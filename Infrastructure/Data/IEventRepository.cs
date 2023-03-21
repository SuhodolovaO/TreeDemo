using Domain.Entities;

namespace Infrastructure.Data
{
    public interface IEventRepository : IRepositoryBase<Event>
    {
        Task<IReadOnlyCollection<Event>> GetByFilter(
            int skip, int take, DateTime? dateFrom, DateTime? dateTo, string filterText);
    }
}
