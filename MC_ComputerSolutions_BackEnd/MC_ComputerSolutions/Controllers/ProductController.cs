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
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProduct _ProductRepo;

        public ProductController(IProduct ProductRepo)
        {
            _ProductRepo = ProductRepo;
        }

        public IActionResult GetAllProducts()
        {
            var products = _ProductRepo.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]

        public IActionResult GetByProductID(int id)
        {
            if (id < 0)
            {
                BadRequest();
            }
            var product = _ProductRepo.GetByProductID(id);
            return Ok(product);
        }

        [HttpPost]

        public IActionResult CreateProduct([FromBody] Product newObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (newObj == null)
            {
                return BadRequest();
            }

            _ProductRepo.CreateProduct(newObj);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateProduct(int id, [FromBody] Product newObj)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            int result = _ProductRepo.UpdateProduct(id, newObj);
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

        public IActionResult DeleteProduct(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            _ProductRepo.DeleteProduct(id);

            return Ok();
        }
    }
}
