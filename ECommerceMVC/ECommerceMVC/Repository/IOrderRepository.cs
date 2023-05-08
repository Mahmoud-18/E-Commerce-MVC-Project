using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IOrderRepository
    {
        List<OrderDetails> GetAll();

        List<OrderDetails> GetAllInclude();
        List<OrderDetails> GetAllByCustomerId(int userid);
        List<OrderDetails> GetAllByOrderStatusId(int statusid);
        OrderDetails GetById(int id);
        void Insert(OrderDetails newOrder);
        void Update(int id, OrderDetails order);
        void Delete(int id);
    }
}
