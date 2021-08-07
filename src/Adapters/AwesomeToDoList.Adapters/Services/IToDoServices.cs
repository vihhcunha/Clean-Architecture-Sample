using AwesomeTodoList.Domain.Entities;
using AwesomeToDoList.Adapters.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeToDoList.Adapters.Services
{
    public interface IToDoServices
    {
        Task<ToDoViewModel> AddToDo(ToDoViewModel todoViewModel);
        Task<ToDoViewModel> FinishToDo(Guid toDoId);
        Task<ToDoViewModel> ReopenToDo(Guid toDoId);
        Task<ToDoViewModel> RenameToDo(Guid toDoId, string name);
        Task<ToDoViewModel> UpdateDescriptionToDo(Guid toDoId, string description);
        Task RemoveToDo(Guid toDoId);
        Task<ToDoViewModel> GetToDo(Guid toDoId);
        Task<ICollection<ToDoViewModel>> GetToDoList();
    }
}
