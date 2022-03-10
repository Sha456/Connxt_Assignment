using Connxt.Core.Repository;
using Connxt.Core.Validation;

namespace Connxt.Infrastructure.Repository
{
    public class LuhnAlgorithmManager : IValidationManager
    {
        private IValidationManager _validationManager;

        public LuhnAlgorithmManager()
        {
        }

        public bool ApproveRequest(ValidationRecord validationRecord)
        {
            int[] cardInt = new int[validationRecord.cardNumber.Length];

            for(int i = 0; i < validationRecord.cardNumber.Length; i++)
            {
                cardInt[i] = (int)(validationRecord.cardNumber[i] - '0');
            }

            for (int i = cardInt.Length - 2; i >= 0; i -= 2)
            {
                int tempValue = cardInt[i];
                tempValue *= 2;
                if(tempValue > 9)
                {
                    tempValue = (tempValue % 10) + 1;
                }
                cardInt[i] = tempValue;
            }

            int total = cardInt.Sum();

            if (total % 10 == 0)
            {
               var r= _validationManager?.ApproveRequest(validationRecord) ?? true;
               return r;
            }
            return false;
        }

        public void SetNextValidation(IValidationManager validationManager)
        {
            this._validationManager = validationManager;
        }
    }
}