using AutoMapper;
using AwesomeTodoList.Domain.Entities;
using AwesomeToDoList.Adapters.ViewModels;

namespace AwesomeToDoList.Adapters.MappingProfile
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDo, ToDoViewModel>();
        }
    }
}
