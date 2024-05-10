using AutoMapper;
using TodoList.Application.CQRS.ToDoLists.Commands;
using TodoList.Application.DTOs;

namespace TodoList.Application.Mappings
{
    public class DTOToCommandMappingProfille : Profile
    {
        public DTOToCommandMappingProfille()
        {
            CreateMap<ToDoListDTO, ToDoListCreateCommand>();
            CreateMap<ToDoListDTO, ToDoListUpdateCommand>();
            CreateMap<IEnumerable<ToDoListDTO>, ToDoListDeleteAllCommand>();
        }
    }
}
