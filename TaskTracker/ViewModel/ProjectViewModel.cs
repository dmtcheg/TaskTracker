using System;
using TaskTracker.Core;
using TaskTracker.Core.Models;

namespace TaskTracker.ViewModel
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public int Priority { get; set; }

        public ProjectViewModel(Project proj)
        {
            Id = proj.Id;
            Name = proj.Name;
            StartDate = proj.StartDate;
            CompletionDate = proj.CompletionDate;
            Priority = proj.Priority;
        }
    }
}