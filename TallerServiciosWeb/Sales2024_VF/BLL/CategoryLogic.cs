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
    public class CategoryLogic
    {
        public Categories Create(Categories category)
        {
            Categories res = null;

            using (var r = RepositoryFactory.CreateRepository())
            {
                Categories result = r.Retrieve<Categories>(c => c.CategoryName == category.CategoryName);
                if (result == null)
                {
                    res = r.Create(category);
                }
                else
                {
                    // Implementar lógica en caso de que ya exista una categoría con el mismo nombre
                }
                return res;
            }
        }

        public Categories RetrieveById(int id)
        {
            Categories res = null;

            using (var r = RepositoryFactory.CreateRepository())
            {
                res = r.Retrieve<Categories>(c => c.CategoryID == id);
            }
            return res;
        }

        public bool Update(Categories categoryToUpdate)
        {
            bool res = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                // Verificar si ya existe una categoría con el mismo nombre pero con un CategoryID diferente
                Categories existingCategory = r.Retrieve<Categories>(
                    c => c.CategoryName == categoryToUpdate.CategoryName && c.CategoryID != categoryToUpdate.CategoryID);

                if (existingCategory == null)
                {
                    // No existe otra categoría con el mismo nombre, proceder con la actualización
                    res = r.Update(categoryToUpdate);
                }
                else
                {
                    // Implementar lógica en caso de que ya exista una categoría con el mismo nombre
                }
            }
            return res;
        }

        public bool Delete(int id)
        {
            bool res = false;

            var category = RetrieveById(id);
            if (category != null)
            {
                // Aquí no se implementa lógica específica para verificar si se puede eliminar
                // pero se podría agregar lógica adicional si es necesario
                using (var r = RepositoryFactory.CreateRepository())
                {
                    res = r.Delete(category);
                }
            }
            else
            {
                // Implementar lógica para indicar que no existe la categoría
            }
            return res;
        }

        public List<Categories> Filters(string name)
        {
            List<Categories> res = null;

            using (var repository = RepositoryFactory.CreateRepository())
            {
                res = repository.Filter<Categories>(
                    c => c.CategoryName == name);
            }
            return res;
        }

        // Mostrar todas las categorías
        public List<Categories> RetrieveAll()
        {
            List<Categories> res = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                res = r.RetrieveAll<Categories>();
            }
            return res;
        }
    }
}
