using MC_ComputerSolutions.Entities;
using MC_ComputerSolutions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC_ComputerSolutions.Repositories
{
    public class InvoiceProductsRepository : IInvoiceProducts
    {
        AppDbContext _appDbContext;

        public InvoiceProductsRepository(AppDbContext dbcontext)
        {
            _appDbContext = dbcontext;
        }


        public void CreateInvoiceProducts(InvoiceProducts InvoiceProductsObject)
        {
            _appDbContext.InvoiceProducts.Add(InvoiceProductsObject);
            _appDbContext.SaveChanges();
        }

        public void DeleteInvoiceProducts(int id)
        {
            var invoiceProducts = _appDbContext.InvoiceProducts.Where(c => c.InvoiceProductsID == id).SingleOrDefault();
            _appDbContext.InvoiceProducts.Remove(invoiceProducts);
            _appDbContext.SaveChanges();
        }

        public ICollection<InvoiceProducts> GetAllInvoiceProducts()
        {
            var invoiceProducts = _appDbContext.InvoiceProducts.ToList();
            return invoiceProducts;
        }


        public InvoiceProducts GetByInvoiceProductsID(int id)
        {
            var invoiceProducts = _appDbContext.InvoiceProducts.Where(c => c.InvoiceProductsID == id).SingleOrDefault();
            return invoiceProducts;
        }

        public int UpdateInvoiceProducts(int id, InvoiceProducts InvoiceProductsObject)
        {
            var invoiceProducts = _appDbContext.InvoiceProducts.Where(c => c.InvoiceProductsID == id).SingleOrDefault();
            if (invoiceProducts == null)
            {
                return 0;
            }
            else
            {
                invoiceProducts.InvoiceNo = InvoiceProductsObject.InvoiceNo;
                invoiceProducts.ProductID = InvoiceProductsObject.ProductID;
                invoiceProducts.Quantity = InvoiceProductsObject.Quantity;
                invoiceProducts.Total = InvoiceProductsObject.Total;

                _appDbContext.SaveChanges();
                return 1;
            }
        }

        ICollection<DTOInvoiceProductDetails> IInvoiceProducts.GetByInvoiceInvoice(string InvoiceNo)
        {
            var invoiceProductsList = (from product in _appDbContext.Product
                                join invoiceProducts in _appDbContext.InvoiceProducts
                                on product.ProductID equals invoiceProducts.ProductID
                                where invoiceProducts.InvoiceNo == InvoiceNo
                                select new DTOInvoiceProductDetails
                                {
                                    InvoiceProductID = invoiceProducts.InvoiceProductsID,
                                    InvoiceNo = invoiceProducts.InvoiceNo,
                                    ProductID = product.ProductID,
                                    ProductName = product.ProductName,
                                    UnitPrice = product.UnitPrice,
                                    Quantity = invoiceProducts.Quantity,
                                    Total = invoiceProducts.Total

                                }).ToList();

            return invoiceProductsList;

          
        }
    }
}
