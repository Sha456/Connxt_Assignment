using Connxt.Core.Entities;
using Connxt.Core.Repository;
using Connxt.Core.Validation;
using Connxt.Infrastructure.Data;
using Connxt.Infrastructure.Repository.Base;

namespace Connxt.Infrastructure.Repository
{
    public class CreditCardValidationRepository : Repository<CreditCardValidation>, ICreditCardValidationRepository
    {
        public CreditCardValidationRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }

        public CreditCardValidation GetCreditCardValidationConfigBy(string? cardNumber)
        {
            return  _dbContext.CreditCardProperties
                .Where(c => cardNumber.StartsWith(c.CardBeginsWithDigit ?? ""))
                .Select(c => c.CreditCardValidation)
                .FirstOrDefault() ?? new CreditCardValidation();
        }

        public bool PerformCreditCardValidation(string cardNumber, CreditCardValidation creditCardValidation)
        {
            var validateLength = new CardLengthValidationManager();
            var luhnAlgorithm = new LuhnAlgorithmManager();

            validateLength.SetNextValidation(luhnAlgorithm);

            var cardValidation = new ValidationRecord(cardNumber, creditCardValidation);
            return  validateLength.ApproveRequest(cardValidation); 
        }

        public async Task<bool> SaveCreditCardValidationConfig(CreditCardValidation creditCardValidation)
        {
            await _dbContext.AddAsync(creditCardValidation);
            Int32 rowCount = await _dbContext.SaveChangesAsync();
            return (rowCount > 0);
        }
    }
}