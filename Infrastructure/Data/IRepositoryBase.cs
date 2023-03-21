using Domain.Entities;

namespace Infrastructure.Data
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task<T> GetById(long id);
        Task<long> Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
