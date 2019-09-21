using Pishkhan.Data;
using Pishkhan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pishkhan.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppIdentityDbContext _context;
        public BaseRepository(AppIdentityDbContext context)
        {
            _context = context;
        }

        public ServiceResult Create(TEntity entity)
        {
            _context.Add(entity);
            return Save();
        }
        private ServiceResult Save()
        {
            if (_context.SaveChanges() > 0)
                return ServiceResult.Okay();
            return ServiceResult.Error();
        }
    }
}
