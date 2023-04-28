using ECommerceMVC.Context;
using ECommerceMVC.Models;
using System.Diagnostics.Metrics;

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
            context.OrderItems.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<OrderItems> GetAll()
        {
            return context.OrderItems.ToList();
        }

        public List<OrderItems> GetAllByOrderId(int orderid)
        {
            return context.OrderItems.Where(i => i.OrderDetailsId == orderid).ToList();
        }

        public OrderItems GetById(int id)
        {
            return context.OrderItems.FirstOrDefault(i => i.Id == id);
        }

        public void Insert(OrderItems newOrderItem)
        {
            context.OrderItems.Add(newOrderItem);
            context.SaveChanges();
        }

        public void Update(int id, OrderItems orderItem)
        {
            context.Update(orderItem);
            context.SaveChanges();
        }
    }
}
