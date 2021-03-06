using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Application.Domain;

namespace Klir.TechChallenge.Web.Api.Application.Ports.Out
{
    public interface ILoadOrder
    {
        IEnumerable<Order> LoadOrders();
        Order GetById(string id);
    }
}