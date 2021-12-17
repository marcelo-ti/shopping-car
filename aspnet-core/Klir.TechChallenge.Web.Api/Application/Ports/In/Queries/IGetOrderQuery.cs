using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Application.Domain;

namespace Klir.TechChallenge.Web.Api.Application.Ports.In.Queries
{
    public interface IGetOrderQuery
    {
        IEnumerable<Order> GetOrder();
        Order GetById(string id);
    }
}