using Klir.TechChallenge.Web.Api.Adapter.In.Calculators;
using Xunit;

namespace Klir.TechChallenge.Tests.Adapter.In.Controllers.Calculators
{
    public class Buy1Get1FreeCalculatorTests
    {
        private readonly Buy1Get1FreeCalculator _buy1Get1FreeCalculator;

        public Buy1Get1FreeCalculatorTests()
        {
            _buy1Get1FreeCalculator = new Buy1Get1FreeCalculator();
        }

        [Theory(DisplayName = "Buy 1 Get 1 Price Calculation when quantity is less than multiple")]
        [InlineData(0, 4, 0)]
        [InlineData(1, 4, 4)]
        public void Buy1Get1PriceCalculationWhenQuantityIsLessThanMultiple(uint quantity, decimal productPrice, decimal expected)
        {
            // Arrange & Act
            var (price, promotionApplied) = _buy1Get1FreeCalculator.Calculate(quantity, productPrice);

            // Assert
            Assert.Equal(expected, price);
            Assert.False(promotionApplied);
        }

        [Theory(DisplayName = "Buy 1 Get 1 Price Price Calculation when quantity is multiple of 2")]
        [InlineData(2, 4, 4)]
        [InlineData(4, 4, 8)]
        [InlineData(6, 4, 12)]
        public void Buy1Get1PriceCalculationWhenQuantityIsMultipleOf2(uint quantity, decimal productPrice, decimal expected)
        {
            // Arrange & Act
            var (price, promotionApplied) = _buy1Get1FreeCalculator.Calculate(quantity, productPrice);

            // Assert
            Assert.Equal(expected, price);
            Assert.True(promotionApplied);
        }

        [Theory(DisplayName = "Buy 1 Get 1 Price Price Calculation when quantity is bigger than multiple but isn't multiple of 2")]
        [InlineData(3, 4, 8)]
        [InlineData(5, 4, 12)]
        [InlineData(7, 4, 16)]
        [InlineData(9, 4, 20)]
        public void Buy1Get1PriceCalculationWhenQuantityIsBiggerThanMultipleButIsNotMultipleOf2(uint quantity, decimal productPrice, decimal expected)
        {
            // Arrange & Act
            var (price, promotionApplied) = _buy1Get1FreeCalculator.Calculate(quantity, productPrice);

            // Assert
            Assert.Equal(expected, price);
            Assert.True(promotionApplied);
        }
    }
}