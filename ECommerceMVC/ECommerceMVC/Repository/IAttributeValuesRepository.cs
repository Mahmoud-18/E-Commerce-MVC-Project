using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface IAttributeValuesRepository
    {
        List<AttributeValues> GetAll();
        AttributeValues GetById(int id);
        void Insert(AttributeValues attributeValues);
        void Update(int id, AttributeValues attributeValues);
        void Delete(int id);
    }
}
