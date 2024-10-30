using AppPermission.Domain.Interface;
using AppPermission.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppPermission.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppPermissionContext _context;
        private DbSet<TEntity> _entities;

        public BaseRepository(AppPermissionContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetId(int Id)
        {
            return await _entities.FindAsync(Id);
        }

        public virtual async Task Save(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual async Task Update(TEntity entity)
        {
            _entities.Update(entity);
        }
        public virtual async Task Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }
    }
}
