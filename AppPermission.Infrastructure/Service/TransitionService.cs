using AppPermission.Infrastructure.Context;
using System.Threading.Tasks;

namespace AppPermission.Infrastructure.Service
{
    public class TransitionService
    {
        private readonly AppPermissionContext _context;

        public TransitionService(AppPermissionContext context)
        {
            _context = context;
        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
