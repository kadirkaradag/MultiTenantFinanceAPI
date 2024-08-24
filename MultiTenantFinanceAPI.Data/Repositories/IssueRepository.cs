using Microsoft.EntityFrameworkCore;
using MultiTenantFinanceAPI.Core.Entities;
using MultiTenantFinanceAPI.Core.Interfaces;
using MultiTenantFinanceAPI.Data.Context;

namespace MultiTenantFinanceAPI.Data.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly AppDbContext _context;

        public IssueRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Issue> GetByIdAsync(int id)
        {
            return await _context.Issues
                .Include(i => i.Agreement)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Issue>> GetAllAsync()
        {
            return await _context.Issues
                .Include(i => i.Agreement)
                .ToListAsync();
        }

        public async Task AddAsync(Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Issue issue)
        {
            _context.Issues.Update(issue);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            if (issue != null)
            {
                _context.Issues.Remove(issue);
                await _context.SaveChangesAsync();
            }
        }
    }
}
