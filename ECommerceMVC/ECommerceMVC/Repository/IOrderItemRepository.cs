using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IOrderItemRepository
    {
        List<OrderItems> GetAll();
        List<OrderItems> GetAllByOrderId(int orderid);
        OrderItems GetById(int id);
        void Insert(OrderItems newOrderItem);
        void InsertRange(List<OrderItems> newOrderItems);
        void Update(int id, OrderItems orderItem);
        void Delete(int id);
    }
}
