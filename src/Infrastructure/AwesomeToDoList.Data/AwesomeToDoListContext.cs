using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading.Tasks;

namespace AwesomeToDoList.Data
{
    public class AwesomeToDoListContext : DbContext, IUnitOfWork
    {
        public AwesomeToDoListContext() { }

        public AwesomeToDoListContext(DbContextOptions<AwesomeToDoListContext> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }

        public async Task Commit()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(AwesomeToDoListContext)));
            base.OnModelCreating(modelBuilder);
        }
    }
}
