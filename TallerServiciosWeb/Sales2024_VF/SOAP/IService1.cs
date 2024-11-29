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
    [ServiceContract]
    public interface IService1
    {
     
        [OperationContract]
        Products Create(Products newProduct);

        [OperationContract]
        Products[] GetAllProducts();

        [OperationContract]
        bool DeleteProduct(int id);

        [OperationContract]
        bool UpdateProduct(Products productToUpdate);

        
        [OperationContract]
        Categories CreateCategory(Categories newCategory);

        [OperationContract]
        bool UpdateCategory(Categories categoryToUpdate);

        [OperationContract]
        bool DeleteCategory(int categoryId);

        [OperationContract]
        Categories[] GetAllCategories();
    }

}
