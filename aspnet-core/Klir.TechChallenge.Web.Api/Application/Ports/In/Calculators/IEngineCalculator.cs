using Klir.TechChallenge.Web.Api.Application.Domain.Enums;

namespace Klir.TechChallenge.Web.Api.Application.Ports.In.Calculators
{
    public interface IEngineCalculator
    {
        ICalculator GetCalculator(Promotion? promotion);
    }
}