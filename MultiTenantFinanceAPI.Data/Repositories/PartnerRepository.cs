using Microsoft.EntityFrameworkCore;
using MultiTenantFinanceAPI.Core.Entities;
using MultiTenantFinanceAPI.Core.Interfaces;
using MultiTenantFinanceAPI.Data.Context;

public class PartnerRepository : IPartnerRepository
{
    private readonly AppDbContext _context;
    public PartnerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Partner>> GetAllAsync()
    {
        return await _context.Partners.ToListAsync();
    }

    public async Task<Partner> GetByIdAsync(int id)
    {
        return await _context.Partners.FindAsync(id);
    }

    public async Task AddAsync(Partner entity)
    {
        await _context.Partners.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Partner entity)
    {
        _context.Partners.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Partner entity)
    {
        _context.Partners.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
