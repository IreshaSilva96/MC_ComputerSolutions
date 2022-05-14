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
    [Route("api/Invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        IInvoice _InvoiceRepo;

        public InvoiceController(IInvoice InvoiceRepo)
        {
            _InvoiceRepo = InvoiceRepo;
        }

        public IActionResult GetAllInvoices()
        {
            var invoices = _InvoiceRepo.GetAllInvoices();
            return Ok(invoices);
        }

        [HttpGet("{id}")]

        public IActionResult GetByInvoiceID(int id)
        {
            if (id < 0)
            {
                BadRequest();
            }
            var invoice = _InvoiceRepo.GetByInvoiceID(id);
            return Ok(invoice);
        }

        [HttpGet("byInvoiceNo/{invoiceNo}")]

        public IActionResult GetByInvoiceNo(string invoiceNo)
        {
            var invoiceData = _InvoiceRepo.GetByInvoiceNo(invoiceNo);
            return Ok(invoiceData);
        }

        [HttpPost]

        public IActionResult CreateInvoice([FromBody] Invoice newObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (newObj == null)
            {
                return BadRequest();
            }

            _InvoiceRepo.CreateInvoice(newObj);
            return Ok();
        }

        [HttpPut("{InvoiceNo}")]

        public IActionResult UpdateInvoice(string InvoiceNo, [FromBody] Invoice newObj)
        {

            int result = _InvoiceRepo.UpdateInvoice(InvoiceNo, newObj);
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

        public IActionResult DeleteInvoice(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            _InvoiceRepo.DeleteInvoice(id);

            return Ok();
        }
    }
}
