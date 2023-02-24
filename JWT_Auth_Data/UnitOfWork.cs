using JWT_Auth_Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JWT_Auth_Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;

    public UnitOfWork(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public async Task CommmitAsync()
    {
        await _context.SaveChangesAsync();
    }
}