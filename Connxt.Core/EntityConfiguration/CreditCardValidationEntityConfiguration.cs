using Connxt.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connxt.Core.EntityConfiguration
{
    public class CreditCardValidationEntityConfiguration : IEntityTypeConfiguration<CreditCardValidation>
    {
        public void Configure(EntityTypeBuilder<CreditCardValidation> builder)
        {
            builder.ToTable("CreditCardValidations");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CardName)
                           .IsRequired(true)
                           .HasMaxLength(70);

            builder.Property(c => c.CardValidationConfiguration)
                           .IsRequired(true)
                           .HasMaxLength(500);

            builder.HasMany(c => c.CreditCardProperties)
               .WithOne(c => c.CreditCardValidation)
               .HasForeignKey(cc => cc.CreditCardValidationId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}