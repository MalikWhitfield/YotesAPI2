using Data.Interfaces;
using Data.Models;
using System;

namespace Data.Repositories
{
    public class EfYoteRepository : EfAsyncCrudRepository<YoteContext, Yote, Guid>
    {
        public EfYoteRepository(YoteContext yoteContext, IUserService userService) : base(yoteContext, userService)
        {

        }
    }
}
