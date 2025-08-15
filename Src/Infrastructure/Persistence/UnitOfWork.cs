using Application.Contracts;
using Domain.Entities.Base;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork

{
    private readonly ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    public DbContext Context => _context;

    public IGenericRepository<T> Repository<T>() where T : BaseEntity
    { 
        return new GenericRepository<T>(_context);
    }
    public async Task<int> Save(CancellationToken cancellationToken)=> 
        await _context.SaveChangesAsync(cancellationToken);
    
}
