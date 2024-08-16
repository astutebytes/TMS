using TMS.Application.Interfaces;
using TMS.Application.Interfaces.Repositories;
using TMS.Persistence.Data;

namespace TMS.Persistence.Repositories
{
    public class UnitOfWork(DataContext context, IEventRepository eventRepository) : IUnitOfWork
    {
        public IEventRepository EventRepository => eventRepository;

        public async Task<bool> Complete()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
