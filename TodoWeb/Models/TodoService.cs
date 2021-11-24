using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoWeb.Models
{
    public class TodoService : ITodoService
    {
        List<Todo> todos;
        int ID = 4;
        public TodoService()
        {
            todos = new List<Todo>()
            {
                new Todo 
                {
                    Id = 1, 
                    Title = "Birinchi topshiriq", 
                    Time = DateTime.Now
                },
                new Todo
                {
                    Id = 2,
                    Title = "Ikkinchi topshiriq",
                    Time = DateTime.Now
                },
                new Todo
                {
                    Id = 3,
                    Title = "Yana nimadir",
                    Time = DateTime.Now
                }
            };
        }
        public bool AddTodo(Todo todo)
        {
            try
            {
                todo.Id = ID;
                todo.Time = DateTime.Now;
                todos.Add(todo);
                ID++;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteTodo(int id)
        {
            try
            {
                todos.RemoveAll(p => p.Id == id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Todo GetById(int id)
        {
            return todos.FirstOrDefault(t => t.Id == id);
        }

        public List<Todo> GetTodos()
        {
            return todos;
        }

        public bool UpdateTodo(Todo todo)
        {
            foreach (var t in todos)
            {
                if (t.Id == todo.Id)
                {
                    t.Title = todo.Title;
                    t.Time = DateTime.Now;
                    return true;
                }
            }

            return true;
        }
    }
}
