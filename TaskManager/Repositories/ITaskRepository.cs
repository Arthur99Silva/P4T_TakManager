// Esse arquivo faz referencia a interface do algoritmo
using Task = TaskManager.Models.Task;
using System.Collections.Generic;

namespace TaskManager.Repositories
{
    public interface ITaskRepository
    { // Foram definidos metodos de adicionar, remover, atualizar e listar tarefas
        void AddTask(Task task);
        void RemoveTask(int taskId);
        void UpdateTask(Task task);
        IEnumerable<Task> GetAllTasks();
        Task GetTaskById(int taskId);
    }
}
