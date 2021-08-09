using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.Entities;
using AwesomeTodoList.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeToDoList.Data.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly AwesomeToDoListContext _context;

        public ToDoRepository(AwesomeToDoListContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task AddToDo(ToDo toDo)
        {
            await _context.ToDos.AddAsync(toDo);
        }

        public async Task DeleteToDo(Guid id)
        {
            var toDo = await _context.ToDos.FirstOrDefaultAsync(x => x.IdToDo.Equals(id));

            _context.ToDos.Remove(toDo);
        }

        public async Task<ToDo> GetToDo(Guid id)
        {
            return await _context.ToDos.FirstOrDefaultAsync(x => x.IdToDo.Equals(id));
        }

        public async Task<List<ToDo>> GetToDoList()
        {
            return await _context.ToDos.ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
