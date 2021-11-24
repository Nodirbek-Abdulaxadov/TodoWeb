using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoWeb.Models
{
    public interface ITodoService
    {
        List<Todo> GetTodos();
        Todo GetById(int id);
        bool AddTodo(Todo todo);
        bool UpdateTodo(Todo todo);
        bool DeleteTodo(int id);
    }
}
