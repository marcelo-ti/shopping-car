namespace Klir.TechChallenge.Web.Api.Application.Domain
{
    public class ShoppingItem
    {
        public ShoppingItem(string id, uint quantity, decimal price, Product product, bool promotionApplied)
        {
            Id = id;
            Quantity = quantity;
            Price = price;
            Product = product;
            PromotionApplied = promotionApplied;
        }

        public string Id { get; }
        public uint Quantity { get; }
        public decimal Price { get; }
        public Product Product { get; }
        public bool PromotionApplied { get; }
    }
}