using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IOrderItemRepository
    {
        List<OrderItems> GetAll();
        List<OrderItems> GetAllByOrderId();
        OrderItems GetById(int id);
        void Insert(OrderItems newOrderItem);
        void Update(int id, OrderItems orderItem);
        void Delete(int id);
    }
}
