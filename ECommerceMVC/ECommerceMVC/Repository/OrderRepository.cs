using ECommerceMVC.Context;
using ECommerceMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

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
            context.OrderDetails.Remove(GetById(id));
            context.SaveChanges();
        }

        public List<OrderDetails> GetAll()
        {
            return context.OrderDetails.ToList();
        }

        public List<OrderDetails> GetAllByCustomerId(int userid)
        {
            return context.OrderDetails.Include(x=>x.OrderStatus).Include(x=>x.PaymentMethod).Include(o => o.OrderItems).Where(i => i.CustomerId == userid).ToList();
        }

        public List<OrderDetails> GetAllByOrderStatusId(int statusid)
        {
            return context.OrderDetails.Where(i => i.OrderStatusId == statusid).ToList();
        }

        public OrderDetails GetById(int id)
        {
            return context.OrderDetails.FirstOrDefault(i => i.Id == id);
        }

        public void Insert(OrderDetails newOrder)
        {
            context.OrderDetails.Add(newOrder);
            context.SaveChanges();
        }

        public void Update(int id, OrderDetails order)
        {
            context.Update(order);           
            context.SaveChanges();
        }
    }
}
