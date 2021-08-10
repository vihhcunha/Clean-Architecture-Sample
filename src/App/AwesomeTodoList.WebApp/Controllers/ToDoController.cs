using AwesomeTodoList.Domain.CommonObjects.Exceptions;
using AwesomeTodoList.Domain.CommonObjects.Validation;
using AwesomeToDoList.Adapters.Services;
using AwesomeToDoList.Adapters.ViewModels;
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
        private readonly IValidationService _validationService;

        public ToDoController(IToDoServices toDoServices, IValidationService validationService)
        {
            _toDoServices = toDoServices;
            _validationService = validationService;
        }

        [Route("/")]
        public async Task<IActionResult> ToDoList()
        {
            return View(await _toDoServices.GetToDoList());
        }

        [HttpDelete]
        [Route("remove-todo")]
        public async Task<IActionResult> RemoveToDo(Guid idToDo)
        {
            await _toDoServices.RemoveToDo(idToDo);
            return View("ToDoList", await _toDoServices.GetToDoList());
        }

        [HttpGet]
        [Route("add-todo")]
        public IActionResult AddToDo()
        {
            return View();
        }

        [HttpPost]
        [Route("add-todo")]
        public async Task<IActionResult> AddToDo(ToDoViewModel toDoViewModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(toDoViewModel);

                await _toDoServices.AddToDo(toDoViewModel);
                return RedirectToAction("ToDoList");
            }
            catch (DomainException ex)
            {
                CarregarMensagensDeValidacao();
                return View(toDoViewModel);
            }
            
        }

        public void CarregarMensagensDeValidacao()
        {
            ViewData["errors"] = _validationService.MessagesValidationList;
        }
    }
}
