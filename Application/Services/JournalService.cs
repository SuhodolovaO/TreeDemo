using Application.DTO;
using Domain.Entities;
using Infrastructure.Data;

namespace Application.Services
{
    public class JournalService : IJournalService
    {
        private IEventRepository _eventRepository;

        public JournalService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<MRange> GetJournalRange(int skip, int take, VJournalFilter filter)
        {
            var events = await _eventRepository.GetByFilter(skip, take, filter?.From, filter?.To, filter?.Search);

            return new MRange { 
                Skip = skip,
                Count = events.Count(),
                Items = events.Select(x => EventToJournalInfo(x))
            };
        }

        public async Task<MJournalInfo> GetSingleJournalInfo(long id)
        {
            var eventObj = await _eventRepository.GetById(id);

            return EventToJournalInfo(eventObj);
        }

        private MJournalInfo EventToJournalInfo(Event eventObj)
        {
            return new MJournalInfo {
                Id = eventObj.Id,
                EventId = eventObj.EventId,
                CreatedAt = eventObj.CreatedAt
            };
        }
    }
}
