using ECommerceMVC.Models;
using ECommerceMVC.Repository;
using ECommerceMVC.Services;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class ShopController : Controller
    {
        ProductsServices ProductsServices;

        public ShopController(ProductsServices productsServices)
        {
            ProductsServices = productsServices;
        }
        public IActionResult ShowAllProducts(int? prodsCount, int pg = 1)
        {
            var products = ProductsServices.GetAllProducts();
            int pageSize = 12;
            if (prodsCount == null)
            {
                if (pg < 1)
                    pg = 1;

                int recsCount = products.Count();

                var pager = new Pager(recsCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = products.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;
                return View(data);
            }else
            {
                pageSize = (int)prodsCount;
                if (pg < 1)
                    pg = 1;

                int recsCount = products.Count();

                var pager = new Pager(recsCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = products.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;
                return View(data);
            }
            //return View(products);
        }
        public IActionResult ProductsByCategory(int? prodsCount,int id, int pg)
        {
            ViewBag.CategoryId = id;
            var products = ProductsServices.GetProductsByCategoryId(id);
            int pageSize = 12;
            if (prodsCount == null)
            {
                if (pg < 1)
                    pg = 1;

                int recsCounts = products.Count();

                var pagers = new Pager(recsCounts, pg, pageSize);
                int recSkips = (pg - 1) * pageSize;
                var datas = products.Skip(recSkips).Take(pagers.PageSize).ToList();
                this.ViewBag.Pager = pagers;
                return View(datas);
            }
            else
            {
                pageSize = (int)prodsCount;
                if (pg < 1)
                    pg = 1;

                int recsCounts = products.Count();

                var pagers = new Pager(recsCounts, pg, pageSize);
                int recSkips = (pg - 1) * pageSize;
                var datas = products.Skip(recSkips).Take(pagers.PageSize).ToList();
                this.ViewBag.Pager = pagers;
                return View(datas);
            }

            if (pg < 1)
                pg = 1;

            int recsCount = products.Count();

            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = products.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(data);
            //return View(products);
        }
    }
}
