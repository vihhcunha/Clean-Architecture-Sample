using System.Collections.Generic;

namespace AwesomeTodoList.Domain.CommonObjects
{
    public interface ICommand
    {
        List<string> ValidationMessages { get; }
        bool IsValid();
    }

    public interface ICommand<out TResponse>
    {
        List<string> ValidationMessages { get; }
        bool IsValid();
    }
}
