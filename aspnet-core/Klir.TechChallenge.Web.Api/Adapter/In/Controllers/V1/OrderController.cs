using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Klir.TechChallenge.Web.Api.Adapter.In.Controllers.RequestsResponses;
using Klir.TechChallenge.Web.Api.Application.Domain.Enums;
using Klir.TechChallenge.Web.Api.Application.Ports.In.Calculators;
using Klir.TechChallenge.Web.Api.Application.Ports.In.Queries;
using Klir.TechChallenge.Web.Api.Application.Ports.Out;
using Klir.TechChallenge.Web.Api.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Klir.TechChallenge.Web.Api.Adapter.In.Controllers.V1
{
    [ApiVersion("1"),
     ApiController,
     Produces("application/json"),
     Route("api/v{version:apiVersion}/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IGetProductQuery _getProductQuery;
        private readonly IGetOrderQuery _getOrderQuery;
        private readonly ISaveNewOrderPort _saveNewOrderPort;
        private readonly IEngineCalculator _engineCalculator;

        public OrderController(
            IGetProductQuery getProductQuery,
            IGetOrderQuery getOrderQuery,
            ISaveNewOrderPort saveNewOrderPort,
            IEngineCalculator engineCalculator)
        {
            _getProductQuery = getProductQuery;
            _getOrderQuery = getOrderQuery;
            _saveNewOrderPort = saveNewOrderPort;
            _engineCalculator = engineCalculator;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _getOrderQuery
                .GetOrders()
                .Select(MapOrder);
        }

        [HttpGet("{id}")]
        public Order GetById(string id)
        {
            return MapOrder(_getOrderQuery.GetById(id));
        }

        [HttpPost]
        public IActionResult Add([Required] Order order)
        {
            var shoppingItems = order.ShoppingItems.Select(
                shoppingItem =>
                {
                    var product = _getProductQuery.GetById(shoppingItem.Product.Id);

                    var promotion =
                        EnumExtensions.GetValueFromDescription<Promotion>(shoppingItem.Product.Promotion);

                    var (price, promotionApplied) = _engineCalculator.GetCalculator(promotion)
                        .Calculate(shoppingItem.Quantity, product.Price);

                    return new Application.Domain.ShoppingItem(shoppingItem.Id,
                        shoppingItem.Quantity, price,
                        new Application.Domain.Product
                        (
                            shoppingItem.Product.Id,
                            shoppingItem.Product.Name,
                            shoppingItem.Product.Price,
                            promotion
                        ),
                        promotionApplied);
                }
            ).ToList();

            _saveNewOrderPort.Save(new Application.Domain.Order(order.Id, order.Date, shoppingItems.Sum(x => x.Price),
                shoppingItems));
            return Ok(order);
        }

        private static Order MapOrder(Application.Domain.Order order) => new Order
        {
            Id = order.Id,
            Date = order.Date,
            Total = order.Total,
            ShoppingItems = order.ShoppingItems.Select(shoppingItem => new ShoppingItem
            {
                Id = shoppingItem.Id,
                Price = shoppingItem.Price,
                Quantity = shoppingItem.Quantity,
                PromotionApplied = shoppingItem.PromotionApplied,
                Product = new Product
                {
                    Id = shoppingItem.Product.Id,
                    Name = shoppingItem.Product.Name,
                    Price = shoppingItem.Product.Price,
                    Promotion = shoppingItem.Product.Promotion.GetDescription()
                }
            })
        };
    }
}