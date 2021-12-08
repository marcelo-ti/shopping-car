using System.Collections.Generic;
using Klir.TechChallenge.Web.Api.Application.Domain;
using Klir.TechChallenge.Web.Api.Application.Ports.Out;

namespace Klir.TechChallenge.Web.Api.Adapter.Out.Persistence
{
    public class ProductQueryAdapter : ILoadProduct
    {
        private readonly ProductRepository _productRepository;

        public ProductQueryAdapter(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> LoadProducts()
        {
            return _productRepository.GetProducts();
        }
    }
}