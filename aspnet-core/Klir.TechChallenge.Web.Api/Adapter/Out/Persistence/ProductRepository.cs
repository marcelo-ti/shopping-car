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
                new Product {Id = 1, Name = "Product A", Price = 20, Promotion = Promotion.Buy1Get1Free},
                new Product {Id = 2, Name = "Product B", Price = 4, Promotion = Promotion.Buy3For10Euro},
                new Product {Id = 3, Name = "Product C", Price = 2},
                new Product {Id = 4, Name = "Product D", Price = 4, Promotion = Promotion.Buy3For10Euro}
            };
        }
    }
}