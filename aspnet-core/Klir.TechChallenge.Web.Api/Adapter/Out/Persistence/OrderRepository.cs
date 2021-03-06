using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Klir.TechChallenge.Web.Api.Application.Domain;
using Klir.TechChallenge.Web.Api.Application.Ports.Out;

namespace Klir.TechChallenge.Web.Api.Adapter.Out.Persistence
{
    [ExcludeFromCodeCoverage]
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders;

        public OrderRepository()
        {
            _orders = new List<Order>();
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orders;
        }

        public Order GetById(string id)
        {
            return _orders.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Order order)
        {
            _orders.Add(order);
        }
    }
}