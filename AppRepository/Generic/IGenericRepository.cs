using System.Linq.Expressions;

namespace AppRepository.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? expression = null, params string[] includeProperties);
        async Task<TEntity?> GetFirst(Expression<Func<TEntity, bool>>? expression = null, params string[] includeProperties) => (await Get(expression, includeProperties)).FirstOrDefault();
    }
}
