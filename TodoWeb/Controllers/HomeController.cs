using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TodoWeb.Models;

namespace TodoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoService _service;

        public HomeController(ITodoService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            List<Todo> list = _service.GetTodos();

            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Todo newTodo)
        {
            if (newTodo.Title is not null)
            {
                if (_service.AddTodo(newTodo))
                {
                    return Redirect("index");
                }
            }

            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Todo todo = _service.GetById(id);
            return View(todo);
        }

        [HttpPost]
        public IActionResult Edit(Todo todo)
        {
            if(_service.UpdateTodo(todo))
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(todo);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.DeleteTodo(id);
            return RedirectToAction("Index");
        }
    }
}
