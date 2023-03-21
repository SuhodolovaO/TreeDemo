namespace Domain.Entities
{
    public class Node : BaseEntity
    {
        public Tree? Tree { get; internal set; }
        public Node? Parent { get; internal set; }
        public List<Node> Children { get; internal set; } = new();

        public long TreeId { get; internal set; }
        public long? ParentId { get; internal set; }
        public string Name { get; internal set; }

        public Node(long treeId, long parentId, string name)
        {
            TreeId = treeId;
            ParentId = parentId;
            Name = name;
        }

        public Node(string name)
        {
            Tree = new Tree { Name = name };
            Name = name;
        }

        public void Rename(string newName)
        {
            Name = newName;
        }
    }
}
