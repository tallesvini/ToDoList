using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Domain.Entities;

namespace TodoList.Infra.Data.Configuration
{
	public class ToDoListConfiguration : IEntityTypeConfiguration<ToDoList>
	{
		public void Configure(EntityTypeBuilder<ToDoList> builder)
		{
			builder.ToTable("TODOLIST");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("TODOLIST_ID").ValueGeneratedOnAdd();
			builder.Property(x => x.Title).HasColumnName("TITLE").HasMaxLength(255).IsRequired();
			builder.Property(x => x.Description).HasColumnName("DESCRIPTION").HasMaxLength(255).IsRequired();
			builder.Property(x => x.StartDate).HasColumnName("START_DATE").IsRequired();
			builder.Property(x => x.EndDate).HasColumnName("END_DATE");
			builder.Property(x => x.Status).HasColumnName("STATUS").IsRequired();
			builder.Property(x => x.UserId).HasColumnName("USER_ID").IsRequired();

			builder.HasOne<User>(x => x.User)
				.WithMany(y => y.ToDoLists)
					.HasForeignKey(j => j.UserId);
		}
	}
}
