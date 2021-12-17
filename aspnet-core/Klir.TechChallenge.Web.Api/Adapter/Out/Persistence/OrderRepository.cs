using System.Collections.Generic;
using System.Linq;
using Klir.TechChallenge.Web.Api.Application.Domain;

namespace Klir.TechChallenge.Web.Api.Adapter.Out.Persistence
{
    public class OrderRepository
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

        public void SaveOrder(Order order)
        {
            _orders.Add(order);
        }
    }
}