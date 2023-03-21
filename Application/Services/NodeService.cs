using Application.DTO;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Data;

namespace Application.Services
{
    public class NodeService : INodeService
    {
        private INodeRepository _nodeRepository;

        public NodeService(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        public async Task<MNode> GetOrCreateTree(string name)
        {
            var treeNodes = await _nodeRepository.GetAllTreeNodes(name);

            if (!treeNodes.Any())
            {
                var newMainNode = new Node(name);
                await _nodeRepository.Create(newMainNode);
                treeNodes = await _nodeRepository.GetAllTreeNodes(name);
            }

            var nodesTree = NodesListToDTO(treeNodes, null);

            return nodesTree.First();
        }

        public async Task CreateNode(string treeName, long parentNodeId, string nodeName)
        {
            var parentNode = await _nodeRepository.GetSngleNodeData(parentNodeId);
            ValidateNodeSearch(treeName, parentNodeId, parentNode);
            ValidateNewChildName(parentNode, nodeName);

            var newNode = new Node(parentNode.TreeId, parentNodeId, nodeName);
            await _nodeRepository.Create(newNode);
        }

        public async Task RenameNode(string treeName, long nodeId, string newNodeName)
        {
            var node = await _nodeRepository.GetSngleNodeData(nodeId);
            ValidateNodeSearch(treeName, nodeId, node);

            if (node.ParentId is null)
                throw new SecureException("Couldn't rename root node");

            var parentNode = await _nodeRepository.GetSngleNodeData(node.ParentId.Value);
            ValidateNewChildName(parentNode, newNodeName);

            node.Rename(newNodeName);
            await _nodeRepository.Update(node);
        }

        public async Task DeleteNode(string treeName, long nodeId)
        {
            var node = await _nodeRepository.GetSngleNodeData(nodeId);
            ValidateNodeSearch(treeName, nodeId, node);

            if (node.Children.Any())
                throw new SecureException("You have to delete all children nodes first");

            if (node.ParentId is null)
            {
                await _nodeRepository.DeleteMainNode(node);
            }
            else
            {
                await _nodeRepository.Delete(node);
            }
            
        }

        private void ValidateNodeSearch(string treeName, long nodeId, Node node)
        {
            if (node is null)
                throw new SecureException($"Node with ID = {nodeId} was not found");

            if (node.Tree?.Name != treeName)
                throw new SecureException("Requested node was found, but it doesn't belong your tree");
        }

        private void ValidateNewChildName(Node node, string newNodeName)
        { 
            if(node.Children.Any(x => x.Name == newNodeName))
                throw new SecureException("Duplicate name");
        }

        private IEnumerable<MNode> NodesListToDTO(IEnumerable<Node> nodes, long? parentNodeId)
        {
            foreach (var node in nodes.Where(x => x.ParentId == parentNodeId))
            {
                yield return new MNode {
                    Id = node.Id,
                    Name = node.Name,
                    Children = NodesListToDTO(node.Children, node.Id)
                };
            }
        }
    }
}
