using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Application.Domain;
using Klir.TechChallenge.Web.Api.Application.Ports.Out;

namespace Klir.TechChallenge.Web.Api.Adapter.Out.Persistence
{
    public class OrderQueryAdapter : ILoadOrder
    {
        private readonly OrderRepository _orderRepository;

        public OrderQueryAdapter(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> LoadOrder()
        {
            return _orderRepository.GetOrders();
        }

        public Order GetById(string id)
        {
            return _orderRepository.GetById(id);
        }
    }
}