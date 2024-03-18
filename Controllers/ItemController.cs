using Microsoft.AspNetCore.Mvc;
using WarehouseManager.Data;
using WarehouseManager.Entities;

namespace WarehouseManager.Controllers
{
    [ApiController]
    [Route("[Controller]")] // 
    public class ItemController : ControllerBase
    {
        private readonly DataContext _context;

        public ItemController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItem() // List of items
        {
            var items = _context.Items;
            return items;
        }

        [HttpGet("{id}")] // Specific item

        public ActionResult<Item> GetItem(int id)
        {
            var item = _context.Items.Find(id);

            return item;
        }
    }
}
