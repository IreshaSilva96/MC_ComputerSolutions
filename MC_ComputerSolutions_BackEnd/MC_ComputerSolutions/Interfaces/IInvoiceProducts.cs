using MC_ComputerSolutions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC_ComputerSolutions.Interfaces
{
    public interface IInvoiceProducts
    {
        ICollection<InvoiceProducts> GetAllInvoiceProducts();

        InvoiceProducts GetByInvoiceProductsID(int id);

        ICollection<DTOInvoiceProductDetails> GetByInvoiceInvoice(string InvoiceNo);

        void CreateInvoiceProducts(InvoiceProducts InvoiceProductsObject);

        int UpdateInvoiceProducts(int id, InvoiceProducts InvoiceProductsObject);

        void DeleteInvoiceProducts(int id);
    }
}
