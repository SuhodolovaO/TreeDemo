using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TreeDemo.Controllers
{
    [ApiController]
    public class TreeController : ControllerBase
    {
        private INodeService _nodeService;

        public TreeController(INodeService service)
        {
            _nodeService = service;
        }

        /// <summary>
        /// Returns your entire tree. If your tree doesn't exist it will be created automatically.
        /// </summary>
        [HttpPost]
        [Route("api.user.tree.get")]
        [ProducesResponseType(typeof(MNode), StatusCodes.Status200OK)]
        public async Task<MNode> GetOrCreate([Required] string treeName)
        {
            return await _nodeService.GetOrCreateTree(treeName);
        }
    }
}