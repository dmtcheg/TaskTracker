using System;
using System.Collections.Generic;

namespace TaskTracker.Core.Models
{
    public enum ProjectStatus
    {
        NotStarted,
        Active,
        Completed
    }
    
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public int Priority { get; set; }
        public ProjectStatus Status { get; set; }
        public List<Task> Tasks { get; set; }
    }
}