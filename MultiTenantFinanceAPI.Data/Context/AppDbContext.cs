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

            // Seed verilerini ekleme
            modelBuilder.Entity<Agreement>().HasData(
                new Agreement
                {
                    Id = 1,
                    Name = "Agreement 1",
                    Amount = 10000m,
                    Cost = 5000m,
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = new DateTime(2023, 12, 31),
                    TenantId = 1
                },
                new Agreement
                {
                    Id = 2,
                    Name = "Agreement 2",
                    Amount = 15000m,
                    Cost = 7500m,
                    StartDate = new DateTime(2023, 2, 1),
                    EndDate = new DateTime(2023, 11, 30),
                    TenantId = 2
                },
                new Agreement
                {
                    Id = 3,
                    Name = "Agreement 3",
                    Amount = 20000m,
                    Cost = 10000m,
                    StartDate = new DateTime(2023, 3, 1),
                    EndDate = new DateTime(2023, 10, 31),
                    TenantId = 1
                },
                new Agreement
                {
                    Id = 4,
                    Name = "Agreement 4",
                    Amount = 25000m,
                    Cost = 12500m,
                    StartDate = new DateTime(2023, 4, 1),
                    EndDate = new DateTime(2023, 9, 30),
                    TenantId = 2
                },
                new Agreement
                {
                    Id = 5,
                    Name = "Agreement 5",
                    Amount = 30000m,
                    Cost = 15000m,
                    StartDate = new DateTime(2023, 5, 1),
                    EndDate = new DateTime(2023, 8, 31),
                    TenantId = 1
                },
                new Agreement
                {
                    Id = 6,
                    Name = "Agreement 6",
                    Amount = 35000m,
                    Cost = 17500m,
                    StartDate = new DateTime(2023, 6, 1),
                    EndDate = new DateTime(2023, 7, 31),
                    TenantId = 2
                }
            );

            modelBuilder.Entity<Partner>().HasData(
                new Partner
                {
                    Id = 1,
                    Name = "Partner 1",
                    ContactInfo = "partner1@example.com",
                    TenantId = 1
                },
                new Partner
                {
                    Id = 2,
                    Name = "Partner 2",
                    ContactInfo = "partner2@example.com",
                    TenantId = 2
                },
                new Partner
                {
                    Id = 3,
                    Name = "Partner 3",
                    ContactInfo = "partner3@example.com",
                    TenantId = 1
                },
                new Partner
                {
                    Id = 4,
                    Name = "Partner 4",
                    ContactInfo = "partner4@example.com",
                    TenantId = 2
                },
                new Partner
                {
                    Id = 5,
                    Name = "Partner 5",
                    ContactInfo = "partner5@example.com",
                    TenantId = 1
                },
                new Partner
                {
                    Id = 6,
                    Name = "Partner 6",
                    ContactInfo = "partner6@example.com",
                    TenantId = 2
                }
            );


            modelBuilder.Entity<Issue>().HasData(
                new Issue
                {
                    Id = 1,
                    Title = "Issue 1",
                    Description = "Description for Issue 1",
                    Keywords = "critical, high",
                    Cost = 3000m,
                    AgreementAmount = 10000m,
                    RiskLevel = RiskLevel.High,
                    RiskAmount = 500m,
                    AgreementId = 1,
                    TenantId = 1
                },
                new Issue
                {
                    Id = 2,
                    Title = "Issue 2",
                    Description = "Description for Issue 2",
                    Keywords = "important, medium",
                    Cost = 4000m,
                    AgreementAmount = 15000m,
                    RiskLevel = RiskLevel.Medium,
                    RiskAmount = 300m,
                    AgreementId = 2,
                    TenantId = 2
                },
                new Issue
                {
                    Id = 3,
                    Title = "Issue 3",
                    Description = "Description for Issue 3",
                    Keywords = "low, minimal",
                    Cost = 2000m,
                    AgreementAmount = 20000m,
                    RiskLevel = RiskLevel.Low,
                    RiskAmount = 200m,
                    AgreementId = 3,
                    TenantId = 1
                },
                new Issue
                {
                    Id = 4,
                    Title = "Issue 4",
                    Description = "Description for Issue 4",
                    Keywords = "critical, high",
                    Cost = 7000m,
                    AgreementAmount = 25000m,
                    RiskLevel = RiskLevel.High,
                    RiskAmount = 1000m,
                    AgreementId = 4,
                    TenantId = 2
                },
                new Issue
                {
                    Id = 5,
                    Title = "Issue 5",
                    Description = "Description for Issue 5",
                    Keywords = "important, medium",
                    Cost = 5000m,
                    AgreementAmount = 30000m,
                    RiskLevel = RiskLevel.Medium,
                    RiskAmount = 700m,
                    AgreementId = 5,
                    TenantId = 1
                },
                new Issue
                {
                    Id = 6,
                    Title = "Issue 6",
                    Description = "Description for Issue 6",
                    Keywords = "low, minimal",
                    Cost = 3500m,
                    AgreementAmount = 35000m,
                    RiskLevel = RiskLevel.Low,
                    RiskAmount = 400m,
                    AgreementId = 6,
                    TenantId = 2
                }
            );

            // Tenant-based filtering (seed işleminden sonra eklenir)
            modelBuilder.Entity<Agreement>().HasQueryFilter(a => a.TenantId == _tenantProvider.TenantId);
            modelBuilder.Entity<Partner>().HasQueryFilter(p => p.TenantId == _tenantProvider.TenantId);
            modelBuilder.Entity<Issue>().HasQueryFilter(i => i.TenantId == _tenantProvider.TenantId);
        }
    }

}
