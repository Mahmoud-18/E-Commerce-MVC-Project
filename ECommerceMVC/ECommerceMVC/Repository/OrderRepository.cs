using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EcommerceDbContext context;

        public OrderRepository(EcommerceDbContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetails> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<OrderDetails> GetAllByCustomerId()
        {
            throw new NotImplementedException();
        }

        public List<OrderDetails> GetAllByOrderStatusId()
        {
            throw new NotImplementedException();
        }

        public OrderDetails GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(OrderDetails newOrder)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, OrderDetails order)
        {
            throw new NotImplementedException();
        }
    }
}
