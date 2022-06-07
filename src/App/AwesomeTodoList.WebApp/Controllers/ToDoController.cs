using AwesomeTodoList.Domain.CommonObjects.Exceptions;
using AwesomeTodoList.Domain.CommonObjects.Validation;
using AwesomeToDoList.Adapters.Services;
using AwesomeToDoList.Adapters.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [Route("remove-todo/{idToDo}")]
        public async Task<IActionResult> RemoveToDo([FromRoute]Guid idToDo)
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

        [HttpPost]
        [Route("update-todo")]
        public async Task<IActionResult> UpdateToDo(ToDoViewModel toDoViewModel)
        {
            try
            {
                if (!ModelState.IsValid) return RedirectToAction("ToDoList");

                await _toDoServices.UpdateToDo(toDoViewModel.IdToDo, toDoViewModel.Name, toDoViewModel.Description);
                return RedirectToAction("ToDoList");
            }
            catch (DomainException ex)
            {
                CarregarMensagensDeValidacao();
                return RedirectToAction("ToDoList");
            }

        }

        [HttpPatch]
        [Route("update-status-todo/{idToDo}")]
        public async Task<IActionResult> UpdateSTatusToDo([FromRoute] Guid idToDo)
        {
            try
            {
                if (!ModelState.IsValid) return RedirectToAction("ToDoList");

                var toDo = await _toDoServices.GetToDo(idToDo);

                if (toDo.Done)
                    await _toDoServices.ReopenToDo(idToDo);
                else
                    await _toDoServices.FinishToDo(idToDo);

                return RedirectToAction("ToDoList");
            }
            catch (DomainException ex)
            {
                CarregarMensagensDeValidacao();
                return RedirectToAction("ToDoList");
            }

        }

        public void CarregarMensagensDeValidacao()
        {
            TempData["errors"] = _validationService.MessagesValidationList;
        }
    }
}
