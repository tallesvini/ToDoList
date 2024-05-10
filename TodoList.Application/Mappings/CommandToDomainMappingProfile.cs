using AutoMapper;
using TodoList.Application.CQRS.ToDoLists.Commands;
using TodoList.Domain.Entities;

namespace TodoList.Application.Mappings
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<ToDoListCreateCommand, ToDoList>();
            CreateMap<ToDoListUpdateCommand, ToDoList>();
            CreateMap<ToDoListDeleteAllCommand, ToDoList>();
        }
    }
}
