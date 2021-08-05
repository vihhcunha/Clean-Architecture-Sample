using AwesomeTodoList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeTodoList.Domain.UseCases.Facade
{
    public interface IToDoFacade
    {
        Task<ToDo> AddToDo(string name, string description, DateTime? prevision = null);
        Task<ToDo> FinishToDo(Guid toDoId);
        Task<ToDo> ReopenToDo(Guid toDoId);
        Task<ToDo> RenameToDo(Guid toDoId, string name);
        Task<ToDo> UpdateDescriptionToDo(Guid toDoId, string description);
        Task RemoveToDo(Guid toDoId);
        Task<ToDo> GetToDo(Guid toDoId);
        Task<ICollection<ToDo>> GetToDoList();
    }
}
