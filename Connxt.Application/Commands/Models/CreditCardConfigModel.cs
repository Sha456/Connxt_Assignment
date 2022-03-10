namespace Connxt.Application.Commands.Models
{
    public class CreditCardConfigModel
    {
        public int[]? CardNumberLength { get; set; }
        public bool ValidateLuhnAlgorithm { get; set; }
    }
}