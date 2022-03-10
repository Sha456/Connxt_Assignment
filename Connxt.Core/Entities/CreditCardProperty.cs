namespace Connxt.Core.Entities
{
    public class CreditCardProperty : Entity
    {
        public string? CardBeginsWithDigit { get; set; }
        public int CreditCardValidationId { get; set; }

        public CreditCardValidation? CreditCardValidation { get; set; }
    }
}