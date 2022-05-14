using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MC_ComputerSolutions.Entities
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceID { get; set; }

        [Required]
        public string InvoiceNo { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public DateTime PurchasedDate { get; set; }

        [Required]
        public float GrossTotal { get; set; }

        [Required]
        public float Discount { get; set; }

        [Required]
        public float NetTotal { get; set; }
    }
}
