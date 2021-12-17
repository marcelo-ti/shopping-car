using System;
using System.Collections.Generic;

namespace Klir.TechChallenge.Web.Api.Adapter.In.Controllers.RequestsResponses
{
    public class Order
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<ShoppingItem> ShoppingItems { get; set; }
    }
}