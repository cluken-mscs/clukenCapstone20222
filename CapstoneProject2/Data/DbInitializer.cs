using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneProject2.Models;

namespace CapstoneProject2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
            new Product {Brand="DC",Description="Judge",Size="Large"},
            new Product {Brand="DC",Description="Control",Size="Large"},
            new Product {Brand="DC",Description="Operative",Size="Large"},
            new Product {Brand="DC",Description="Servo",Size="Large"},
            new Product {Brand="Lib Tech",Description="Orca",Size="Large"},
            new Product {Brand="Lib Tech",Description="T.Rice Pro",Size="Large"},
            new Product {Brand="Anon",Description="Invert",Size="Large"},
            new Product {Brand="Anon",Description="Helo",Size="Large"}
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            var productTypes = new ProductType[]
            {
            new ProductType{ProdTypeId=1,ProductId=1,ProdTypeDesc="Boots"},
            new ProductType{ProdTypeId=1,ProductId=2,ProdTypeDesc="Boots"},
            new ProductType{ProdTypeId=2,ProductId=3,ProdTypeDesc="Coat"},
            new ProductType{ProdTypeId=2,ProductId=4,ProdTypeDesc="Coat"},
            new ProductType{ProdTypeId=3,ProductId=5,ProdTypeDesc="Snowboard"},
            new ProductType{ProdTypeId=3,ProductId=6,ProdTypeDesc="Snowboard"},
            new ProductType{ProdTypeId=4,ProductId=7,ProdTypeDesc="Helmet"},
            new ProductType{ProdTypeId=4,ProductId=8,ProdTypeDesc="Helmet"},
            };
            foreach (ProductType pt in productTypes)
            {
                context.ProductTypes.Add(pt);
            }
            context.SaveChanges();
        }
    }
}