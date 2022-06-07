using System.Threading.Tasks;

namespace AwesomeTodoList.Domain.CommonObjects
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }

    public interface ICommandHandler<in TCommand, out TResponse> where TCommand : ICommand<TResponse>
    {
        TResponse Handle(TCommand command);
    }
}
