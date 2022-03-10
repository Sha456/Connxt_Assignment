using Connxt.Core.Validation;

namespace Connxt.Core.Repository
{
    public interface IValidationManager
    {
        bool ApproveRequest(ValidationRecord validationRecord);
        void SetNextValidation(IValidationManager validationManager);
    }
}