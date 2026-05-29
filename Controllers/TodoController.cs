using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController(TodoContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetAll([FromQuery] int? listId)
        {
            var query = context.TodoItems.AsQueryable();
            if (listId.HasValue)
                query = query.Where(t => t.ListId == listId);
            return Ok(await query.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            var item = await context.TodoItems.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> Create(TodoItem item)
        {
            context.TodoItems.Add(item);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TodoItem updated)
        {
            var todo = await context.TodoItems.FindAsync(id);
            if (todo == null) return NotFound();

            todo.Title = updated.Title;
            todo.IsCompleted = updated.IsCompleted;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var todo = await context.TodoItems.FindAsync(id);
            if (todo == null) return NotFound();

            context.TodoItems.Remove(todo);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}