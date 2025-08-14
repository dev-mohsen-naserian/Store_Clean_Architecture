using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIDAsync(int Id, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T> AddAsync(T Entity, CancellationToken cancellationToken);
    Task<T> UpdateAsync(T Entity);
    void Delete(T Entity);
    Task<bool> AnyAsync(Expression<Func<T,bool>> expression, CancellationToken cancellationToken);
    Task<bool> AnyAsync(CancellationToken cancellationToken);
}
