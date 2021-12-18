using System.Diagnostics.CodeAnalysis;

namespace Klir.TechChallenge.Web.Api.Adapter.In.Controllers.RequestsResponses
{
    [ExcludeFromCodeCoverage]
    public class ShoppingItemCalculated
    {
        public decimal Price { get; set; }
        public bool PromotionApplied { get; set; }
    }
}