using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.CommonObjects.Exceptions;
using AwesomeTodoList.Domain.CommonObjects.Validation;
using AwesomeTodoList.Domain.Entities;
using AwesomeTodoList.Domain.Repository;
using AwesomeTodoList.Domain.UseCases.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeTodoList.Domain.UseCases.Handler
{
    public class ToDoCommandHandler : ICommandHandler<AddToDoCommand, Task<ToDo>>,
                                      ICommandHandler<FinishToDoCommand, Task<ToDo>>,
                                      ICommandHandler<GetToDoCommand, Task<ToDo>>,
                                      ICommandHandler<GetToDoListCommand, Task<List<ToDo>>>,
                                      ICommandHandler<RemoveToDoCommand, Task>,
                                      ICommandHandler<RenameToDoCommand, Task<ToDo>>,
                                      ICommandHandler<ReopenToDoCommand, Task<ToDo>>,
                                      ICommandHandler<UpdateDescriptionToDoCommand, Task<ToDo>>,
                                      ICommandHandler<UpdateToDoCommand, Task<ToDo>>
    {
        private readonly IToDoRepository _repository;
        private readonly IValidationService _validationService;

        public ToDoCommandHandler(IToDoRepository repository, IValidationService validationService)
        {
            _repository = repository;
            _validationService = validationService;
        }

        public async Task<ToDo> Handle(AddToDoCommand command)
        {
            if (command.IsValid() is false)
                HandleValidationMessages(command.ValidationMessages);

            var toDo = new ToDo(command.Name, command.Description, command.Prevision);

            await _repository.AddToDo(toDo);
            await _repository.UnitOfWork.Commit();

            return toDo;
        }

        public async Task<ToDo> Handle(FinishToDoCommand command)
        {
            if (command.IsValid() is false)
                HandleValidationMessages(command.ValidationMessages);

            var toDo = await _repository.GetToDo(command.Id);

            if (toDo is null)
                throw new DomainException("Essa tarefa não existe!");

            toDo.FinishTask();
            await _repository.UnitOfWork.Commit();

            return toDo;
        }

        public async Task<ToDo> Handle(GetToDoCommand command)
        {
            if (command.IsValid() is false)
                HandleValidationMessages(command.ValidationMessages);

            return await _repository.GetToDo(command.Id);
        }

        public async Task<List<ToDo>> Handle(GetToDoListCommand command)
        {
            if (command.IsValid() is false)
                HandleValidationMessages(command.ValidationMessages);

            return await _repository.GetToDoList();
        }

        public async Task<ToDo> Handle(RenameToDoCommand command)
        {
            if (command.IsValid() is false)
                HandleValidationMessages(command.ValidationMessages);

            var toDo = await _repository.GetToDo(command.Id);

            if (toDo is null)
                throw new DomainException("Essa tarefa não existe!");

            toDo.Rename(command.Name);
            await _repository.UnitOfWork.Commit();

            return toDo;
        }

        public async Task<ToDo> Handle(ReopenToDoCommand command)
        {
            if (command.IsValid() is false)
                HandleValidationMessages(command.ValidationMessages);

            var toDo = await _repository.GetToDo(command.Id);

            if (toDo is null)
                throw new DomainException("Essa tarefa não existe!");

            toDo.ReopenTask();
            await _repository.UnitOfWork.Commit();

            return toDo;
        }

        public async Task<ToDo> Handle(UpdateDescriptionToDoCommand command)
        {
            if (command.IsValid() is false)
                HandleValidationMessages(command.ValidationMessages);

            var toDo = await _repository.GetToDo(command.Id);

            if (toDo is null)
                throw new DomainException("Essa tarefa não existe!");

            toDo.UpdateDescription(command.Description);
            await _repository.UnitOfWork.Commit();

            return toDo;
        }

        public async Task Handle(RemoveToDoCommand command)
        {
            if (command.IsValid() is false)
                HandleValidationMessages(command.ValidationMessages);

            await _repository.DeleteToDo(command.Id);
            await _repository.UnitOfWork.Commit();
        }

        public async Task<ToDo> Handle(UpdateToDoCommand command)
        {
            if (command.IsValid() is false)
                HandleValidationMessages(command.ValidationMessages);

            var toDo = await _repository.GetToDo(command.Id);

            if (toDo is null)
                throw new DomainException("Essa tarefa não existe!");

            toDo.UpdateDescription(command.Description);
            toDo.Rename(command.Name);
            await _repository.UnitOfWork.Commit();

            return toDo;
        }

        private void HandleValidationMessages(List<string> validationMessages)
        {
            _validationService.AddValidationMessage(validationMessages);
            throw new DomainException("Há problemas no comando. Veja as mensagens de validação!");
        }
    }
}
