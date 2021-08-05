using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
