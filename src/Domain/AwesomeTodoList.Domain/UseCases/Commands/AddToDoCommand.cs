using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwesomeTodoList.Domain.UseCases.Commands
{
    public class AddToDoCommand : ICommand<Task<ToDo>>
    {
        public AddToDoCommand(string name, string description, DateTime? prevision = null)
        {
            Name = name;
            Description = description;
            Prevision = prevision;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime? Prevision { get; private set; }

        public List<string> ValidationMessages { get; } = new List<string>();   

        public bool IsValid()
        {
            if (String.IsNullOrEmpty(Name))
                ValidationMessages.Add("Nome precisa ser preenchido!");

            return ValidationMessages.Count == 0;
        }
    }
}
