using AwesomeTodoList.Domain.CommonObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwesomeTodoList.Domain.UseCases.Commands
{
    public class RemoveToDoCommand : ICommand<Task>
    {
        public List<string> ValidationMessages { get; } = new List<string>();

        public Guid Id { get; private set; }

        public RemoveToDoCommand(Guid id)
        {
            Id = id;
        }

        public bool IsValid()
        {
            if (Id == Guid.Empty)
                ValidationMessages.Add("Defina um Id do ToDo válido!");

            return ValidationMessages.Count == 0;
        }
    }
}
