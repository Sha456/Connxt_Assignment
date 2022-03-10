using Connxt.Application.Commands.Models;
using Connxt.Core.Repository;
using Connxt.Core.Validation;
using Newtonsoft.Json;

namespace Connxt.Infrastructure.Repository
{
    public class CardLengthValidationManager : IValidationManager
    {
        private IValidationManager _validationManager;

        public CardLengthValidationManager()
        {
        }

        public bool ApproveRequest(ValidationRecord validationRecord)
        {
            var cardValidationConfig = JsonConvert.DeserializeObject<CreditCardConfigModel>(validationRecord.creditCardValidation.CardValidationConfiguration!);

            if ((cardValidationConfig.CardNumberLength).Contains(validationRecord.cardNumber.Length))
            {
                return  _validationManager?.ApproveRequest(validationRecord)?? true;
            }
            return false;
        }

        public void SetNextValidation(IValidationManager validationManager)
        {
            this._validationManager = validationManager;
        }
    }
}