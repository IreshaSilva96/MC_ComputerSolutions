using MC_ComputerSolutions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC_ComputerSolutions.Interfaces
{
    public interface IProduct
    {
        ICollection<Product> GetAllProducts();

        Product GetByProductID(int id);

        void CreateProduct(Product ProductObject);

        int UpdateProduct(int id, Product ProductObject);

        void DeleteProduct(int id);
    }
}
