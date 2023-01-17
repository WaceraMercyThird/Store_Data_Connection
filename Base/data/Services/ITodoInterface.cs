using System;
using Base.data.Models;

namespace Base.data.Services
{
	public interface ITodoInterface
	{
		public Task<List<TodoItem>> GetTodoItems();

        public Task<TodoItem> GetTodoItem(long id);

        public void CreateTodoItem(TodoItem? todoItem);
        public Task<bool> SaveChanges();
    }
}

