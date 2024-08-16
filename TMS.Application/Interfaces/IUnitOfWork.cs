using TMS.Application.Interfaces.Repositories;

namespace TMS.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IEventRepository EventRepository { get; }

        Task<bool> Complete();
    }
}
