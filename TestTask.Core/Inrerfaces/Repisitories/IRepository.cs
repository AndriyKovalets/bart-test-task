using System.Linq.Expressions;
using TestTask.Domain.Entities;

namespace TestTask.Core.Inrerfaces.Repisitories
{
    public interface IRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByKeyAsync<TKey>(TKey key);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);
        Task<int> SaveChangesAsync();
    }
}
