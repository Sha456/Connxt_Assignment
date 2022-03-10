using Connxt.Core.Entities;

namespace Connxt.Core.Validation
{
    public record ValidationRecord(string cardNumber, CreditCardValidation creditCardValidation);
}