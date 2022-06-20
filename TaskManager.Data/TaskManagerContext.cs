using Microsoft.EntityFrameworkCore;

namespace TaskManager.Data
{
    public class TaskManagerContext : DbContext
    {
        private readonly string _connection;

        public TaskManagerContext(string connection)
        {
            _connection = connection;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
    }
}

