using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeTodoList.Domain.Repository
{
    public interface IToDoRepository : IRepository
    {
        Task AddToDo(ToDo toDo);
        Task DeleteToDo(Guid id);
        Task<ToDo> GetToDo(Guid id);
        Task<List<ToDo>> GetToDoList();
    }
}
