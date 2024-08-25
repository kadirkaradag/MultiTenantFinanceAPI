using Microsoft.EntityFrameworkCore;
using MultiTenantFinanceAPI.Core.Entities;
using MultiTenantFinanceAPI.Core.Interfaces;
using MultiTenantFinanceAPI.Data.Context;

namespace MultiTenantFinanceAPI.Data.Repositories
{
    public class AgreementRepository : IAgreementRepository
    {
        private readonly AppDbContext _context;

        public AgreementRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Agreement> GetByIdAsync(int id)
        {
            return await _context.Agreements.Include(a => a.Issues).Include(a => a.Partner).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Agreement>> GetAllAsync()
        {
            return await _context.Agreements.Include(a => a.Issues).Include(a => a.Partner).ToListAsync();
        }

        public async Task AddAsync(Agreement agreement)
        {
            await _context.Agreements.AddAsync(agreement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Agreement agreement)
        {
            _context.Agreements.Update(agreement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var agreement = await _context.Agreements.FindAsync(id);
            if (agreement != null)
            {
                _context.Agreements.Remove(agreement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
