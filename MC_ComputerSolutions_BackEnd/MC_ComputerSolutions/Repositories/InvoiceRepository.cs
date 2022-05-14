using MC_ComputerSolutions.Entities;
using MC_ComputerSolutions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC_ComputerSolutions.Repositories
{
    public class InvoiceRepository : IInvoice
    {
        AppDbContext _appDbContext;

        public InvoiceRepository(AppDbContext dbcontext)
        {
            _appDbContext = dbcontext;
        }


        public void CreateInvoice(Invoice InvoiceObject)
        {
            _appDbContext.Invoice.Add(InvoiceObject);
            _appDbContext.SaveChanges();
        }

        public void DeleteInvoice(int id)
        {
            var invoice = _appDbContext.Invoice.Where(c => c.InvoiceID == id).SingleOrDefault();
            _appDbContext.Invoice.Remove(invoice);
            _appDbContext.SaveChanges();
        }

        public ICollection<Invoice> GetAllInvoices()
        {
            var invoice = _appDbContext.Invoice.ToList();
            return invoice;
        }

        public Invoice GetByInvoiceID(int id)
        {
            var invoice = _appDbContext.Invoice.Where(c => c.InvoiceID == id).SingleOrDefault();
            return invoice;
        }

        public Invoice GetByInvoiceNo(string invoiceNo)
        {
            var invoiceData = _appDbContext.Invoice.Where(c => c.InvoiceNo == invoiceNo).SingleOrDefault();
            return invoiceData;
        }

        public int UpdateInvoice(string InvoiceNo, Invoice InvoiceObject)
        {
            var invoice = _appDbContext.Invoice.Where(c => c.InvoiceNo == InvoiceNo).SingleOrDefault();

                invoice.InvoiceNo = InvoiceObject.InvoiceNo;
                invoice.CustomerName = InvoiceObject.CustomerName;
                invoice.PurchasedDate = InvoiceObject.PurchasedDate;
                invoice.GrossTotal = InvoiceObject.GrossTotal;
                invoice.Discount = InvoiceObject.Discount;
                invoice.NetTotal = InvoiceObject.NetTotal;

                _appDbContext.SaveChanges();
                return 1;
        }
    }
}
