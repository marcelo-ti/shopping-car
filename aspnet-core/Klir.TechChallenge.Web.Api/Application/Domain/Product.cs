using Klir.TechChallenge.Web.Api.Application.Domain.Enums;

namespace Klir.TechChallenge.Web.Api.Application.Domain
{
    public class Product
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Promotion? Promotion { get; set; }
    }
}