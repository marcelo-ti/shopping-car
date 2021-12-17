using Klir.TechChallenge.Web.Api.Application.Domain.Enums;

namespace Klir.TechChallenge.Web.Api.Application.Ports.In.Calculators
{
    public interface ICalculator
    {
        (decimal price, bool promotionApplied) Calculate(uint quantity, decimal price);
    }
}