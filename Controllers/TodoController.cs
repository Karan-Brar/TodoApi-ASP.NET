using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    /// <summary>
    /// This is the main controller class that will map to the route ending with "/Todo".
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        /// <summary>
        /// Initializes an instance of the controller class.
        /// </summary>
        /// <param name="context">An instance of TodoContext that will be used by the controller</param>
        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem { Description = "Buy movie tickets" });
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Responds to GET requests at the route "/Todo".
        /// </summary>
        /// <returns>The List of to-do items in the database.</returns>
        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        /// <summary>
        /// Responds to GET requests at the route "/Todo/{id}" where {id} is the ID of the To-do item to be retrieved.
        /// </summary>
        /// <param name="id">The ID of the to-do item passed as a parameter in the URL.</param>
        /// <returns>
        /// A specific action result or the to-do item found.
        /// Possible action return types - NotFoundActionResult
        /// </returns>
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

        /// <summary>
        /// Responds to the POST requests at the route "/Todo".
        /// </summary>
        /// <param name="todoItem">The to-do item data from the request body.</param>
        /// <returns>
        /// A specific action result.
        /// Possible action return types - CreatedAtActionResult
        /// </returns>
        [HttpPost]
        public IActionResult Create(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Create), new { id = todoItem.Id }, todoItem);
        }

        /// <summary>
        /// Responds to PUT requests at the route "/Todo/{id}" where {id} is the ID of the To-do item to be updated.
        /// </summary>
        /// <param name="id">The ID of the to-do item passed as a parameter in the URL.</param>
        /// <param name="todoItem">
        /// The to-do item data from the request body.
        /// Possible action return types - BadRequestActionResult, NotFoundActionResult, NoContentActionResult
        /// </param>
        /// <returns>A specific action result.</returns>
        /// <remarks>The ID passed as a parameter must match the ID of the to-do item passed in request body.</remarks>
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

            if(todoItem.Description != null)
            {
                existingTodoItem.Description = todoItem.Description;
            }

            existingTodoItem.IsComplete = todoItem.IsComplete;
            

            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Responds to DELETE requests at the route "/Todo/{id}" where {id} is the ID of the To-do item to be deleted.
        /// </summary>
        /// <param name="id">The ID of the to-do item passed as a parameter in the URL</param>
        /// <returns>
        /// A specific action result.
        /// Possible action return types - NotFoundActionResult, NoContentActionResult.
        /// </returns>
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
