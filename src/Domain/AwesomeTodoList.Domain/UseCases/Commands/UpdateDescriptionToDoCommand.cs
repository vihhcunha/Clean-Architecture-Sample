using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeTodoList.Domain.UseCases.Commands
{
    public class UpdateDescriptionToDoCommand : ICommand<Task<ToDo>>
    {
        public List<string> ValidationMessages { get; } = new List<string>();

        public Guid Id { get; private set; }
        public string Description { get; private set; }

        public UpdateDescriptionToDoCommand(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public bool IsValid()
        {
            if (Id == Guid.Empty)
                ValidationMessages.Add("Defina um Id do ToDo válido!");

            return ValidationMessages.Count == 0;
        }
    }
}
