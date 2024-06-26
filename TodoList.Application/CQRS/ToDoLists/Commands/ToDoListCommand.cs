﻿using MediatR;
using TodoList.Domain.Entities;
using TodoList.Domain.Enum;

namespace TodoList.Application.CQRS.ToDoLists.Commands
{
	public class ToDoListCommand : IRequest<ToDoList>
	{
        public string Title { get; set; }
		public string Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public StatusEnum Status { get; set; }
	}
}
