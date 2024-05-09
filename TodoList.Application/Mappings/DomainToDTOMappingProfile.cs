using AutoMapper;
using TodoList.Application.DTOs;
using TodoList.Domain.Entities;

namespace TodoList.Application.Mappings
{
	public class DomainToDTOMappingProfile : Profile
	{
        public DomainToDTOMappingProfile()
        {
            CreateMap<ToDoList, ToDoListDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
