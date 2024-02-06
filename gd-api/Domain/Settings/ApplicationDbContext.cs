using gd_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace gd_api.Domain.Settings
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<FileEntity> file { get; set; }
        public DbSet<UserEntity> user { get; set; }
        public DbSet<AddressEntity> address { get; set; }
        public DbSet<CompanyEntity> company { get; set; }
        public DbSet<ProductEntity> product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
    }
}
