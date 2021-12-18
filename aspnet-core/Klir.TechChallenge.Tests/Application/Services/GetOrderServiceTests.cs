using System;
using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Application.Domain;
using Klir.TechChallenge.Web.Api.Application.Ports.Out;
using Klir.TechChallenge.Web.Api.Application.Services;
using NSubstitute;
using Xunit;

namespace Klir.TechChallenge.Tests.Application.Services
{
    public class GetOrderServiceTests
    {
        private readonly ILoadOrder _loadOrder;
        private readonly GetOrderService _service;

        public GetOrderServiceTests()
        {
            _loadOrder = Substitute.For<ILoadOrder>();
            _service = new GetOrderService(_loadOrder);
        }

        [Fact(DisplayName = "Get Orders should call LoadOrder port")]
        public void GetOrdersShouldCallLoadOrderPort()
        {
            // Arrange
            _loadOrder.LoadOrders().Returns(new List<Order>());

            // Act
            _service.GetOrders();

            // Assert
            _loadOrder.Received(1).LoadOrders();
        }

        [Fact(DisplayName = "Get Order by id should call LoadOrder port")]
        public void GetOrderByIdShouldCallLoadOrderPort2()
        {
            // Arrange
            const string id = "id";
            _loadOrder.GetById(id).Returns(new Order(id, new DateTime(), 0, null));

            // Act
            _service.GetById(id);

            // Assert
            _loadOrder.Received(1).GetById(id);
        }
    }
}