namespace Application.DTO
{
    public class ErrorMessage
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public ErrorMessageData Data { get; set; }
    }
}
