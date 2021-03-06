﻿using System.Collections.Generic;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.Domain.Concrete
{
    public class InMemoryProductsRepository : IProductsRepository
    {
        private List<Product> _products = new List<Product>
        {
            new Product { Name = "Football", Price = 25 },
            new Product { Name = "Surf board", Price = 179 },
            new Product { Name = "Running shoes", Price = 95 }
        };
        public IEnumerable<Product> Products
        {
            get { return _products; }
        }

        public Product DeleteProduct(int productId)
        {
            throw new System.NotImplementedException();
        }

        public void SaveProduct(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
