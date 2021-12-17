using Klir.TechChallenge.Web.Api.Application.Ports.In.Calculators;

namespace Klir.TechChallenge.Web.Api.Adapter.In.Calculators
{
    public class RegularCalculator : ICalculator
    {
        public (decimal price, bool promotionApplied) Calculate(uint quantity, decimal price)
        {
            return (price * quantity, false);
        }
    }
}