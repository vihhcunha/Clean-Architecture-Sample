using AutoMapper;
using AwesomeTodoList.Domain.Entities;
using AwesomeToDoList.Adapters.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
