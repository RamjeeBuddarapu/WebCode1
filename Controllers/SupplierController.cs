using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebCode.Database;
using WebCode.Entities;

namespace WebCode.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles="Supplier")]
    public class SupplierController: ControllerBase
    {
        private readonly MyContext _dbContext;
        public SupplierController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost("AddSupplier")]
        public IActionResult AddSupplier([FromBody]Supplier supplier)
        {
            return Ok("Supplier added successfully");
        }
        [HttpGet("GetSuppliers")]
        public IActionResult GetSuppliers()
        {
            return Ok("List of Suppliers");
        }
        [HttpPut("EditSupplier")]
        public IActionResult EditSupplier([FromBody]Supplier supplier)
        {
            return Ok("Supplier edited successfully");
        }
        [HttpDelete("DeleteSupplier/{supplierId}")]
        public IActionResult DeleteSupplier(int supplierId) 
        {
            return Ok("Supplier deleted successfully");
        }

    }
}
