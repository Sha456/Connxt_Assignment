using Connxt.Core.Entities;
using Connxt.Core.Repository.Base;

namespace Connxt.Core.Repository
{
    public interface ICreditCardValidationRepository : IReporsitory<CreditCardValidation>
    {
        Task<bool> SaveCreditCardValidationConfig(CreditCardValidation creditCardValidation);
        CreditCardValidation GetCreditCardValidationConfigBy(string cardNumber);
        bool PerformCreditCardValidation(string cardNumber, CreditCardValidation creditCardValidation);
    }
}