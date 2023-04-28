using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private readonly EcommerceDbContext context;

        public OrderStatusRepository(EcommerceDbContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderStatus> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderStatus GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(OrderStatus newOrderStatus)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, OrderStatus orderStatus)
        {
            throw new NotImplementedException();
        }
    }
}
