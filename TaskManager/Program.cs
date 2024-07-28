using Task = TaskManager.Models.Task;
using TaskManager.Repositories;
using TaskManager.Services;
using System;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            ITaskRepository taskRepository = new TaskRepository();
            TaskService taskService = new TaskService(taskRepository);

            while (true)
            {
                Console.WriteLine("1. Adicionar tarefa");
                Console.WriteLine("2. Remover tarefa");
                Console.WriteLine("3. Atualizar tarefa");
                Console.WriteLine("4. Lista de tarefas");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddTask(taskService);
                        break;
                    case "2":
                        RemoveTask(taskService);
                        break;
                    case "3":
                        UpdateTask(taskService);
                        break;
                    case "4":
                        ListAllTasks(taskService);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("ERRO! Opção inválida.");
                        break;
                }
            }
        }

        static void AddTask(TaskService taskService)
        {
            var task = new Task
            { // inicializacao obrigatoria
                Title = string.Empty,
                Description = string.Empty
            };

            Console.Write("Digite o ID da tarefa: ");
            task.Id = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Digite o nome da tarefa: ");
            task.Title = Console.ReadLine() ?? string.Empty;
            Console.Write("Digite a descrição da tarefa: ");
            task.Description = Console.ReadLine() ?? string.Empty;
            Console.Write("Digite a data da tarefa(yyyy-MM-dd): ");
            task.DueDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Digite a prioridade da tarefa: ");
            task.Priority = int.Parse(Console.ReadLine() ?? string.Empty);

            taskService.AddTask(task);
            Console.WriteLine("Tarefa adicionada na lista!!!");
        }

        static void RemoveTask(TaskService taskService)
        {
            Console.Write("Digite o ID da tarefa para remover: ");
            int taskId = int.Parse(Console.ReadLine() ?? string.Empty);
            taskService.RemoveTask(taskId);
            Console.WriteLine("Tarefa removida!!!");
        }

        static void UpdateTask(TaskService taskService)
        {
            var task = new Task
            {// inicializacao obrigatoria
                Title = string.Empty, 
                Description = string.Empty
            };

            Console.Write("Digite um ID de tarefa para atualizar: ");
            task.Id = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Digite o novo nome da tarefa: ");
            task.Title = Console.ReadLine() ?? string.Empty;
            Console.Write("Digite uma nova descricao para a tarefa: ");
            task.Description = Console.ReadLine() ?? string.Empty;
            Console.Write("Digite uma nova data para a tarefa(yyyy-MM-dd): ");
            task.DueDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Digite uma nova prioridade para a tarefa: ");
            task.Priority = int.Parse(Console.ReadLine() ?? string.Empty);

            taskService.UpdateTask(task);
            Console.WriteLine("Tarefa atualizada!!!");
        }

        static void ListAllTasks(TaskService taskService)
        {
            var tasks = taskService.GetAllTasks();
            foreach (var task in tasks)
            {
                Console.WriteLine($"ID: {task.Id}, Nome: {task.Title}, Descrição: {task.Description}, Data limite: {task.DueDate}, Prioridade: {task.Priority}");
            }
        }
    }
}
