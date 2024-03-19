using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task <ActionResult<IEnumerable<Item>>> GetItem() // List of items
        {
            var items = await _context.Items.ToListAsync();
            return items;
        }

        [HttpGet("{id}")] // Specific item

        public async Task <ActionResult<Item>> GetItem(int id)
        {
            return await _context.Items.FindAsync(id);
        }
    }
}
