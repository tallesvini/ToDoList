using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.Application.DTOs;

namespace TodoList.UiWeb.Data
{
    public class TodoListUiWebContext : DbContext
    {
        public TodoListUiWebContext (DbContextOptions<TodoListUiWebContext> options)
            : base(options)
        {
        }

        public DbSet<TodoList.Application.DTOs.ToDoListDTO> ToDoListDTO { get; set; } = default!;
    }
}
