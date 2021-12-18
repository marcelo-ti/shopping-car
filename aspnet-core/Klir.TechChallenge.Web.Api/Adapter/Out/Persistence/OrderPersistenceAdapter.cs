using Klir.TechChallenge.Web.Api.Application.Domain;
using Klir.TechChallenge.Web.Api.Application.Ports.Out;

namespace Klir.TechChallenge.Web.Api.Adapter.Out.Persistence
{
    public class OrderPersistenceAdapter : ISaveNewOrderPort
    {
        private readonly IOrderRepository _orderRepository;

        public OrderPersistenceAdapter(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Save(Order order)
        {
            _orderRepository.Save(order);
        }
    }
}