using Connxt.Application.Commands;
using Connxt.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Connxt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IMediator _mediator;

        public PaymentController(ILogger<PaymentController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("validatecc")]
        [ProducesResponseType(typeof(CreditCardValidationResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> ValidateCreditCard([FromBody] CreditCardValidationCommand creditCardValidationCommand)
        {
            try
            {
                var result = await _mediator.Send(creditCardValidationCommand);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"validatecc/ {0}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("addcreditcard")]
        [ProducesResponseType(typeof(AddCreditCardResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddCreditCard([FromBody] AddCreditCardCommand addCreditCardCommand)
        {
            try
            {
                var result = await _mediator.Send(addCreditCardCommand);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"addcreditcard/ {0}", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}