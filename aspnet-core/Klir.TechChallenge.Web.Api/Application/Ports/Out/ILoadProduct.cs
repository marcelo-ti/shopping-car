using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Application.Domain;

namespace Klir.TechChallenge.Web.Api.Application.Ports.Out
{
    public interface ILoadProduct
    {
        IEnumerable<Product> LoadProducts();
    }
}