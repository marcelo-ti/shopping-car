using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Klir.TechChallenge.Web.Api.Application.Domain
{
    [ExcludeFromCodeCoverage]
    public class Order
    {
        public Order(string id, DateTime date, decimal total, IEnumerable<ShoppingItem> shoppingItems)
        {
            Id = id;
            Date = date;
            Total = total;
            ShoppingItems = shoppingItems;
        }

        public string Id { get; }
        public DateTime Date { get; }
        public decimal Total { get; }
        public IEnumerable<ShoppingItem> ShoppingItems { get; }
    }
}