using MC_ComputerSolutions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC_ComputerSolutions.Interfaces
{
    public interface IInvoice
    {
        ICollection<Invoice> GetAllInvoices();

        Invoice GetByInvoiceID(int id);


        Invoice GetByInvoiceNo(string invoiceNo);

        void CreateInvoice(Invoice InvoiceObject);

        int UpdateInvoice(string InvoiceNo, Invoice InvoiceObject);

        void DeleteInvoice(int id);
    }
}
