using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TreeDemo.Controllers
{
    [ApiController]
    public class NodeController : ControllerBase
    {
        private INodeService _service;

        public NodeController(INodeService service)
        {
            _service = service;
        }

        /// <summary>
        /// Create a new node in your tree. You must to specify a parent node ID that belongs to your tree. A new node name must be unique across all siblings.
        /// </summary>
        [HttpPost]
        [Route("api.user.tree.node.create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task Create([Required] string treeName, [Required] long parentNodeId, [Required] string nodeName) =>
            await _service.CreateNode(treeName, parentNodeId, nodeName);

        /// <summary>
        /// Rename an existing node in your tree. You must specify a node ID that belongs your tree. A new name of the node must be unique across all siblings.
        /// </summary>
        [HttpPost]
        [Route("api.user.tree.node.rename")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task Rename([Required] string treeName, [Required] long nodeId, [Required] string newNodeName) =>
            await _service.RenameNode(treeName, nodeId, newNodeName);

        /// <summary>
        /// Delete an existing node in your tree. You must specify a node ID that belongs your tree.
        /// </summary>
        [HttpPost]
        [Route("api.user.tree.node.delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task Delete([Required] string treeName, [Required] long nodeId) =>
            await _service.DeleteNode(treeName, nodeId);
    }
}
