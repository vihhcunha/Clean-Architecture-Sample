using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.CommonObjects.Validation;
using AwesomeTodoList.Domain.Entities;
using AwesomeTodoList.Domain.Repository;
using AwesomeTodoList.Domain.UseCases;
using AwesomeTodoList.Domain.UseCases.Commands;
using AwesomeTodoList.Domain.UseCases.Facade;
using AwesomeTodoList.Domain.UseCases.Handler;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ObserverTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var validation = serviceProvider.GetService<IValidationService>();
            var toDoFacade = serviceProvider.GetService<IToDoFacade>();

            var test = new Test(toDoFacade, validation);
            test.CallCommand().ConfigureAwait(true).GetAwaiter();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IToDoFacade, ToDoFacade>();
            services.AddScoped<IToDoRepository, RepositoryFake>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped(typeof(ICommandHandler<AddToDoCommand, Task<ToDo>>), typeof(ToDoCommandHandler));
            services.AddScoped(typeof(ICommandHandler<FinishToDoCommand, Task<ToDo>>), typeof(ToDoCommandHandler));
        }
    }
}
