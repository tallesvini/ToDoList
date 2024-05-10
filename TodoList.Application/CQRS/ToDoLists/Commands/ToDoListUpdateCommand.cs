namespace TodoList.Application.CQRS.ToDoLists.Commands
{
    public class ToDoListUpdateCommand : ToDoListCommand
	{
        public Guid Id { get; set; }
	}
}
