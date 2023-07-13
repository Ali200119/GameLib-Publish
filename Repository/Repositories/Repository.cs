using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Helpers;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<T> entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }



        public async Task CreateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();

            await entities.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task CreateMultipleAsync(List<T> entity)
        {
            if (entities is null) throw new ArgumentNullException();

            await entities.AddRangeAsync(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();

            entities.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            return await entities.AsNoTracking().IncludeMultiple(includes).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int? id, params Expression<Func<T, object>>[] includes)
        {
            if (id is null) throw new ArgumentNullException();

            T entity = await entities.AsNoTracking().IncludeMultiple(includes).FirstOrDefaultAsync(e => e.Id == id);

            if (entity is null) throw new NullReferenceException();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();

            entities.Update(entity);
            await SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(T entity)
        {
            if (entity is null) throw new ArgumentNullException();

            entity.SoftDelete = true;

            await SaveChangesAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await entities.CountAsync();
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}