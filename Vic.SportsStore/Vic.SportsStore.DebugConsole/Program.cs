using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EFDbContext())
            {
                var product = new Product()
                {
                    Name = "name-001",
                    Price = 1.2M,
                    Description = "des01",
                    Category = "C1"
                };


                ctx.Products.Add(product);
                ctx.SaveChanges();
            }

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
