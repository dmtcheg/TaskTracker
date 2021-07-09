namespace TaskTracker.Core.Models
{
    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Done
    }

    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public TaskStatus Status { get; set; }
        public Project Project { get; }
    }
}