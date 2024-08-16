using TMS.Application.DTOs;
using TMS.Domain.Entities;

namespace TMS.Application.Interfaces.Repositories
{
    public interface IEventRepository
    {
        void AddEvent(TMSEvent model);
    }
}
