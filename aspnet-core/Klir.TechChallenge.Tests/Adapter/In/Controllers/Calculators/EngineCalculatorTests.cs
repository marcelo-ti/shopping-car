using Klir.TechChallenge.Web.Api.Adapter.In.Calculators;
using Klir.TechChallenge.Web.Api.Application.Domain.Enums;
using Xunit;

namespace Klir.TechChallenge.Tests.Adapter.In.Controllers.Calculators
{
    public class EngineCalculatorTests
    {
        private readonly EngineCalculator _engineCalculator;

        public EngineCalculatorTests()
        {
            _engineCalculator = new EngineCalculator();
        }

        [Fact(DisplayName = "Get Buy 1 Get 1 Free Calculator")]
        public void GetBuy1Get1FreeCalculator()
        {
            // Arrange & Act
            var calculator = _engineCalculator.GetCalculator(Promotion.Buy1Get1Free);

            // Assert
            Assert.IsType<Buy1Get1FreeCalculator>(calculator);
        }

        [Fact(DisplayName = "Get Buy 3 For 10 Euro Calculator")]
        public void GetBuy3For10EuroCalculator()
        {
            // Arrange & Act
            var calculator = _engineCalculator.GetCalculator(Promotion.Buy3For10Euro);

            // Assert
            Assert.IsType<Buy3For10EuroCalculator>(calculator);
        }

        [Theory(DisplayName = "Get Regular Calculator")]
        [InlineData(Promotion.UnmappedPromotion)]
        [InlineData(null)]
        public void GetRegularCalculator(Promotion? promotion)
        {
            // Arrange & Act
            var calculator = _engineCalculator.GetCalculator(promotion);

            // Assert
            Assert.IsType<RegularCalculator>(calculator);
        }
    }
}