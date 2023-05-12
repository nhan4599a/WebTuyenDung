using WebTuyenDung.Data.Conversions;
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

        public DbSet<Locale> Locales { get; set; }

        public DbSet<CurriculumVitae> CVs { get; set; }

        public DbSet<JobApplication> JobApplications { get; set; }

        public DbSet<SavedRecruimentNews> SavedRecruimentNews { get; set; }

        public DbSet<CurriculumVitaeDetail> CVDetails { get; set; }

        public DbSet<PotentialCandidateCount> PotentialCandidateCount { get; set; }

        public DbSet<LikedCurriculumVitae> LikedCVs { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder
                .Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>();

            configurationBuilder
                .Properties<DateOnly?>()
                .HaveConversion<NullableDateOnlyConverter>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                .HasData<Post>()
                .HasData<Locale>();
        }
    }
}
