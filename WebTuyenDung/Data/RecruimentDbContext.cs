﻿using WebTuyenDung.Data.Conversions;
using WebTuyenDung.Enums;
using WebTuyenDung.Models;
using Microsoft.EntityFrameworkCore;
using WebTuyenDung.Helper;
using System;

namespace WebTuyenDung.Data
{
    public class RecruimentDbContext : DbContext
    {
        public RecruimentDbContext(DbContextOptions<RecruimentDbContext> options) : base(options) { }

        public DbSet<RecruimentNews> RecruimentNews { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Employer> Employers { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder
                .Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<BaseEntity>()
                .HasQueryFilter(e => !e.IsDeleted);

            modelBuilder
                .Entity<BaseEntity>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder
                .Ignore<BaseEntity>()
                .Entity<User>()
                .HasDiscriminator(e => e.Role)
                .HasValue<Candidate>(UserRole.Candidate)
                .HasValue<Employer>(UserRole.Employer)
                .HasValue<User>(UserRole.Admin);

            modelBuilder
                .HasUserData()
                .HasData<RecruimentNews>()
                .HasData<Post>();
        }
    }
}
