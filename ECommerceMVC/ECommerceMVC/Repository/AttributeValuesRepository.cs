using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class AttributeValuesRepository : IAttributeValuesRepository
    {
        EcommerceDbContext context;

        public AttributeValuesRepository(EcommerceDbContext _context)
        {
            context = _context;
        }
        public void Delete(int id)
        {
            AttributeValues attributeValues = GetById(id);
            context.AttributeValues.Remove(attributeValues);
            context.SaveChanges();
        }

        public List<AttributeValues> GetAll()
        {
            return context.AttributeValues.ToList();
        }


        public AttributeValues GetById(int id)
        {
            return context.AttributeValues.FirstOrDefault(sh => sh.Id == id)!;
        }

        public void Insert(AttributeValues attributeValues)
        {
            context.AttributeValues.Add(attributeValues);
            context.SaveChanges();
        }

        public void Update(int id, AttributeValues attributeValues)
        {
            context.Update(attributeValues);
            context.SaveChanges();
        }

    }
}
