using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Base.data.Models;
using Base.data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : Controller
    {
        //private readonly ApplicationDBContext _todoContext;
        private readonly ITodoInterface _iTodoService;

        public TodoItemController(ApplicationDBContext todoContext, ITodoInterface iTodoService)
        {
            //_todoContext = todoContext;
            _iTodoService = iTodoService;
        }
        // GET: /<controller>/
        [HttpGet]
        public async Task<List<TodoItem>> GetTodos()
        {
            return await _iTodoService.GetTodoItems();
        }

        // GET: /Id
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodo(long id)
        {
            var todoItem = await _iTodoService.GetTodoItem(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost]
        public async Task<TodoItem> CreateTodo(TodoItem todoItem)
        {
            _iTodoService.CreateTodoItem(todoItem);
            await _iTodoService.SaveChanges();
            return todoItem;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _todoContext.Entry(todoItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _todoContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

    }
}

