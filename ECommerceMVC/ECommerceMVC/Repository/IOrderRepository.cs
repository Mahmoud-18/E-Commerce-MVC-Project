using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IOrderRepository
    {
        List<OrderDetails> GetAll();
        List<OrderDetails> GetAllByCustomerId();
        List<OrderDetails> GetAllByOrderStatusId();
        OrderDetails GetById(int id);
        void Insert(OrderDetails newOrder);
        void Update(int id, OrderDetails order);
        void Delete(int id);
    }
}
