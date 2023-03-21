using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class NodeRepository : RepositoryBase<Node>, INodeRepository
    {
        public NodeRepository(Context context) : base(context) { }

        public async Task<IReadOnlyCollection<Node>> GetAllTreeNodes(string treeName)
        {
            return await _dbSet.Where(x => x.Tree != null && x.Tree.Name == treeName).ToListAsync();
        }

        public async Task DeleteMainNode(Node node)
        {
            var tree = await _context.Trees.FirstOrDefaultAsync(x => x.Name == node.Name);

            if (tree is not null)
            {
                _context.Trees.Remove(tree);
            }

            _dbSet.Remove(node);
            _context.SaveChanges();
        }

        public async Task<Node> GetSngleNodeData(long nodeId)
        {
            return await _dbSet.Include(x => x.Tree).Include(x => x.Children).FirstOrDefaultAsync(x => x.Id == nodeId);
        }
    }
}
