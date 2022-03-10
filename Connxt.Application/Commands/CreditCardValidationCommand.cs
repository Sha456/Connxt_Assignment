using Connxt.Application.Responses;
using MediatR;

namespace Connxt.Application.Commands
{
    public class CreditCardValidationCommand : IRequest<CreditCardValidationResponse>
    {
        public string? CreditCardNumber { get; set; }
    }
}