using GalaxyHotel.Core.Interfaces;
using GalaxyHotel.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyHotel.Infrastructure.Data
{
    public class Repository<T> : IAsyncRepository<T> where T : BaseEntity//, IAggregateRoot
    {
        protected readonly GalaxyHotelContext dbContext;

        public Repository(GalaxyHotelContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<T> FirstAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstAsync();
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}