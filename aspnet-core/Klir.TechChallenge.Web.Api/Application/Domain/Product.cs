using Klir.TechChallenge.Web.Api.Application.Domain.Enums;

namespace Klir.TechChallenge.Web.Api.Application.Domain
{
    public class Product
    {
        public Product(uint id, string name, decimal price, Promotion? promotion)
        {
            Id = id;
            Name = name;
            Price = price;
            Promotion = promotion;
        }

        public uint Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public Promotion? Promotion { get; }
    }
}