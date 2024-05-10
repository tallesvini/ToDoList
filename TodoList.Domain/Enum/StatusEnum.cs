using System.ComponentModel;

namespace TodoList.Domain.Enum
{
	public enum StatusEnum
	{
		[Description("Pendente")]
		Pendente = 1,

		[Description("Concluído")]
		Concluido = 2,

		[Description("Em Andamento")]
		Andamento = 3
	}
}
