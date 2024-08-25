using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MultiTenantFinanceAPI.Core.Entities;
using MultiTenantFinanceAPI.Core.Entities.Enums;
using MultiTenantFinanceAPI.Core.Interfaces;

namespace MultiTenantFinanceAPI.Data.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ITenantProvider _tenantProvider;

        public AppDbContext(DbContextOptions<AppDbContext> options, ITenantProvider tenantProvider) : base(options)
        {
            _tenantProvider = tenantProvider;
        }

        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Issue> Issues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tenant-based filtering
            modelBuilder.Entity<Agreement>().HasQueryFilter(a => a.TenantId == _tenantProvider.TenantId);
            modelBuilder.Entity<Partner>().HasQueryFilter(p => p.TenantId == _tenantProvider.TenantId);
            modelBuilder.Entity<Issue>().HasQueryFilter(i => i.TenantId == _tenantProvider.TenantId);

            // Seed verileri ekleme
            modelBuilder.Entity<Agreement>().HasData(
                new Agreement { Id = 1, Name = "Agreement 1", Amount = 10000, Cost = 8000, TenantId = 1 },
                new Agreement { Id = 2, Name = "Agreement 2", Amount = 15000, Cost = 12000, TenantId = 1 }
            );

            modelBuilder.Entity<Partner>().HasData(
        new Partner { Id = 1, Name = "Partner A", ContactInfo = "partnera@example.com", TenantId = 1 },
        new Partner { Id = 2, Name = "Partner B", ContactInfo = "partnerb@example.com", TenantId = 1 }
    );

            modelBuilder.Entity<Issue>().HasData(
          new Issue
          {
              Id = 1,
              Title = "Issue 1",
              Description = "Description 1",
              RiskAmount = 500,
              AgreementId = 1,
              Keywords = "critical",
              Cost = 3000,
              AgreementAmount = 10000,
              RiskLevel = RiskLevel.High
          },
          new Issue
          {
              Id = 2,
              Title = "Issue 2",
              Description = "Description 2",
              RiskAmount = 300,
              AgreementId = 2,
              Keywords = "important",
              Cost = 1000,
              AgreementAmount = 20000,
              RiskLevel = RiskLevel.Medium
          }
      );
        }
    }

}
