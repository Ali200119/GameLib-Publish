using System;
using System.Linq.Expressions;
using Domain.Common;

namespace Repository.Repositories.Interfaces
{
	public interface IRepository<T> where T: BaseEntity
	{
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int? id, params Expression<Func<T, object>>[] includes);
        Task CreateAsync(T entity);
        Task CreateMultipleAsync(List<T> entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SoftDeleteAsync(T entity);
        Task<int> GetCountAsync();
    }
}