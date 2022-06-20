using System.Text.Json.Serialization;

namespace TaskManager.Data
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public bool IsCompleted { get; set; }
    }
}

