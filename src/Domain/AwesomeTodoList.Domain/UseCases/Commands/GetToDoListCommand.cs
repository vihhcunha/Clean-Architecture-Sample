using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.Entities;
using System.Collections.Generic;
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
