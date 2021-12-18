using System;
using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Adapter.Out.Persistence;
using Klir.TechChallenge.Web.Api.Application.Domain;
using Klir.TechChallenge.Web.Api.Application.Ports.Out;
using Klir.TechChallenge.Web.Api.Application.Services;
using NSubstitute;
using Xunit;

namespace Klir.TechChallenge.Tests.Adapter.Out.Persistence
{
    public class OrderPersistenceAdapterTests
    {
        private readonly IOrderRepository _repository;
        private readonly OrderPersistenceAdapter _adapter;

        public OrderPersistenceAdapterTests()
        {
            _repository = Substitute.For<IOrderRepository>();
            _adapter = new OrderPersistenceAdapter(_repository);
        }

        [Fact(DisplayName = "Save should call order repository")]
        public void SaveOrderShouldCallOrderRepository()
        {
            // Arrange
            var order = new Order("id", new DateTime(), 0, null);

            // Act
            _adapter.Save(order);

            // Assert
            _repository.Received(1).Save(order);
        }
    }
}