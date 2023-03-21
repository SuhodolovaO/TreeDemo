using Application.DTO;

namespace Application.Services
{
    public interface INodeService
    {
        Task<MNode> GetOrCreateTree(string name);
        Task CreateNode(string treeName, long parentNodeId, string nodeName);
        Task RenameNode(string treeName, long nodeId, string newNodeName);
        Task DeleteNode(string treeName, long nodeId);
    }
}
