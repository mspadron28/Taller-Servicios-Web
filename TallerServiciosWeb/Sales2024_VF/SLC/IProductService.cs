using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC
{
    public interface IProductService
    {
        Products CreateProduct(Products products);
        List<Products> GetAllProducts();
        bool Delete(int id);

    }
}