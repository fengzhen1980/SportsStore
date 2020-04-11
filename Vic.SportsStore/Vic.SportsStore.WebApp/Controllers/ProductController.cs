﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Entities;
using Vic.SportsStore.WebApp.Models;

namespace Vic.SportsStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        public const int PageSize = 2;
        public IProductsRepository ProductsRepository { get; set; }

        //// GET: Product
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                currentCategory = category,

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = ProductsRepository.Products
                                .Where(p => category == null || p.Category == category)
                                .Count()
                },

                Products = ProductsRepository
                  .Products
                  .Where(p => category == null || p.Category == category)
                  .OrderBy(p => p.ProductId)
                  .Skip((page - 1) * PageSize)
                  .Take(PageSize)
            };

            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = ProductsRepository
            .Products
            .FirstOrDefault(p => p.ProductId == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}