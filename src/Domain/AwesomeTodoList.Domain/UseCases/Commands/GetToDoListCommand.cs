using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeTodoList.Domain.UseCases.Commands
{
    public class GetToDoListCommand : ICommand<Task<List<ToDo>>>
    {
        public List<string> ValidationMessages { get; } = new List<string>();

        public bool IsValid()
        {
            return true;
        }
    }
}
