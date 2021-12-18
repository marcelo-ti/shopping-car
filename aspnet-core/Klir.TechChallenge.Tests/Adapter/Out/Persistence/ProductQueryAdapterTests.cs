using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Adapter.Out.Persistence;
using Klir.TechChallenge.Web.Api.Application.Domain;
using Klir.TechChallenge.Web.Api.Application.Ports.Out;
using NSubstitute;
using Xunit;

namespace Klir.TechChallenge.Tests.Adapter.Out.Persistence
{
    public class ProductQueryAdapterTests
    {
        private readonly IProductRepository _repository;
        private readonly ProductQueryAdapter _adapter;

        public ProductQueryAdapterTests()
        {
            _repository = Substitute.For<IProductRepository>();
            _adapter = new ProductQueryAdapter(_repository);
        }

        [Fact(DisplayName = "Load Products should call product repository")]
        public void LoadProductsShouldCallProductRepository()
        {
            // Arrange
            _repository.GetProducts().Returns(new List<Product>());

            // Act
            _adapter.LoadProducts();

            // Assert
            _repository.Received(1).GetProducts();
        }
    }
}