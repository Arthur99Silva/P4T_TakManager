// Esse arquivo faz referencia a Camada de Serviços
using Task = TaskManager.Models.Task;
using TaskManager.Repositories;
using System.Collections.Generic;

namespace TaskManager.Services
{ // construtor para receber uma instancia de ITaskRepository
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void AddTask(Task task)
        { //add nova tarefa
            _taskRepository.AddTask(task);
        }

        public void RemoveTask(int taskId)
        { // remove tarefa pelo Id
            _taskRepository.RemoveTask(taskId);
        }

        public void UpdateTask(Task task)
        { // atualiza uma tarefa existente
            _taskRepository.UpdateTask(task);
        }

        public IEnumerable<Task> GetAllTasks()
        { // retorna todas as tarefas
            return _taskRepository.GetAllTasks();
        }

        public Task GetTaskById(int taskId)
        { // retorna uma tarefa pelo id
            return _taskRepository.GetTaskById(taskId);
        }
    }
}
