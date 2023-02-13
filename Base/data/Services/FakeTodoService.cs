using System;
using Base.data.Models;
using Microsoft.EntityFrameworkCore;

namespace Base.data.Services
{
	public class FakeTodoService : ITodoInterface
    {

        private readonly ApplicationDBContext _todoContext;

        public FakeTodoService(ApplicationDBContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task<List<TodoItem>> GetTodoItems()
        {
            return await  _todoContext.TodoItems.ToListAsync();
        }
        public async Task<TodoItem> GetTodoItem(long id)
        {
            return await _todoContext.TodoItems.FindAsync(id);
        }

        public void CreateTodoItem(TodoItem todoItem)
        {
            _todoContext.TodoItems.Add(todoItem);
        }

        public async Task<bool> SaveChanges()
        {
            return await _todoContext.SaveChangesAsync() > 0;
        }


    }
}

