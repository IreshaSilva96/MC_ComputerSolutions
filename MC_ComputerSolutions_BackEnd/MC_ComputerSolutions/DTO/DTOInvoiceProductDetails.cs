using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC_ComputerSolutions
{
    public class DTOInvoiceProductDetails
    {

        public int InvoiceProductID { get; set; }

        public string InvoiceNo { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public float AvailableQty { get; set; }

        public float UnitPrice { get; set; }

        public int Quantity { get; set; }

        public float Total { get; set; }
    }
}
