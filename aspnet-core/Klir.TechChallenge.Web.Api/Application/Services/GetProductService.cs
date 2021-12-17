using System.Collections.Generic;
using System.Linq;
using Klir.TechChallenge.Web.Api.Application.Domain;
using Klir.TechChallenge.Web.Api.Application.Ports.In.Queries;
using Klir.TechChallenge.Web.Api.Application.Ports.Out;

namespace Klir.TechChallenge.Web.Api.Application.Services
{
    public class GetProductService : IGetProductQuery
    {
        private readonly ILoadProduct _loadProduct;

        public GetProductService(ILoadProduct loadProduct)
        {
            _loadProduct = loadProduct;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _loadProduct.LoadProducts();
        }

        public Product GetById(uint productId)
        {
            return _loadProduct.LoadProducts().FirstOrDefault(product => product.Id == productId);
        }
    }
}