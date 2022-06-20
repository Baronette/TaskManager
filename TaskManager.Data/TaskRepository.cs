using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager.Data
{
    public class TaskRepository
    {
        private readonly string _connection;

        public TaskRepository(string connection)
        {
            _connection = connection;
        }
        public void AddTask(TaskItem task)
        {
            using var context = new TaskManagerContext(_connection);
            context.Tasks.Add(task);
            context.SaveChanges();
        }
        public List<TaskItem> GetTasks()
        {
            using var context = new TaskManagerContext(_connection);
            return context.Tasks.Where(t => !t.IsCompleted).Include(t => t.User).ToList();
        }
        public void SetTaskTaken(int id, int userId)
        {
            using var context = new TaskManagerContext(_connection);
            var task = context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return;
            }
            task.UserId = userId;
            context.SaveChanges();
        }
        public void MarkCompleted(int id)
        {
            using var context = new TaskManagerContext(_connection);
            var task = context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return;
            }
            task.IsCompleted = true;
            context.SaveChanges();
        }
    }
}


