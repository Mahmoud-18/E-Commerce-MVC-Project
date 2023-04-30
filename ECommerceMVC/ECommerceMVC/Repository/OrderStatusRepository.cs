using ECommerceMVC.Context;
using ECommerceMVC.Models;
using Microsoft.EntityFrameworkCore;

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
            OrderStatus or = GetById(id);
            or.IsDeleted = true;
            or.DeletedOnUtc = DateTime.UtcNow;
            context.SaveChanges();
        }

        public List<OrderStatus> GetAll()
        {
            return context.OrderStatus.Where(i => i.IsDeleted == false).ToList();
        }

        public OrderStatus GetById(int id)
        {
            return context.OrderStatus.Include("Orders").FirstOrDefault(i => i.Id == id);
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
