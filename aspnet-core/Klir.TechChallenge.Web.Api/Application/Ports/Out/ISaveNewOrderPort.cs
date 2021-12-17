using Klir.TechChallenge.Web.Api.Application.Domain;

namespace Klir.TechChallenge.Web.Api.Application.Ports.Out
{
    public interface ISaveNewOrderPort
    {
        void Save(Order order);
    }
}