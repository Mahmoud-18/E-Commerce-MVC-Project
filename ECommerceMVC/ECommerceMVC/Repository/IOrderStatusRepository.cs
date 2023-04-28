using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IOrderStatusRepository
    {
        List<OrderStatus> GetAll();
        OrderStatus GetById(int id);
        void Insert(OrderStatus newOrderStatus);
        void Update(int id, OrderStatus orderStatus);
        void Delete(int id);
    }
}
