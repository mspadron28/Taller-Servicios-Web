using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductLogic
    {
        public Products Create(Products products)
        {
            Products res = null;

            using (var r = RepositoryFactory.CreateRepository())
            {
                Products result = r.Retrieve<Products>(p => p.ProductName == products.ProductName);
                if (result == null)
                {
                    res = r.Create(products);
                }
                else
                {
                   
                }
                return res;
            }
        }

        public Products RetrieveById(int id)
        {
            Products res = null;

            using (var r = RepositoryFactory.CreateRepository())
            {
                res = r.Retrieve<Products>(p => p.ProductID == id);
            }
            return res;
        }

        public bool Update(Products productToUpdate)
        {
            bool res = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Verificar si ya existe un producto con el mismo nombre pero con un ProductID diferente
                Products existingProduct = r.Retrieve<Products>(
                    p => p.ProductName == productToUpdate.ProductName && p.ProductID != productToUpdate.ProductID);

                if (existingProduct == null)
                {
                    // No existe otro producto con el mismo nombre, proceder con la actualización
                    res = r.Update(productToUpdate);
                }
                else
                {

                }
            }
            return res;
        }

        public bool Delete(int id)
        {
            bool res = false;

            var product = RetrieveById(id);
            if (product != null)
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    res = r.Delete(product);
                }
            }
            else
            {
                // Producto no encontrado
                throw new Exception($"Producto con ID {id} no encontrado.");
            }
            return res;
        }


        public List<Products> Filters(string name)
        {
            List<Products> res = null;

            using (var respository = RepositoryFactory.CreateRepository())
            {
                res = respository.Filter<Products>(
                    p => p.ProductName == name);
            }
            return res;
        }

        //Mostrar todo
        public List<Products> RetrieveAllProducts()
        {
            List<Products> res = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                res = r.RetrieveAll<Products>();
            }
            return res;
        }

    }


}