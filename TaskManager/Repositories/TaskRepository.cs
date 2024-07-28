// Esse arquivo implementa a interface usando uma lista de memoria por ser mais facil de implementar
using Task = TaskManager.Models.Task;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly List<Task> _tasks = new List<Task>(); // lista na memoria que armazena as tarefas

        // Adicionando uma tarefa na lista
        public void AddTask(Task task)
        {
            _tasks.Add(task);
        }

        // Removendo uma tarefa da lista
        public void RemoveTask(int taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }

        // Atualizando a lista de tarefas
        public void UpdateTask(Task task)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.DueDate = task.DueDate;
                existingTask.Priority = task.Priority;
            }
        }


        // listando todas as tarefas na lista
        public IEnumerable<Task> GetAllTasks()
        {
            return _tasks;
        }


        // retorna uma tarefa especifica pelo seu id, caso nao seja encontrado retorna null
        public Task? GetTaskById(int taskId)
        {
            return _tasks.FirstOrDefault(t => t.Id == taskId);
        }
    }
}
