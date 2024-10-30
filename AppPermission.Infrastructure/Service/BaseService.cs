using AppPermission.Domain.Interface;
using System.Threading.Tasks;

namespace AppPermission.Infrastructure.Service
{
    public class BaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly TransitionService _transitionService;

        public BaseService(IBaseRepository<TEntity> repository, TransitionService transitionService)
        {
            _repository = repository;
            _transitionService = transitionService;
        }
        public virtual async Task Save(TEntity entity)
        {
            await _repository.Save(entity);
            await _transitionService.Commit();
        }
        public virtual async Task Update(TEntity entity)
        {
            await _repository.Update(entity);
            await _transitionService.Commit();
        }
        public async Task Remove(TEntity entity)
        {
            await _repository.Remove(entity);
            await _transitionService.Commit();
        }
    }
}
