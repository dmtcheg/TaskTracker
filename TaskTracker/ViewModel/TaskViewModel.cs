using TaskTracker.Core.Models;

namespace TaskTracker.ViewModel
{
    public class TaskViewModel
    {
        public TaskViewModel(Task t)
        {
            Id = t.Id;
            Name = t.Name;
            Description = t.Description;
            Priority = t.Priority;
            ProjectId = t.Project.Id;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public TaskStatus Status { get; set; }
        public int ProjectId { get; set; }
    }
}