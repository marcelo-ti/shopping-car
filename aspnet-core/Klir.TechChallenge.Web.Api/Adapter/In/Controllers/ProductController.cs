using System.Collections.Generic;
using System.Linq;
using Klir.TechChallenge.Web.Api.Application.Domain;
using Klir.TechChallenge.Web.Api.Application.Ports.In.Queries;
using Klir.TechChallenge.Web.Api.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Klir.TechChallenge.Web.Api.Adapter.In.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IGetProductQuery _getProductQuery;

        public ProductController(IGetProductQuery getProductQuery)
        {
            _getProductQuery = getProductQuery;
        }

        [HttpGet]
        public IEnumerable<ProductView> Get()
        {
            return _getProductQuery
                .GetProducts()
                .Select(product => new ProductView
                {
                    Id = product.Id, Name = product.Name, Price = product.Price,
                    Promotion = product.Promotion.GetDescription()
                });
        }
    }
}