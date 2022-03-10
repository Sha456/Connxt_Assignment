using Connxt.Application.Commands;
using Connxt.Application.Mappers;
using Connxt.Application.Responses;
using Connxt.Core.Entities;
using Connxt.Core.Repository;
using MediatR;

namespace Connxt.Application.Handlers
{
    public class PaymentHandler : IRequestHandler<CreditCardValidationCommand, CreditCardValidationResponse>,
        IRequestHandler<AddCreditCardCommand, AddCreditCardResponse> 
    {
        private readonly ICreditCardValidationRepository _creditCardValidationRepository;

        public PaymentHandler(ICreditCardValidationRepository creditCardValidationRepository)
        {
            _creditCardValidationRepository = creditCardValidationRepository;
        }

        public Task<CreditCardValidationResponse> Handle(CreditCardValidationCommand request, CancellationToken cancellationToken)
        {
            if (request.CreditCardNumber == null) return Task.FromResult(new CreditCardValidationResponse()
            {
                CardName = null,
                CardNumber = null,
                ValidationStatus = false
            });

            var result = _creditCardValidationRepository.GetCreditCardValidationConfigBy(request.CreditCardNumber);

            bool isNull = result.GetType().GetProperties()
                            .All(p => p.GetValue(result) != null);

            if (isNull)
            {
                var isCCValid = _creditCardValidationRepository.PerformCreditCardValidation(request.CreditCardNumber, result);

                return Task.FromResult(new CreditCardValidationResponse()
                {
                    CardName = result.CardName,
                    CardNumber = request.CreditCardNumber,
                    ValidationStatus = isCCValid
                });
            }
            return Task.FromResult(new CreditCardValidationResponse()
            {
                CardName = null,
                CardNumber = null,
                ValidationStatus = false
            });

        }

        public async Task<AddCreditCardResponse> Handle(AddCreditCardCommand request, CancellationToken cancellationToken)
        {
            var creditCardValidation = ApplicationMapper.Mapper.Map<CreditCardValidation>(request);

            bool status = await _creditCardValidationRepository.SaveCreditCardValidationConfig(creditCardValidation);
            return new AddCreditCardResponse()
            {
                CreditCardAddedStatus = status,
            };
        }
    }
}