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
            OrderDetails order = GetById(id);
            order.IsDeleted = true;
            context.SaveChanges();
        }

        public List<OrderDetails> GetAll()
        {
            return context.OrderDetails.Where(o=>o.IsDeleted==false).ToList();
        }
        public List<OrderDetails> GetAllInclude()
        {
            return context.OrderDetails.Include(o => o.OrderItems).Include(x => x.OrderStatus).Include(x => x.PaymentMethod).Include(o => o.Customer).Where(o => o.IsDeleted == false).OrderByDescending(e => e.OrderDate).ToList();
        }

        public List<OrderDetails> GetAllByCustomerId(int userid)
        {
            return context.OrderDetails.Include(x=>x.OrderStatus).Include(x=>x.PaymentMethod).Include(o => o.OrderItems).Where(i => i.CustomerId == userid && i.IsDeleted == false).ToList();
        }

        public List<OrderDetails> GetAllByOrderStatusId(int statusid)
        {
            return context.OrderDetails.Where(i => i.OrderStatusId == statusid).Where(o => o.IsDeleted == false).ToList();
        }

       

        public OrderDetails GetById(int id)
        {
            return context.OrderDetails.Include(o => o.OrderItems).ThenInclude(p=>p.ProductItem).Include(x => x.OrderStatus).Include(x => x.PaymentMethod).Include(o => o.Customer).Include(a => a.Address).ThenInclude(c => c.Country).OrderByDescending(e => e.OrderDate).Where(o => o.IsDeleted == false).FirstOrDefault(i => i.Id == id);
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
        public void SaveChanges()
        { 
            context.SaveChanges();
        }
    }
}
