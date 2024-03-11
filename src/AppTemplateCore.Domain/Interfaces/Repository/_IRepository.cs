using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplateCore.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(Guid id);

        Task<TEntity?> GetByIdAsync(int id);

        int Add(TEntity obj);

        Task<IPagingResult<TEntity>?> GetAllPagingAsync(int? pageSize, int? page);

        [Obsolete("Use new method GetAllPagingAsync()")]
        Task<IEnumerable<TEntity>?> GetAllAsync();

        IPagingResult<TEntity>? FindPaging(Expression<Func<TEntity, bool>> predicate, int pageSize = 50, int page = 1);

        Task<IEnumerable<TEntity>?> Find(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity?> Update(TEntity obj);

        Task<int> Remove(Guid id);

        Task<int> Remove(int id);

        int SaveChanges();
    }
}