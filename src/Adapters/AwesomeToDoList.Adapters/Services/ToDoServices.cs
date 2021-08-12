using AutoMapper;
using AwesomeTodoList.Domain.Entities;
using AwesomeTodoList.Domain.UseCases.Facade;
using AwesomeToDoList.Adapters.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeToDoList.Adapters.Services
{
    public class ToDoServices : IToDoServices
    {
        private readonly IToDoFacade _toDoFacade;
        private readonly IMapper _mapper;

        public ToDoServices(IToDoFacade toDoFacade, IMapper mapper)
        {
            _toDoFacade = toDoFacade;
            _mapper = mapper;
        }

        public async Task<ToDoViewModel> AddToDo(ToDoViewModel todoViewModel)
        {
            var toDo = await _toDoFacade.AddToDo(todoViewModel.Name, todoViewModel.Description, todoViewModel.Prevision);

            return ToDoToToDoViewModel(toDo);
        }

        public async Task<ToDoViewModel> FinishToDo(Guid toDoId)
        {
            var toDo = await _toDoFacade.FinishToDo(toDoId);

            return ToDoToToDoViewModel(toDo);
        }

        public async Task<ToDoViewModel> GetToDo(Guid toDoId)
        {
            var toDo = await _toDoFacade.GetToDo(toDoId);

            return ToDoToToDoViewModel(toDo);
        }

        public async Task<ICollection<ToDoViewModel>> GetToDoList()
        {
            var toDo = await _toDoFacade.GetToDoList();

            return ToDoToToDoViewModel(toDo);
        }

        public async Task RemoveToDo(Guid toDoId)
        {
            await _toDoFacade.RemoveToDo(toDoId);
        }

        public async Task<ToDoViewModel> RenameToDo(Guid toDoId, string name)
        {
            var toDo = await _toDoFacade.RenameToDo(toDoId, name);

            return ToDoToToDoViewModel(toDo);
        }

        public async Task<ToDoViewModel> ReopenToDo(Guid toDoId)
        {
            var toDo = await _toDoFacade.ReopenToDo(toDoId);

            return ToDoToToDoViewModel(toDo);
        }

        public async Task<ToDoViewModel> UpdateDescriptionToDo(Guid toDoId, string description)
        {
            var toDo = await _toDoFacade.UpdateDescriptionToDo(toDoId, description);

            return ToDoToToDoViewModel(toDo);
        }

        public async Task<ToDoViewModel> UpdateToDo(Guid toDoId, string name, string description)
        {
            var toDo = await _toDoFacade.UpdateToDo(toDoId, name, description);

            return ToDoToToDoViewModel(toDo);
        }

        private ToDoViewModel ToDoToToDoViewModel(ToDo toDo)
        {
            return _mapper.Map<ToDoViewModel>(toDo);
        }

        private ICollection<ToDoViewModel> ToDoToToDoViewModel(IEnumerable<ToDo> toDo)
        {
            return _mapper.Map<ICollection<ToDoViewModel>>(toDo);
        }
    }
}
