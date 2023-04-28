using ECommerceMVC.Models;

namespace ECommerceMVC.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        List<Category> GetByParentCategoryId(int id);
        Category GetById(int id);
        void Insert(Category newCategory);
        void Update(int id, Category category);
        void Delete(int id);
    }
}
