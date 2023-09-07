using MailApp.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<EmailLog> EmailLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<EmailAddress>()
               .HasIndex(x => x.Email) // Ürün adına göre bir index oluşturuyoruz
               .IsUnique(); // Bu indexi benzersiz yaparak aynı üründen iki tane eklenmesini engelliyoruz

            base.OnModelCreating(modelBuilder);
        }
    }
}
