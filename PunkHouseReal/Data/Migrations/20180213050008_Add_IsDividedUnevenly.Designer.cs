﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using PunkHouseReal.Data;
using PunkHouseReal.Models.EnumsAndConstants;
using System;

namespace PunkHouseReal.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180213050008_Add_IsDividedUnevenly")]
    partial class Add_IsDividedUnevenly
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PunkHouseReal.Domain.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatorId");

                    b.Property<DateTimeOffset>("DateCreated");

                    b.Property<DateTimeOffset>("DateModified");

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<int>("ExpenseType");

                    b.Property<int>("HouseId");

                    b.Property<bool>("IsDividedUnevenly");

                    b.Property<bool>("IsPaid");

                    b.Property<string>("Name");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("HouseId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("PunkHouseReal.Domain.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("CreatorId");

                    b.Property<DateTimeOffset>("DateCreated");

                    b.Property<DateTimeOffset>("DateModified");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("PunkHouseReal.Domain.HouseMateExpense", b =>
                {
                    b.Property<string>("HouseMateId");

                    b.Property<int>("ExpenseId");

                    b.Property<bool>("IsPaid");

                    b.Property<decimal>("Total");

                    b.HasKey("HouseMateId", "ExpenseId");

                    b.HasAlternateKey("ExpenseId", "HouseMateId");

                    b.ToTable("HouseMateExpenses");
                });

            modelBuilder.Entity("PunkHouseReal.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTimeOffset>("DateCreated");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("PunkHouseReal.Domain.HouseMate", b =>
                {
                    b.HasBaseType("PunkHouseReal.Models.ApplicationUser");

                    b.Property<DateTimeOffset>("DateModified");

                    b.Property<int?>("HouseId");

                    b.HasIndex("HouseId");

                    b.ToTable("HouseMate");

                    b.HasDiscriminator().HasValue("HouseMate");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PunkHouseReal.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PunkHouseReal.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PunkHouseReal.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PunkHouseReal.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PunkHouseReal.Domain.Expense", b =>
                {
                    b.HasOne("PunkHouseReal.Domain.HouseMate", "HouseMate")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("PunkHouseReal.Domain.House", "House")
                        .WithMany("Expenses")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PunkHouseReal.Domain.HouseMateExpense", b =>
                {
                    b.HasOne("PunkHouseReal.Domain.Expense", "Expense")
                        .WithMany("HouseMateExpenses")
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PunkHouseReal.Domain.HouseMate", "HouseMate")
                        .WithMany("HouseMateExpenses")
                        .HasForeignKey("HouseMateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PunkHouseReal.Domain.HouseMate", b =>
                {
                    b.HasOne("PunkHouseReal.Domain.House", "House")
                        .WithMany("HouseMates")
                        .HasForeignKey("HouseId");
                });
#pragma warning restore 612, 618
        }
    }
}
