using Klir.TechChallenge.Web.Api.Application.Domain.Enums;
using Klir.TechChallenge.Web.Api.Application.Ports.In.Calculators;

namespace Klir.TechChallenge.Web.Api.Adapter.In.Calculators
{
    public class EngineCalculator : IEngineCalculator
    {
        public ICalculator GetCalculator(Promotion? promotion)
        {
            return promotion switch
            {
                Promotion.Buy1Get1Free => new Buy1Get1FreeCalculator(),
                Promotion.Buy3For10Euro => new Buy3For10EuroCalculator(),
                _ => new RegularCalculator()
            };
        }
    }
}