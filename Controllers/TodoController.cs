using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Services;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll() =>
            TodoItemService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var todoItem = TodoItemService.Get(id);

            if(todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }


        [HttpPost]
        public IActionResult Create(TodoItem todoItem)
        {
            TodoItemService.Add(todoItem);
            return CreatedAtAction(nameof(Create), new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoItem todoItem)
        {
            if(id != todoItem.Id)
            {
                return BadRequest();
            }

            var existingTodoItem = TodoItemService.Get(id);
            if(existingTodoItem is null)
            {
                return NotFound();
            }

            TodoItemService.Update(todoItem);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todoItem = TodoItemService.Get(id);

            if(todoItem is null)
            {
                return NotFound();
            }

            TodoItemService.Delete(id);

            return NoContent();
        }
    }
}
