using ECommerceMVC.Context;
using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EcommerceDbContext context;

        public CategoryRepository(EcommerceDbContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetByParentCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category newCategory)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
