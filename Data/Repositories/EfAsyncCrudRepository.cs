using Common.Exceptions;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EfAsyncCrudRepository<C, T, K> : IAsyncCrudRepository<T, K> where C : DbContext where T : class, IIdentifiable<K>
    {
        /// <summary>
        /// The EF context
        /// </summary>
        protected C _context;

        /// <summary>
        /// 
        /// </summary>
        protected IUserService _userService;

        /// <summary>
        /// The injection constructor.
        /// </summary>
        /// <param name="context">The EF context to use for this repository.</param>
        /// <param name="userService">The user service to use for this repository.</param>
        public EfAsyncCrudRepository(C context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        /// <summary>
        /// Creates an item
        /// </summary>
        /// <param name="item">The item to create</param>
        /// <returns>The created item</returns>
        virtual public async Task<T> Create(T item)
        {
            try
            {
                UpdateTrackableCreated(item);

                await _context.Set<T>().AddAsync(item);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException) when (dbUpdateException.InnerException.Message.Contains("Duplicate"))
            {
                throw new DuplicateResourceException(dbUpdateException.InnerException.Message);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new ResourceValidationException(dbUpdateException.InnerException.Message);
            }

            return item;
        }

        /// <summary>
        /// Creates all items
        /// </summary>
        /// <param name="items">The items to create</param>
        /// <returns>The created items</returns>
        virtual public async Task<IEnumerable<T>> CreateAll(IEnumerable<T> items)
        {
            if (items.Count() == 0)
            {
                // nothing to do
                return new List<T>();
            }

            try
            {
                items = items.Select(item => UpdateTrackableCreated(item));

                await _context.Set<T>().AddRangeAsync(items);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException) when (dbUpdateException.InnerException.Message.Contains("Duplicate"))
            {
                throw new DuplicateResourceException(dbUpdateException.InnerException.Message);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new ResourceValidationException(dbUpdateException.InnerException.Message);
            }

            return items;
        }

        /// <summary>
        /// Deletes an item by its ID
        /// </summary>
        /// <param name="id">The ID of the item to delete</param>
        /// <returns>The deleted item</returns>
        virtual public async Task DeleteById(K id)
        {
            var item = await _context.Set<T>().FindAsync(id);

            if (item == null)
            {
                throw new ResourceNotFoundException($"Could not find {typeof(T).GetType().Name.ToLower()} with key {id}");
            }

            _context.Set<T>().Remove(item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a tracked Datamodel
        /// </summary>
        /// <param name="item">The tracked Datamodel to delete</param>
        /// <returns></returns>
        virtual public async Task Delete(T item)
        {
            _context.Set<T>().Remove(item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a range of tracked Datamodels
        /// </summary>
        /// <param name="items">The collection of Datamodels to delete</param>
        /// <returns></returns>
        virtual public async Task DeleteAll(IEnumerable<T> items)
        {
            if (items.Count() == 0)
            {
                // nothing to do
                return;
            }

            _context.Set<T>().RemoveRange(items);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all Datamodels
        /// </summary>
        /// <param name="skip">The number of records to skip</param>
        /// <param name="limit">The maximum number of records to return</param>
        /// <param name="include">Strings of poco property names to include with the join</param>
        /// <returns></returns>
        virtual public async Task<ListResults<T>> GetAll(int? page = null, int? pageSize = null, params string[] include)
        {
            IQueryable<T> items = _context.Set<T>();

            items = IncludeAll(items, include);
            return await PageResultSet(items, page, pageSize);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        virtual public async Task<T> GetById(K id, params string[] include)
        {
            T result = include.Length > 0
                ? await IncludeAll(_context.Set<T>(), include).SingleOrDefaultAsync(e => e.Id.Equals(id))
                : await _context.Set<T>().FindAsync(id);

            if (result == null)
            {
                throw new ResourceNotFoundException($"Could not find {typeof(T).Name.ToLower()} with key {id}");
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        virtual public async Task<T> Update(T item)
        {
            UpdateTrackableModified(item);

            var itemToUpdate = _context.Set<T>().Find(item.Id);
            _context.Entry(itemToUpdate).CurrentValues.SetValues(item);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new ResourceValidationException(dbUpdateException.InnerException.Message);
            }

            return itemToUpdate;
        }

        /// <summary>
        /// Counts the total number of datamodels in the set
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetCount()
        {
            return await _context.Set<T>().CountAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="E"></typeparam>
        protected static IQueryable<E> IncludeAll<E>(IQueryable<E> items, string[] include) where E : class
        {
            foreach (string property in include)
            {
                items = items.Include(property);
            }

            return items;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <typeparam name="E"></typeparam>
        /// <returns></returns>
        protected static async Task<ListResults<E>> PageResultSet<E>(IQueryable<E> items, int? page, int? pageSize)
        {
            int totalResults = await items.CountAsync();
            int? skip = null;
            int? take = null;

            if (page.HasValue || pageSize.HasValue)
            {
                pageSize = pageSize ?? 25;
                page = page ?? 1;

                if (page < 1)
                {
                    throw new ResourceValidationException("Page size must be greater than 0. Use page = 1 for the first page.");
                }

                skip = (page - 1) * pageSize;
                take = pageSize;
            }

            if (skip.HasValue && take.HasValue)
            {
                items = items.Skip(skip.Value);
                items = items.Take(take.Value);
            }

            return new ListResults<E>()
            {
                Results = await items.ToListAsync(),
                TotalCount = totalResults
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected T UpdateTrackableCreated(T item)
        {
            var trackableItem = item as ITrackable;

            if (trackableItem != null)
            {
                var user = _userService.GetCurrentUser();
                var currentTime = DateTime.UtcNow;

                trackableItem.CreatedBy = trackableItem.CreatedBy ?? user.UserId;
                trackableItem.CreatedAt = currentTime;
                trackableItem.ModifiedBy = trackableItem.ModifiedBy ?? user.UserId;
                trackableItem.ModifiedAt = currentTime;
            }

            return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected T UpdateTrackableModified(T item)
        {
            var trackableItem = item as ITrackable;

            if (trackableItem != null)
            {
                trackableItem.ModifiedBy = trackableItem.ModifiedBy ?? _userService.GetCurrentUser().UserId;
                trackableItem.ModifiedAt = DateTime.UtcNow;
            }

            return item;
        }
    }
}
