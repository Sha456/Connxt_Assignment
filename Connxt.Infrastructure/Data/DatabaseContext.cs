using Connxt.Core.Entities;
using Connxt.Core.Entities.Interface;
using Connxt.Core.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Connxt.Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<CreditCardValidation> CreditCardValidations { get; set; }
        public DbSet<CreditCardProperty> CreditCardProperties { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CreditCardValidationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CreditCardPropertyEntityConfiguration());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(IAuditable).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder.Entity(entityType.ClrType).Property<DateTimeOffset>("CreatedDate");
                modelBuilder.Entity(entityType.ClrType).Property<DateTimeOffset>("ModifiedDate");
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}