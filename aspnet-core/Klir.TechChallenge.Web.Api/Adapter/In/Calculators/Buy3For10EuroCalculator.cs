using Klir.TechChallenge.Web.Api.Application.Ports.In.Calculators;

namespace Klir.TechChallenge.Web.Api.Adapter.In.Calculators
{
    public class Buy3For10EuroCalculator : ICalculator
    {
        private const uint Multiple = 3;

        public (decimal price, bool promotionApplied) Calculate(uint quantity, decimal price)
        {
            if (quantity < Multiple)
                return (price * quantity, false);

            uint totalOf3For1;
            if (quantity % Multiple == 0)
            {
                totalOf3For1 = quantity / Multiple;
                return (10 * totalOf3For1, true);
            }

            totalOf3For1 = quantity / Multiple;
            var priceWithPromotionApplied = totalOf3For1 * 10;
            var quantityWithoutPromotion = quantity - (totalOf3For1 * Multiple);
            var difference = quantityWithoutPromotion * price;

            return (priceWithPromotionApplied + difference, true);
        }
    }
}