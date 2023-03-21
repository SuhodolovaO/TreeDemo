using Application.DTO;
using Domain.Enums;

namespace Application.Services
{
    public interface IEventService
    {
        Task<ErrorMessage> CreateErrorEvent(EventTypes type, string message);
    }
}
