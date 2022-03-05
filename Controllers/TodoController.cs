using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem { Description = "blah blah" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var todoItem = _context.TodoItems.Find(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }


        [HttpPost]
        public IActionResult Create(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Create), new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            var existingTodoItem = _context.TodoItems.Find(id);
            if (existingTodoItem is null)
            {
                return NotFound();
            }

            existingTodoItem.Description = todoItem.Description;
            existingTodoItem.IsComplete = todoItem.IsComplete;

            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todoItem = _context.TodoItems.Find(id);

            if (todoItem is null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
