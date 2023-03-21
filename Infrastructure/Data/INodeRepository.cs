using Domain.Entities;

namespace Infrastructure.Data
{
    public interface INodeRepository : IRepositoryBase<Node>
    {
        Task<IReadOnlyCollection<Node>> GetAllTreeNodes(string treeName);
        Task<Node> GetSngleNodeData(long nodeId);
        Task DeleteMainNode(Node node);
    }
}
