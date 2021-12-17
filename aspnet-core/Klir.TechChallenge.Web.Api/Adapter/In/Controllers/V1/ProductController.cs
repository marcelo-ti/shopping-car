using System.Collections.Generic;
using System.Linq;
using Klir.TechChallenge.Web.Api.Adapter.In.Controllers.RequestsResponses;
using Klir.TechChallenge.Web.Api.Application.Ports.In.Queries;
using Klir.TechChallenge.Web.Api.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Klir.TechChallenge.Web.Api.Adapter.In.Controllers.V1
{
    [ApiVersion("1"),
     ApiController,
     Produces("application/json"),
     Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IGetProductQuery _getProductQuery;

        public ProductController(IGetProductQuery getProductQuery)
        {
            _getProductQuery = getProductQuery;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _getProductQuery
                .GetProducts()
                .Select(product => new Product
                {
                    Id = product.Id, Name = product.Name, Price = product.Price,
                    Promotion = product.Promotion.GetDescription()
                });
        }
    }
}