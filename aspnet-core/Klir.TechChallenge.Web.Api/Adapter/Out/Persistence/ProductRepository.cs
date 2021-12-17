using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Application.Domain;
using Klir.TechChallenge.Web.Api.Application.Domain.Enums;

namespace Klir.TechChallenge.Web.Api.Adapter.Out.Persistence
{
    public class ProductRepository
    {
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product(1, "Product A", 20, Promotion.Buy1Get1Free),
                new Product(2, "Product B", 4, Promotion.Buy3For10Euro),
                new Product(3, "Product C", 2, null),
                new Product(4, "Product D", 4, Promotion.Buy3For10Euro)
            };
        }
    }
}