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



    }
}
