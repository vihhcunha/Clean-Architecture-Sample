using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeTodoList.Domain.UseCases.Commands
{
    public class UpdateToDoCommand : ICommand<Task<ToDo>>
    {
        public List<string> ValidationMessages { get; } = new List<string>();

        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public string Name { get; private set; }

        public UpdateToDoCommand(Guid id, string description, string name)
        {
            Id = id;
            Description = description;
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
