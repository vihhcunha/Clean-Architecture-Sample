using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.CommonObjects.Validation;
using AwesomeTodoList.Domain.Entities;
using AwesomeTodoList.Domain.Repository;
using AwesomeTodoList.Domain.UseCases.Commands;
using AwesomeTodoList.Domain.UseCases.Facade;
using AwesomeTodoList.Domain.UseCases.Handler;
using AwesomeToDoList.Adapters.Services;
using AwesomeToDoList.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwesomeTodoList.ServicesConfiguration
{
    public static class DependencyInjection
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IToDoServices, ToDoServices>();
            services.AddScoped<IToDoRepository, ToDoRepository>();
            services.AddScoped<IToDoFacade, ToDoFacade>();
            services.AddScoped<IValidationService, ValidationService>();

            services.AddScoped<ICommandHandler<AddToDoCommand, Task<ToDo>>, ToDoCommandHandler>();
            services.AddScoped<ICommandHandler<FinishToDoCommand, Task<ToDo>>, ToDoCommandHandler>();
            services.AddScoped<ICommandHandler<GetToDoCommand, Task<ToDo>>, ToDoCommandHandler>();
            services.AddScoped<ICommandHandler<GetToDoListCommand, Task<List<ToDo>>>, ToDoCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveToDoCommand, Task>, ToDoCommandHandler>();
            services.AddScoped<ICommandHandler<RenameToDoCommand, Task<ToDo>>, ToDoCommandHandler>();
            services.AddScoped<ICommandHandler<ReopenToDoCommand, Task<ToDo>>, ToDoCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateDescriptionToDoCommand, Task<ToDo>>, ToDoCommandHandler>();
        }

    }
}
