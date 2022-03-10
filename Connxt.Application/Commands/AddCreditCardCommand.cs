using Connxt.Application.Commands.Models;
using Connxt.Application.Responses;
using MediatR;

namespace Connxt.Application.Commands
{
    public class AddCreditCardCommand : IRequest<AddCreditCardResponse>
    {
        public string? CardName { get; set; }
        public CreditCardConfigModel? CreditCardPropertiesModel { get; set; }
        public IEnumerable<CreditCardPropertyModel>? CreditCardProperties { get; set; }

    }
}