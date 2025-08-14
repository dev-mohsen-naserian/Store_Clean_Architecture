using Application.Contracts;
using Domain.Entities.Base;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public async Task<T> AddAsync(T Entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(Entity, cancellationToken);
        return await Task.FromResult(Entity);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
    {
        return await AnyAsync(expression, cancellationToken);
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken)
    {
        return await AnyAsync(cancellationToken);
    }

    public void Delete(T Entity)
    {
        _context.Entry(Entity).State = EntityState.Deleted;
    }

    public async Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<T> GetByIDAsync(int Id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(Id, cancellationToken);
    }

    public Task<T> UpdateAsync(T Entity)
    {
        _context.Entry(Entity).State = EntityState.Modified;
        return Task.FromResult(Entity);
    }
}
