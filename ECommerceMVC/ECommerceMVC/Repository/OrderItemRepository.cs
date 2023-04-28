using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly EcommerceDbContext context;

        public OrderItemRepository(EcommerceDbContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderItems> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<OrderItems> GetAllByOrderId()
        {
            throw new NotImplementedException();
        }

        public OrderItems GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(OrderItems newOrderItem)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, OrderItems orderItem)
        {
            throw new NotImplementedException();
        }
    }
}
