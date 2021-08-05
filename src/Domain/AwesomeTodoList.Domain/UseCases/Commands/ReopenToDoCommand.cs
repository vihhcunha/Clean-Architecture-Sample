using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeTodoList.Domain.UseCases.Commands
{
    public class ReopenToDoCommand : ICommand<Task<ToDo>>
    {
        public List<string> ValidationMessages { get; } = new List<string>();

        public Guid Id { get; private set; }

        public ReopenToDoCommand(Guid id)
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
