using System;
using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Adapter.Out.Persistence;
using Klir.TechChallenge.Web.Api.Application.Domain;
using Klir.TechChallenge.Web.Api.Application.Ports.Out;
using NSubstitute;
using Xunit;

namespace Klir.TechChallenge.Tests.Adapter.Out.Persistence
{
    public class OrderQueryAdapterTests
    {
        private readonly IOrderRepository _repository;
        private readonly OrderQueryAdapter _adapter;

        public OrderQueryAdapterTests()
        {
            _repository = Substitute.For<IOrderRepository>();
            _adapter = new OrderQueryAdapter(_repository);
        }

        [Fact(DisplayName = "Load Orders should call order repository")]
        public void LoadOrdersShouldCallOrderRepository()
        {
            // Arrange
            _repository.GetOrders().Returns(new List<Order>());

            // Act
            _adapter.LoadOrders();

            // Assert
            _repository.Received(1).GetOrders();
        }

        [Fact(DisplayName = "Get Order by id should call order repository")]
        public void GetOrderByIdShouldCallOrderRepository()
        {
            // Arrange
            const string id = "id";
            _repository.GetById(id).Returns(new Order(id, new DateTime(), 0, null));

            // Act
            _adapter.GetById(id);

            // Assert
            _repository.Received(1).GetById(id);
        }
    }
}