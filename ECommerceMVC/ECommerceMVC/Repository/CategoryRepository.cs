﻿using ECommerceMVC.Context;
using ECommerceMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
            Category category = GetById(id);
            category.IsDeleted = true;
            category.DeletedAtUtc = DateTime.UtcNow;
            
            //context.Category.Remove(category);
            context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return context.Category.Include("ParentCategory").Where(i => i.IsDeleted == false).ToList();
        }       
        public Category GetById(int id)
        {
            return context.Category.Include("ParentCategory").FirstOrDefault(i => i.Id == id);           
        }
        public List<Category> GetByParentCategoryId(int id)
        {
            return context.Category.Where(i => i.ParentCategoryId == id && i.IsDeleted == false).ToList();
        }

        public void Insert(Category newCategory)
        {
            context.Category.Add(newCategory);
            context.SaveChanges();
        }

        public void Update(int id, Category category)
        {
            context.Update(category);
            context.SaveChanges();
        }
    }
}
