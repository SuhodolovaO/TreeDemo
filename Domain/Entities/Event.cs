using Domain.Enums;

namespace Domain.Entities
{
    public class Event : BaseEntity
    {
        public long EventId { get; internal set; }
        public string Type { get; internal set; }
        public string Message { get; internal set; }
        public DateTime CreatedAt { get; internal set; }

        public Event(string message)
        {
            FillEventData(EventTypes.Exception, message);
        }

        public Event(EventTypes type, string message)
        {
            FillEventData(type, message);
        }

        private void FillEventData(EventTypes type, string message)
        {
            EventId = GetMockEventId();
            Type = type.ToString();
            Message = string.IsNullOrWhiteSpace(message) ? $"Internal server error ID = {EventId}" : message;
            CreatedAt = DateTime.UtcNow;
        }

        private long GetMockEventId()
        {
            var rand = new Random();
            return rand.NextInt64(1000);
        }
    }
}
