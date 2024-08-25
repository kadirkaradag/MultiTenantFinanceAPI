﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiTenantFinanceAPI.Data.Context;

#nullable disable

namespace MultiTenantFinanceAPI.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MultiTenantFinanceAPI.Core.Entities.Agreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartnerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.ToTable("Agreements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 10000m,
                            Cost = 5000m,
                            EndDate = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Agreement 1",
                            PartnerId = 1,
                            StartDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 15000m,
                            Cost = 7500m,
                            EndDate = new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Agreement 2",
                            PartnerId = 1,
                            StartDate = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenantId = 2
                        },
                        new
                        {
                            Id = 3,
                            Amount = 20000m,
                            Cost = 10000m,
                            EndDate = new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Agreement 3",
                            PartnerId = 1,
                            StartDate = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenantId = 1
                        },
                        new
                        {
                            Id = 4,
                            Amount = 25000m,
                            Cost = 12500m,
                            EndDate = new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Agreement 4",
                            PartnerId = 1,
                            StartDate = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenantId = 2
                        },
                        new
                        {
                            Id = 5,
                            Amount = 30000m,
                            Cost = 15000m,
                            EndDate = new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Agreement 5",
                            PartnerId = 1,
                            StartDate = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenantId = 1
                        },
                        new
                        {
                            Id = 6,
                            Amount = 35000m,
                            Cost = 17500m,
                            EndDate = new DateTime(2023, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Agreement 6",
                            PartnerId = 1,
                            StartDate = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TenantId = 2
                        });
                });

            modelBuilder.Entity("MultiTenantFinanceAPI.Core.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("MultiTenantFinanceAPI.Core.Entities.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("AgreementAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("AgreementId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Keywords")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RiskAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RiskLevel")
                        .HasColumnType("int");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgreementId");

                    b.ToTable("Issues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgreementAmount = 10000m,
                            AgreementId = 1,
                            Cost = 3000m,
                            Description = "Description for Issue 1",
                            Keywords = "critical, high",
                            RiskAmount = 500m,
                            RiskLevel = 2,
                            TenantId = 1,
                            Title = "Issue 1"
                        },
                        new
                        {
                            Id = 2,
                            AgreementAmount = 15000m,
                            AgreementId = 2,
                            Cost = 4000m,
                            Description = "Description for Issue 2",
                            Keywords = "important, medium",
                            RiskAmount = 300m,
                            RiskLevel = 1,
                            TenantId = 2,
                            Title = "Issue 2"
                        },
                        new
                        {
                            Id = 3,
                            AgreementAmount = 20000m,
                            AgreementId = 3,
                            Cost = 2000m,
                            Description = "Description for Issue 3",
                            Keywords = "low, minimal",
                            RiskAmount = 200m,
                            RiskLevel = 0,
                            TenantId = 1,
                            Title = "Issue 3"
                        },
                        new
                        {
                            Id = 4,
                            AgreementAmount = 25000m,
                            AgreementId = 4,
                            Cost = 7000m,
                            Description = "Description for Issue 4",
                            Keywords = "critical, high",
                            RiskAmount = 1000m,
                            RiskLevel = 2,
                            TenantId = 2,
                            Title = "Issue 4"
                        },
                        new
                        {
                            Id = 5,
                            AgreementAmount = 30000m,
                            AgreementId = 5,
                            Cost = 5000m,
                            Description = "Description for Issue 5",
                            Keywords = "important, medium",
                            RiskAmount = 700m,
                            RiskLevel = 1,
                            TenantId = 1,
                            Title = "Issue 5"
                        },
                        new
                        {
                            Id = 6,
                            AgreementAmount = 35000m,
                            AgreementId = 6,
                            Cost = 3500m,
                            Description = "Description for Issue 6",
                            Keywords = "low, minimal",
                            RiskAmount = 400m,
                            RiskLevel = 0,
                            TenantId = 2,
                            Title = "Issue 6"
                        });
                });

            modelBuilder.Entity("MultiTenantFinanceAPI.Core.Entities.Partner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Partners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContactInfo = "partner1@example.com",
                            Name = "Partner 1",
                            TenantId = 1
                        },
                        new
                        {
                            Id = 2,
                            ContactInfo = "partner2@example.com",
                            Name = "Partner 2",
                            TenantId = 2
                        },
                        new
                        {
                            Id = 3,
                            ContactInfo = "partner3@example.com",
                            Name = "Partner 3",
                            TenantId = 1
                        },
                        new
                        {
                            Id = 4,
                            ContactInfo = "partner4@example.com",
                            Name = "Partner 4",
                            TenantId = 2
                        },
                        new
                        {
                            Id = 5,
                            ContactInfo = "partner5@example.com",
                            Name = "Partner 5",
                            TenantId = 1
                        },
                        new
                        {
                            Id = 6,
                            ContactInfo = "partner6@example.com",
                            Name = "Partner 6",
                            TenantId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MultiTenantFinanceAPI.Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MultiTenantFinanceAPI.Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiTenantFinanceAPI.Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MultiTenantFinanceAPI.Core.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MultiTenantFinanceAPI.Core.Entities.Agreement", b =>
                {
                    b.HasOne("MultiTenantFinanceAPI.Core.Entities.Partner", "Partner")
                        .WithMany("Agreements")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("MultiTenantFinanceAPI.Core.Entities.Issue", b =>
                {
                    b.HasOne("MultiTenantFinanceAPI.Core.Entities.Agreement", "Agreement")
                        .WithMany("Issues")
                        .HasForeignKey("AgreementId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Agreement");
                });

            modelBuilder.Entity("MultiTenantFinanceAPI.Core.Entities.Agreement", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("MultiTenantFinanceAPI.Core.Entities.Partner", b =>
                {
                    b.Navigation("Agreements");
                });
#pragma warning restore 612, 618
        }
    }
}
