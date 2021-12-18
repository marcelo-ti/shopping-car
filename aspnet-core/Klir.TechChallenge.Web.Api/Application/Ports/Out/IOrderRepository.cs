using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Application.Domain;

namespace Klir.TechChallenge.Web.Api.Application.Ports.Out
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetById(string id);
        void Save(Order order);
    }
}