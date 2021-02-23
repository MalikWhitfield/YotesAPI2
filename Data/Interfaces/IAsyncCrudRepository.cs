using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IAsyncCrudRepository<T, K> where T : IIdentifiable<K>
    {
        Task<T> Create(T item);
        Task<IEnumerable<T>> CreateAll(IEnumerable<T> items);
        Task Delete(T item);
        Task DeleteAll(IEnumerable<T> items);
        Task DeleteById(K id);
        Task<ListResults<T>> GetAll(int? page = null, int? pageSize = null, params string[] include);
        Task<T> GetById(K id, params string[] include);
        Task<int> GetCount();
        Task<T> Update(T item);
    }
}
