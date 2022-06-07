using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwesomeTodoList.Domain.UseCases.Commands
{
    public class RenameToDoCommand : ICommand<Task<ToDo>>
    {
        public List<string> ValidationMessages { get; } = new List<string>();

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public RenameToDoCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public bool IsValid()
        {
            if (Id == Guid.Empty)
                ValidationMessages.Add("Defina um Id do ToDo válido!");

            if (String.IsNullOrEmpty(Name))
                ValidationMessages.Add("Defina um nome válido!");

            return ValidationMessages.Count == 0;
        }
    }
}
