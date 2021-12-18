using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Adapter.In.Controllers.V1;
using Klir.TechChallenge.Web.Api.Application.Domain;
using Klir.TechChallenge.Web.Api.Application.Ports.In.Queries;
using NSubstitute;
using Xunit;

namespace Klir.TechChallenge.Tests.Adapter.In.Controllers.V1
{
    public class ProductControllerTests
    {
        private readonly IGetProductQuery _getProductQuery;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _getProductQuery = Substitute.For<IGetProductQuery>();
            _controller = new ProductController(_getProductQuery);
        }

        [Fact(DisplayName = "Get Products")]
        public void GetProducts()
        {
            // Arrange
            _getProductQuery.GetProducts().Returns(new List<Product>
            {
                new Product(1, "product", 0, null)
            });

            // Act
            var result = _controller.Get();

            // Assert
            Assert.NotNull(result);
            _getProductQuery.Received(1).GetProducts();
        }
    }
}