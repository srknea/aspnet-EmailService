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

        public override int SaveChanges()
        {
            ChangeTracker.Entries().ToList().ForEach(x =>
            {
                if (x.Entity is EmailAddress e)
                {
                    if (x.State == EntityState.Added)
                    {
                        e.CreatedDate = DateTime.Now;
                    }
                    if (x.State == EntityState.Modified)
                    {
                        e.UpdatedDate = DateTime.Now;
                    }
                }
            });

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.Entries().ToList().ForEach(x =>
            {
                if (x.Entity is EmailAddress a)
                {
                    if (x.State == EntityState.Added)
                    {
                        a.CreatedDate = DateTime.Now;
                    }
                    if (x.State == EntityState.Modified)
                    {
                        a.UpdatedDate = DateTime.Now;
                    }
                }

                if (x.Entity is EmailLog l)
                {
                    if (x.State == EntityState.Added)
                    {
                        l.CreatedDate = DateTime.Now;
                    }
                    if (x.State == EntityState.Modified)
                    {
                        l.UpdatedDate = DateTime.Now;
                    }
                }
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
