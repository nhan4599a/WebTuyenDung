using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Text.Json;
using WebTuyenDung.JsonConverters;
using WebTuyenDung.Models;

namespace WebTuyenDung.Helper
{
    public static class DataMigrationHelper
    {
        private static readonly Assembly Assembly = typeof(DataMigrationHelper).Assembly;

        public static ModelBuilder HasData<TEntity>(this ModelBuilder modelBuilder) where TEntity : BaseEntity
        {
            var data = GetData<TEntity>();

            modelBuilder
                .Entity<TEntity>()
                .HasData(data);

            return modelBuilder;
        }

        public static ModelBuilder HasUserData(this ModelBuilder modelBuilder)
        {
            return modelBuilder.HasData<Candidate>().HasData<Employer>().HasData<User>();
        }

        private static TEntity[] GetData<TEntity>() where TEntity : BaseEntity
        {
            var dataFileName = $"WebTuyenDung.DataSamples.{typeof(TEntity).Name}Data.json";
            using var dataFileStream = Assembly.GetManifestResourceStream(dataFileName)!;
            var data = JsonSerializer.Deserialize<TEntity[]>(dataFileStream, ApplicationWideJsonConverter.DefaultSerializerOptions)!;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == 0)
                {
                    data[i].Id = i + 1;
                }
                data[i].IsDeleted = false;
                data[i].CreatedAt = DateTimeOffset.Now;
            }
            return data;
        }
    }
}
