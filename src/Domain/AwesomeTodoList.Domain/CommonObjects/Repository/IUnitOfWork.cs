using System.Threading.Tasks;

namespace AwesomeTodoList.Domain.CommonObjects
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
