﻿using ECommerceMVC.Context;
using ECommerceMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ECommerceMVC.Repository
{
    public class BrandRepository : IBrandRepository
    {
        EcommerceDbContext context;

        public BrandRepository(EcommerceDbContext _context)
        {
            context = _context;
        }

        public void Delete(int id)
        {
            Brand brand = GetById(id);
            brand.IsDeleted = true;
            brand.DeletedOnUtc = DateTime.UtcNow;
            context.SaveChanges();
        }

        public List<Brand> GetAll()
        {
            return context.Brand.Where(i => i.IsDeleted == false).ToList();
        }

        public Brand GetById(int id)
        {
            return context.Brand.Include("Products").FirstOrDefault(i => i.Id == id);
        }

        public void Insert(Brand newBrand)
        {
            context.Brand.Add(newBrand);
            context.SaveChanges();
        }

        public void Update(int id, Brand brand)
        {
            context.Update(brand);
            context.SaveChanges();
        }
    }
}
