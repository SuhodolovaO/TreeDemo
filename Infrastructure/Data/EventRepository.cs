using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(Context context) : base(context)
        {
        }

        public async Task<IReadOnlyCollection<Event>> GetByFilter(
            int skip, int take, DateTime? dateFrom, DateTime? dateTo, string filterText)
        {
            return await _dbSet
                .Where(x => !dateFrom.HasValue || x.CreatedAt >= dateFrom.Value)
                .Where(x => !dateTo.HasValue || x.CreatedAt <= dateTo.Value)
                .Where(x => string.IsNullOrWhiteSpace(filterText) || x.Message.Contains(filterText))
                .Skip(skip).Take(take)
                .ToListAsync();
        }
    }
}
