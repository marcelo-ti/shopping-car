using Klir.TechChallenge.Web.Api.Adapter.In.Controllers.RequestsResponses;
using Klir.TechChallenge.Web.Api.Application.Ports.In.Calculators;
using Klir.TechChallenge.Web.Api.Application.Ports.In.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Klir.TechChallenge.Web.Api.Adapter.In.Controllers.V1
{
    [ApiVersion("1"),
     ApiController,
     Produces("application/json"),
     Route("api/v{version:apiVersion}/[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly IGetProductQuery _getProductQuery;
        private readonly IEngineCalculator _engineCalculator;

        public ShoppingController(IGetProductQuery getProductQuery, IEngineCalculator engineCalculator)
        {
            _getProductQuery = getProductQuery;
            _engineCalculator = engineCalculator;
        }

        [HttpGet("{productId}/{quantity}")]
        public ShoppingItemCalculated Calculate(uint productId, uint quantity)
        {
            var product = _getProductQuery.GetById(productId);
            var (price, promotionApplied) =
                _engineCalculator.GetCalculator(product.Promotion).Calculate(quantity, product.Price);
            return new ShoppingItemCalculated {Price = price, PromotionApplied = promotionApplied};
        }
    }
}