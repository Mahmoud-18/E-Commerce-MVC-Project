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
            context.OrderStatus.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<OrderStatus> GetAll()
        {
            return context.OrderStatus.ToList();
        }

        public OrderStatus GetById(int id)
        {
            return context.OrderStatus.FirstOrDefault(i => i.Id == id);
        }

        public void Insert(OrderStatus newOrderStatus)
        {
            context.OrderStatus.Add(newOrderStatus);
            context.SaveChanges();
        }

        public void Update(int id, OrderStatus orderStatus)
        {
            context.Update(orderStatus);
            context.SaveChanges();
        }
    }
}
