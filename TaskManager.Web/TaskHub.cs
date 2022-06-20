using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Data;

namespace TaskManager.Web
{
    public class TaskHub : Hub
    {
        private readonly string _connection;

        public TaskHub(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("ConStr");
        }
        public void NewTask(TaskItem task)
        {
            var repo = new TaskRepository(_connection);
            repo.AddTask(task);
            Clients.All.SendAsync("new-task", task);
        }
        public void OnLogin()
        {
            var repo = new TaskRepository(_connection);
            Clients.Caller.SendAsync("tasks", repo.GetTasks());
        }
        public void GetTasks()
        {
            var repo = new TaskRepository(_connection);
            Clients.All.SendAsync("tasks", repo.GetTasks());
        }
        public void TakeTask(TaskItem task)
        {
            var accountRepo = new AccountRepository(_connection);
            var user = accountRepo.GetUser(Context.User.Identity.Name);
            var repo = new TaskRepository(_connection);
            repo.SetTaskTaken(task.Id, user.Id);
            GetTasks();
        }
        public void CompleteTask(TaskItem task)
        {
            var repo = new TaskRepository(_connection);
            repo.MarkCompleted(task.Id);
            GetTasks();
        }

    }
}
