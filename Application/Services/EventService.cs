using Application.DTO;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;

namespace Application.Services
{
    public class EventService : IEventService
    {
        private IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<ErrorMessage> CreateErrorEvent(EventTypes type, string message)
        {
            var newEvent = new Event(type, message);
            await _eventRepository.Create(newEvent);

            return new ErrorMessage {
                Id = newEvent.EventId,
                Type = newEvent.Type,
                CreatedAt = newEvent.CreatedAt,
                Data = new ErrorMessageData { Message = newEvent.Message }
            };
        }
    }
}
