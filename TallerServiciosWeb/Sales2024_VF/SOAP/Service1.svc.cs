using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SOAP
{
    public class Service1 : IService1
    {
        private ProductLogic _productLogic;
        private CategoryLogic _categoryLogic;

        public Service1()
        {
            _productLogic = new ProductLogic();
            _categoryLogic = new CategoryLogic();
        }

        public Products Create(Products newProduct)
        {
            return _productLogic.Create(newProduct);
        }

        public Products[] GetAllProducts()
        {
            var products = _productLogic.RetrieveAllProducts();
            return products.Select(p => new Products
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                CategoryID = p.CategoryID,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock
            }).ToArray();
        }


        public bool DeleteProduct(int productId)
        {
            var productLogic = new ProductLogic();
            return productLogic.Delete(productId);
        }

        public bool UpdateProduct(Products productToUpdate)
        {
            return _productLogic.Update(productToUpdate);
        }

        public Categories CreateCategory(Categories newCategory)
        {
            return _categoryLogic.Create(newCategory);
        }

        public bool UpdateCategory(Categories categoryToUpdate)
        {
            return _categoryLogic.Update(categoryToUpdate);
        }

        public bool DeleteCategory(int categoryId)
        {
            return _categoryLogic.Delete(categoryId);
        }

        public Categories[] GetAllCategories()
        {
            // Obtener todas las categorías usando la lógica BLL
            var categories = _categoryLogic.RetrieveAll();

            // Transformar las categorías en DTOs y devolverlas como arreglo
            return categories.Select(c => new Categories
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
                Description = c.Description
            }).ToArray();
        }
    }
}