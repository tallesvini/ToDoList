namespace TodoList.Application.CQRS.Users.Command
{
    public class UserUpdateCommand : UserCommand
    {
        public Guid Id { get; set; }
    }
}
