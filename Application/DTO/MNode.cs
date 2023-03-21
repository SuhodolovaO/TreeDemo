namespace Application.DTO
{
    public class MNode
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MNode> Children { get; set; }
    }
}
