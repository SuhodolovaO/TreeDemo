namespace Application.DTO
{
    public class MRange
    {
        public int Skip { get; set; }
        public int Count { get; set; }
        public IEnumerable<MJournalInfo> Items { get; set; }
    }
}
