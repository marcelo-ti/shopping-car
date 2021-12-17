using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Application.Domain;

namespace Klir.TechChallenge.Web.Api.Application.Ports.Out
{
    public interface ILoadOrder
    {
        IEnumerable<Order> LoadOrder();
        Order GetById(string id);
    }
}