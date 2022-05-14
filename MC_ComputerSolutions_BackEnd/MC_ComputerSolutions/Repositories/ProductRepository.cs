using MC_ComputerSolutions.Entities;
using MC_ComputerSolutions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC_ComputerSolutions.Repositories
{
    public class ProductRepository : IProduct
    {
        AppDbContext _appDbContext;

        public ProductRepository(AppDbContext dbcontext)
        {
            _appDbContext = dbcontext;
        }


        public void CreateProduct(Product ProductObject)
        {
            _appDbContext.Product.Add(ProductObject);
            _appDbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _appDbContext.Product.Where(c => c.ProductID == id).SingleOrDefault();
            _appDbContext.Product.Remove(product);
            _appDbContext.SaveChanges();
        }

        public ICollection<Product> GetAllProducts()
        {
            var product = _appDbContext.Product.ToList();
            return product;
        }

        public Product GetByProductID(int id)
        {
            var product = _appDbContext.Product.Where(c => c.ProductID == id).SingleOrDefault();
            return product;
        }

        public int UpdateProduct(int id, Product ProductObject)
        {
            var product = _appDbContext.Product.Where(c => c.ProductID == id).SingleOrDefault();
            if (product == null)
            {
                return 0;
            }
            else
            {
                product.ProductID = ProductObject.ProductID;
                product.ProductName = ProductObject.ProductName;
                product.UnitPrice = ProductObject.UnitPrice;

                _appDbContext.SaveChanges();
                return 1;
            }
        }
    }
}
