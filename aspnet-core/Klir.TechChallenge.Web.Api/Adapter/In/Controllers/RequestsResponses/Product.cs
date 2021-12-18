using System.Diagnostics.CodeAnalysis;

namespace Klir.TechChallenge.Web.Api.Adapter.In.Controllers.RequestsResponses
{
    [ExcludeFromCodeCoverage]
    public class Product
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Promotion { get; set; }
    }
}