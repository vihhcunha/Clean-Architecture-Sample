using AwesomeToDoList.Adapters.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeTodoList.WebApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoServices _toDoServices;

        public ToDoController(IToDoServices toDoServices)
        {
            _toDoServices = toDoServices;
        }

        [Route("/")]
        public async Task<IActionResult> Home()
        {
            return View(await _toDoServices.GetToDoList());
        }
    }
}
