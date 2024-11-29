using BLL;
using Entities;
using SLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Service.Controllers
{
    public class ProductController : ApiController, IProductService
    {
        [HttpPost]
        public Products CreateProduct(Products products)
        {
            var productLogic = new ProductLogic();
            var product = productLogic.Create(products);
            return product;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var productLogic = new ProductLogic();
            var product = productLogic.Delete(id);
            return product;
        }
        [HttpGet]
        public Products GetProductById(int id)
        {
            var productLogic = new ProductLogic();
            var product = productLogic.RetrieveById(id);
            return product;
        }

        [HttpPut]
        public bool UpdateProduct(Products product)
        {
            var productLogic = new ProductLogic();
            var result = productLogic.Update(product);
            return result;
        }

        [HttpGet]
        public List<Products> FilterProducts(string name)
        {
            var productLogic = new ProductLogic();
            var products = productLogic.Filters(name);
            return products;
        }

        [HttpGet]
        public List<Products> GetAllProducts()
        {
            var productLogic = new ProductLogic();
            var products = productLogic.RetrieveAll();
            return products;
        }

    }
}