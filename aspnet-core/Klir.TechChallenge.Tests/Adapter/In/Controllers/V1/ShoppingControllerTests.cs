using Klir.TechChallenge.Web.Api.Adapter.In.Calculators;
using Klir.TechChallenge.Web.Api.Adapter.In.Controllers.V1;
using Klir.TechChallenge.Web.Api.Application.Domain;
using Klir.TechChallenge.Web.Api.Application.Ports.In.Calculators;
using Klir.TechChallenge.Web.Api.Application.Ports.In.Queries;
using NSubstitute;
using Xunit;

namespace Klir.TechChallenge.Tests.Adapter.In.Controllers.V1
{
    public class ShoppingControllerTests
    {
        private readonly IGetProductQuery _getProductQuery;
        private readonly IEngineCalculator _engineCalculator;
        private readonly ShoppingController _controller;

        public ShoppingControllerTests()
        {
            _getProductQuery = Substitute.For<IGetProductQuery>();
            _engineCalculator = Substitute.For<IEngineCalculator>();
            _controller = new ShoppingController(_getProductQuery, _engineCalculator);
        }

        [Fact(DisplayName = "Calculate Product price")]
        public void CalculateProductPrice()
        {
            // Arrange
            const uint id = 1;
            _getProductQuery.GetById(id).Returns(new Product(id, "product", 0, null));
            _engineCalculator.GetCalculator(null).Returns(new RegularCalculator());

            // Act
            var result = _controller.Calculate(id, 1);

            // Assert
            Assert.Equal(0, result.Price);
            Assert.False(result.PromotionApplied);
            _getProductQuery.Received(1).GetById(1);
            _engineCalculator.Received(1).GetCalculator(null);
        }
    }
}