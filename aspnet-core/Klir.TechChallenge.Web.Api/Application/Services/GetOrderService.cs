using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Application.Domain;
using Klir.TechChallenge.Web.Api.Application.Ports.In.Queries;
using Klir.TechChallenge.Web.Api.Application.Ports.Out;

namespace Klir.TechChallenge.Web.Api.Application.Services
{
    public class GetOrderService : IGetOrderQuery
    {
        private readonly ILoadOrder _loadOrder;

        public GetOrderService(ILoadOrder loadOrder)
        {
            _loadOrder = loadOrder;
        }

        public IEnumerable<Order> GetOrder()
        {
            return _loadOrder.LoadOrder();
        }

        public Order GetById(string id)
        {
            return _loadOrder.GetById(id);
        }
    }
}