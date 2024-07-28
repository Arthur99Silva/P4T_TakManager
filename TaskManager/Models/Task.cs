// Nesse arquivo foi feito a modelagem de dados
namespace TaskManager.Models
{
    public class Task
    { // Aqui criamos a classe Task onde estao os atributos pedidos
        public int Id { get; set; }
        public required string Title { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; } // Data de vencimento da tarefa
        public int Priority { get; set; }
    }
}
