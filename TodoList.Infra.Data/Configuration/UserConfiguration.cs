using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Domain.Entities;

namespace TodoList.Infra.Data.Configuration
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("USER");

			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("USER_ID").ValueGeneratedOnAdd();
			builder.Property(x => x.UserName).HasColumnName("USERNAME").HasMaxLength(255).IsRequired();
			builder.Property(x => x.PassWord).HasColumnName("PASSWORD").HasMaxLength(255).IsRequired();
			builder.Property(x => x.Role).HasColumnName("ROLE").IsRequired();
		}
	}
}
