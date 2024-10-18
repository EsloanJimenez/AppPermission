using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppPermission.Domain.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetId(int Id);
        Task Save(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
    }
}
