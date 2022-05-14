using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MC_ComputerSolutions.Entities
{
    public class InvoiceProducts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceProductsID { get; set; }

        [Required]
        public string InvoiceNo { get; set; }

        [ForeignKey("ProductID")]
        public Product ParentProduct { get; set; }
        public int ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public float Total { get; set; }
    }
}
