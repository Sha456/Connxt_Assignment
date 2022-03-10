using Connxt.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connxt.Core.EntityConfiguration
{
    public class CreditCardPropertyEntityConfiguration : IEntityTypeConfiguration<CreditCardProperty>
    {
        public void Configure(EntityTypeBuilder<CreditCardProperty> builder)
        {
            builder.ToTable("CreditCardProperties");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CardBeginsWithDigit)
                   .IsRequired(true);
        }
    }
}