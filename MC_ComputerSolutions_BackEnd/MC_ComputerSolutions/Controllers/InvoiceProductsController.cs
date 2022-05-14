using MC_ComputerSolutions.Entities;
using MC_ComputerSolutions.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC_ComputerSolutions.Controllers
{
    [Route("api/InvoiceProducts")]
    [ApiController]
    public class InvoiceProductsController : ControllerBase
    {
        IInvoiceProducts _InvoiceProductsRepo;

        public InvoiceProductsController(IInvoiceProducts InvoiceProductsRepo)
        {
            _InvoiceProductsRepo = InvoiceProductsRepo;
        }

        public IActionResult GetAllInvoiceProducts()
        {
            var invoiceProducts = _InvoiceProductsRepo.GetAllInvoiceProducts();
            return Ok(invoiceProducts);
        }

        [HttpGet("byInvoiceNo/{invoiceNo}")]
        public IActionResult GetByInvoiceInvoice(string invoiceNo)
        {
            var invoiceProducts = _InvoiceProductsRepo.GetByInvoiceInvoice(invoiceNo);
            return Ok(invoiceProducts);
        }


        [HttpGet("{id}")]

        public IActionResult GetByInvoiceProductsID(int id)
        {
            if (id < 0)
            {
                BadRequest();
            }
            var invoiceProduct = _InvoiceProductsRepo.GetByInvoiceProductsID(id);
            return Ok(invoiceProduct);
        }

        [HttpPost]

        public IActionResult CreateInvoiceProducts([FromBody] InvoiceProducts newObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (newObj == null)
            {
                return BadRequest();
            }

            _InvoiceProductsRepo.CreateInvoiceProducts(newObj);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateInvoiceProducts(int id, [FromBody] InvoiceProducts newObj)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            int result = _InvoiceProductsRepo.UpdateInvoiceProducts(id, newObj);
            if (result == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteInvoiceProducts(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            _InvoiceProductsRepo.DeleteInvoiceProducts(id);

            return Ok();
        }
    }
}
