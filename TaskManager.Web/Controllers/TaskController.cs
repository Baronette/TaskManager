using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Data;

namespace TaskManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IHubContext<TaskHub> _context;
        private readonly string _connection;

        public TaskController(IHubContext<TaskHub> context, IConfiguration configuration)
        {
            _context = context;
            _connection = configuration.GetConnectionString("ConStr");
        }

        [HttpPost]
        [Route("addtask")]
        public void AddTask(string title)
        {
            var repo = new TaskRepository(_connection);
            var task = new TaskItem
            {
                Title = title
            };
            repo.AddTask(task);
            _context.Clients.All.SendAsync("new-task", task);
        }
    }
}
