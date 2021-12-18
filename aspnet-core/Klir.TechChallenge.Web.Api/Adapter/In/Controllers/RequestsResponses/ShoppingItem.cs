using System.Diagnostics.CodeAnalysis;

namespace Klir.TechChallenge.Web.Api.Adapter.In.Controllers.RequestsResponses
{
    [ExcludeFromCodeCoverage]
    public class ShoppingItem
    {
        public string Id { get; set; }
        public uint Quantity { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
        public bool PromotionApplied { get; set; }
    }
}