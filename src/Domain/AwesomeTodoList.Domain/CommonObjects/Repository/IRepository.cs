using System;

namespace AwesomeTodoList.Domain.CommonObjects
{
    public interface IRepository : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
