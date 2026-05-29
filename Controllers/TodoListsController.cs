using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListsController(TodoContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetAll()
        {
            return Ok(await context.TodoLists.Include(l => l.Category).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoList>> Get(int id)
        {
            var list = await context.TodoLists.Include(l => l.Category).Include(l => l.Items).FirstOrDefaultAsync(l => l.Id == id);
            if (list == null) return NotFound();
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult<TodoList>> Create(TodoList list)
        {
            context.TodoLists.Add(list);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = list.Id }, list);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TodoList updated)
        {
            var list = await context.TodoLists.FindAsync(id);
            if (list == null) return NotFound();
            list.Name = updated.Name;
            list.CategoryId = updated.CategoryId;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var list = await context.TodoLists.FindAsync(id);
            if (list == null) return NotFound();
            context.TodoLists.Remove(list);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
