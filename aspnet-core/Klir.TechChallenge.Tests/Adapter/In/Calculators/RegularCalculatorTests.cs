using Klir.TechChallenge.Web.Api.Adapter.In.Calculators;
using Xunit;

namespace Klir.TechChallenge.Tests.Adapter.In.Calculators
{
    public class RegularCalculatorTests
    {
        private readonly RegularCalculator _regularCalculator;

        public RegularCalculatorTests()
        {
            _regularCalculator = new RegularCalculator();
        }

        [Fact(DisplayName = "Regular Price Calculation")]
        public void RegularPriceCalculation()
        {
            // Arrange & Act
            var (price, promotionApplied) = _regularCalculator.Calculate(10, 500);

            // Assert
            Assert.Equal(5000, price);
            Assert.False(promotionApplied);
        }
    }
}