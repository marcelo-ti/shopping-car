using Klir.TechChallenge.Web.Api.Application.Ports.In.Calculators;

namespace Klir.TechChallenge.Web.Api.Adapter.In.Calculators
{
    public class Buy1Get1FreeCalculator : ICalculator
    {
        private const uint Multiple = 2;

        public (decimal price, bool promotionApplied) Calculate(uint quantity, decimal price)
        {
            if (quantity <= 1)
                return (price * quantity, false);

            uint totalProductsForFree;
            if (quantity % Multiple == 0)
            {
                totalProductsForFree = quantity / Multiple;
                return (price * (quantity - totalProductsForFree), true);
            }

            totalProductsForFree = quantity / Multiple;
            return (price * (quantity - totalProductsForFree), true);
        }
    }
}