﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;

namespace Vic.SportsStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        public IProductsRepository ProductsRepository { get; set; }

        //// GET: Product
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ViewResult List()
        {
            return View(ProductsRepository.Products);
        }
    }
}