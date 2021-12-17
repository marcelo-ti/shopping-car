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

            uint totalProductsForFree;
            if (quantity % 3 == Multiple)
            {
                totalProductsForFree = quantity / Multiple;
                return (price * (quantity - totalProductsForFree), true);
            }

            totalProductsForFree = quantity / Multiple;
            return (price * (quantity - totalProductsForFree), true);
        }
    }
}