﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
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

        public ViewResult List(int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = ProductsRepository.Products.Count()
                },

                Products = ProductsRepository
                  .Products
                  .OrderBy(p => p.ProductId)
                  .Skip((page - 1) * PageSize)
                  .Take(PageSize)
            };

            return View(model);
        }
    }
}