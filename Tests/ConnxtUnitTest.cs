using Connxt.Core.Entities;
using Connxt.Core.Repository;
using Moq;
using Xunit;

namespace Tests
{
    public class ConnxtUnitTest
    {
        [Fact]
        public void WhenCreditCardIsSupplied_ThenPresentConfiguration()
        {
            var creditCardNumber = "4111111111111111";
            var cardValidations = new CreditCardValidation
            {
                CardName = "VISA"
            };
            var mockValidation = new Mock<ICreditCardValidationRepository>();
            mockValidation.Setup(x => x.GetCreditCardValidationConfigBy(creditCardNumber)).Returns(cardValidations);
            Assert.Equal("VISA", mockValidation.Object.GetCreditCardValidationConfigBy(creditCardNumber).CardName);
        }

        [Fact]
        public void WhenCreditCardIsSupplied_ThenValidCardStatus()
        {
            var creditCardNumber = "4111111111111111";

            var cardValidations = new CreditCardValidation
            {
                CardName = "VISA",
                CardValidationConfiguration = "{\"CardNumberLength\":[16],\"ValidateLuhnAlgorithm\":true}"
            };
            var mockValidation = new Mock<ICreditCardValidationRepository>();
            mockValidation.Setup(x => x.PerformCreditCardValidation(creditCardNumber, cardValidations)).Returns(true);
            Assert.True(mockValidation.Object.PerformCreditCardValidation(creditCardNumber, cardValidations));
        }
    }
}