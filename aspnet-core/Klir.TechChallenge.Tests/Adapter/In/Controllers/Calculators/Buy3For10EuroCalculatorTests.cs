using Klir.TechChallenge.Web.Api.Adapter.In.Calculators;
using Xunit;

namespace Klir.TechChallenge.Tests.Adapter.In.Controllers.Calculators
{
    public class Buy3For10EuroCalculatorTests
    {
        private readonly Buy3For10EuroCalculator _buy3For10EuroCalculator;

        public Buy3For10EuroCalculatorTests()
        {
            _buy3For10EuroCalculator = new Buy3For10EuroCalculator();
        }

        [Theory(DisplayName = "Buy 3 For 10 Euro Price Calculation when quantity is less than multiple (3)")]
        [InlineData(0, 4, 0)]
        [InlineData(1, 4, 4)]
        [InlineData(2, 4, 8)]
        public void Buy3For10EuroPriceCalculationWhenQuantityIsLessThanMultiple(uint quantity, decimal productPrice, decimal expected)
        {
            // Arrange & Act
            var (price, promotionApplied) = _buy3For10EuroCalculator.Calculate(quantity, productPrice);

            // Assert
            Assert.Equal(expected, price);
            Assert.False(promotionApplied);
        }

        [Theory(DisplayName = "Buy 3 For 10 Euro Price Calculation when quantity is multiple of 3")]
        [InlineData(3, 4, 10)]
        [InlineData(6, 4, 20)]
        [InlineData(9, 4, 30)]
        public void Buy3For10EuroPriceCalculationWhenQuantityIsMultipleOf3(uint quantity, decimal productPrice, decimal expected)
        {
            // Arrange & Act
            var (price, promotionApplied) = _buy3For10EuroCalculator.Calculate(quantity, productPrice);

            // Assert
            Assert.Equal(expected, price);
            Assert.True(promotionApplied);
        }

        [Theory(DisplayName = "Buy 3 For 10 Euro Price Calculation when quantity is bigger than multiple (3) but isn't multiple of 3")]
        [InlineData(4, 4, 14)]
        [InlineData(5, 4, 18)]
        [InlineData(7, 4, 24)]
        [InlineData(8, 4, 28)]
        public void Buy3For10EuroPriceCalculationWhenQuantityIsBiggerThanMultiple3ButIsNotMultipleOf3(uint quantity, decimal productPrice, decimal expected)
        {
            // Arrange & Act
            var (price, promotionApplied) = _buy3For10EuroCalculator.Calculate(quantity, productPrice);

            // Assert
            Assert.Equal(expected, price);
            Assert.True(promotionApplied);
        }
    }
}