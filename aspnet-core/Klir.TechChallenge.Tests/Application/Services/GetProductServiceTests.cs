using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Application.Domain;
using Klir.TechChallenge.Web.Api.Application.Ports.Out;
using Klir.TechChallenge.Web.Api.Application.Services;
using NSubstitute;
using Xunit;

namespace Klir.TechChallenge.Tests.Application.Services
{
    public class GetProductServiceTests
    {
        private readonly ILoadProduct _loadProduct;
        private readonly GetProductService _service;

        public GetProductServiceTests()
        {
            _loadProduct = Substitute.For<ILoadProduct>();
            _service = new GetProductService(_loadProduct);
        }

        [Fact(DisplayName = "Get Products should call LoadProduct port")]
        public void GetProductsShouldCallLoadProductPort()
        {
            // Arrange
            _loadProduct.LoadProducts().Returns(new List<Product>());

            // Act
            _service.GetProducts();

            // Assert
            _loadProduct.Received(1).LoadProducts();
        }

        [Fact(DisplayName = "Get Product by id should call LoadProduct port")]
        public void GetProductByIdShouldCallLoadProductPort()
        {
            // Arrange
            const uint id = 1;
            _loadProduct.LoadProducts().Returns(new List<Product>(new[] {new Product(id, "product", 0, null)}));

            // Act
            var result = _service.GetById(id);

            // Assert
            Assert.NotNull(result);
            _loadProduct.Received(1).LoadProducts();
        }
    }
}