namespace Connxt.Application.Responses
{
    public class CreditCardValidationResponse
    {
        public string? CardName { get; set; }
        public string? CardNumber { get; set; }
        public bool ValidationStatus { get; set; }
    }
}