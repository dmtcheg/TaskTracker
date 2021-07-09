using System.Collections.Generic;
using TaskTracker.Core.Models;

namespace TaskTracker.Core
{
    public static class ProjectService
    {
        public static void RemoveTask(this Project proj, Task t)
        {
            proj.Tasks.Remove(t);
        }
        public static List<Task> AllSubtask(this Project proj)
        {
            return proj.Tasks;
        }

        // todo: фильтровать разными способами (< > = between) по разным полям
        // public static List<Project> DateFilter()
        // {
        // }
    }
}