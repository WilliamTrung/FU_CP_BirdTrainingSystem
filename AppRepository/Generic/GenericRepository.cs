using AppCore.Context;
using AppRepository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppRepository.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly BirdTrainingSystemContext _context;
        public readonly IUnitOfWork _unitOfWork;
        private DbSet<TEntity> _entities;
        public GenericRepository(BirdTrainingSystemContext context, IUnitOfWork unitOfWork)
        {
            _context= context;
            _entities = _context.Set<TEntity>();
            _unitOfWork= unitOfWork;
        }
        public virtual async Task Add(TEntity entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(TEntity entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? expression = null, params string[] includeProperties)
        {
            IQueryable<TEntity>? query = _entities;
            query = expression == null ? query : query.Where(expression); 
            if (includeProperties != null)
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }
            return await query.ToListAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
