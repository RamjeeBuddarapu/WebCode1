using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebCode.Database;
using WebCode.Entities;

namespace WebCode.Controllers
{
    [Authorize(Roles="Supplier,User")]
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController:ControllerBase
    {
        private readonly MyContext _dbContext;
        public ItemController(MyContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Authorize(Roles ="Supplier")]
        [HttpPost("AddItem")]
        public IActionResult AddItem([FromBody] Item item)
        {
            return Ok("Item added successfully");
        }
        [Authorize(Roles = "Supplier")]
        [HttpGet("GetItems")]
        public IActionResult GetItems()
        {
            return Ok("List of items");
        }
        [Authorize(Roles = "Supplier")]
        [HttpGet("GetItemsByItemCode/{itemCode}")]
        public IActionResult GetItemsByItemCode(int itemCode)
        {
            return Ok("Item details by code");
        }

        [Authorize(Roles = "Supplier")]
        [HttpPut("EditItem")]
        public IActionResult EditItem([FromBody] Item item)
        {
            return Ok("Item edited successfuly");
        }

        [Authorize(Roles = "Supplier")]
        [HttpDelete("DeleteItem/{itemCode}")]
        public IActionResult DeleteItem(int itemCode)
        {
            return Ok("Item deleted successfully");
        }

        [Authorize(Roles = "User")]
        [HttpGet("GetItemsByName/{itemName}")]
        public IActionResult GetItemsByName(string itemName)
        {
            return Ok("List of items by name");
        }
    }
}