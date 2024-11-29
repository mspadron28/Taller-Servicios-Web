using Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            addCategoryAndProduct();
        }

        static void addCategoryAndProduct()
        {
            var categories = new Categories();
            categories.CategoryName = "Test2";
            categories.Description = "Description Test 2";

            var product = new Products();
            product.ProductName = "Aji";
            product.UnitPrice = 5;
            product.UnitsInStock = 500;

            //guardar
            categories.Products.Add(product);

            using (var repository = RepositoryFactory.CreateRepository())
            {
                repository.Create(categories);
            }

            Console.WriteLine($"Categoria: {categories.CategoryID}, Producto: {product.ProductID}");
            Console.ReadLine();
        }
    }
}
