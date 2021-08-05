using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.CommonObjects.Validation;
using AwesomeTodoList.Domain.Entities;
using AwesomeTodoList.Domain.Repository;
using AwesomeTodoList.Domain.UseCases.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeTodoList.Domain.UseCases.Facade
{
    public class ToDoFacade : IToDoFacade
    {
        private readonly ICommandHandler<AddToDoCommand, Task<ToDo>> _addToDoCommandHandler;
        private readonly ICommandHandler<FinishToDoCommand, Task<ToDo>> _finishToDoCommandHandler;
        private readonly ICommandHandler<GetToDoCommand, Task<ToDo>> _getToDoCommandHandler;
        private readonly ICommandHandler<GetToDoListCommand, Task<List<ToDo>>> _getListToDoCommandHandler;
        private readonly ICommandHandler<RemoveToDoCommand, Task> _removeToDoCommandHandler;
        private readonly ICommandHandler<RenameToDoCommand, Task<ToDo>> _renameToDoCommandHandler;
        private readonly ICommandHandler<ReopenToDoCommand, Task<ToDo>> _reopenToDoCommandHandler;
        private readonly ICommandHandler<UpdateDescriptionToDoCommand, Task<ToDo>> _updateDescriptionToDoCommandHandler;

        public ToDoFacade(ICommandHandler<AddToDoCommand, Task<ToDo>> addToDoCommandHandler, 
            ICommandHandler<FinishToDoCommand, Task<ToDo>> finishToDoCommandHandler, 
            ICommandHandler<GetToDoCommand, Task<ToDo>> getToDoCommandHandler, 
            ICommandHandler<GetToDoListCommand, Task<List<ToDo>>> getListToDoCommandHandler, 
            ICommandHandler<RemoveToDoCommand, Task> removeToDoCommandHandler, 
            ICommandHandler<RenameToDoCommand, Task<ToDo>> renameToDoCommandHandler, 
            ICommandHandler<ReopenToDoCommand, Task<ToDo>> reopenToDoCommandHandler, 
            ICommandHandler<UpdateDescriptionToDoCommand, Task<ToDo>> updateDescriptionToDoCommandHandler)
        {
            _addToDoCommandHandler = addToDoCommandHandler;
            _finishToDoCommandHandler = finishToDoCommandHandler;
            _getToDoCommandHandler = getToDoCommandHandler;
            _getListToDoCommandHandler = getListToDoCommandHandler;
            _removeToDoCommandHandler = removeToDoCommandHandler;
            _renameToDoCommandHandler = renameToDoCommandHandler;
            _reopenToDoCommandHandler = reopenToDoCommandHandler;
            _updateDescriptionToDoCommandHandler = updateDescriptionToDoCommandHandler;
        }

        public async Task<ToDo> AddToDo(string name, string description, DateTime? prevision = null)
        {
            var command = new AddToDoCommand(name, description, prevision);
            return await _addToDoCommandHandler.Handle(command);
        }

        public async Task<ToDo> FinishToDo(Guid toDoId)
        {
            var command = new FinishToDoCommand(toDoId);
            return await _finishToDoCommandHandler.Handle(command);
        }

        public async Task RemoveToDo(Guid toDoId)
        {
            var removeCommand = new RemoveToDoCommand(toDoId);
            await _removeToDoCommandHandler.Handle(removeCommand);
        }

        public async Task<ToDo> RenameToDo(Guid toDoId, string name)
        {
            var command = new RenameToDoCommand (toDoId, name);
            return await _renameToDoCommandHandler.Handle(command);
        }

        public async Task<ToDo> ReopenToDo(Guid toDoId)
        {
            var command = new ReopenToDoCommand(toDoId);
            return await _reopenToDoCommandHandler.Handle(command);
        }

        public async Task<ToDo> UpdateDescriptionToDo(Guid toDoId, string description)
        {
            var command = new UpdateDescriptionToDoCommand(toDoId, description);
            return await _updateDescriptionToDoCommandHandler.Handle(command);
        }

        public async Task<ToDo> GetToDo(Guid toDoId)
        {
            var command = new GetToDoCommand(toDoId);
            return await _getToDoCommandHandler.Handle(command);
        }

        public async Task<ICollection<ToDo>> GetToDoList()
        {
            var command = new GetToDoListCommand();
            return await _getListToDoCommandHandler.Handle(command);
        }
    }
}
