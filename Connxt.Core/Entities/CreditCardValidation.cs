using Connxt.Core.Entities.Interface;

namespace Connxt.Core.Entities
{
    public class CreditCardValidation : Entity, IAuditable
    {
        public string? CardName { get; set; }
        public string? CardValidationConfiguration { get; set; }

        public ICollection<CreditCardProperty>? CreditCardProperties { get; set; }
    }
}