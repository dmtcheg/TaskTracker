using System;
using System.Collections.Generic;
using System.Linq;
using TaskTracker.Core.Models;

namespace TaskTracker.Core
{
    public static class ProjectService
    {
        public static IEnumerable<Project> DateFilter(List<Project> projects,
            DateTime startAt=default,
            DateTime endAt=default,
            int priority = -1)
        {
            IEnumerable<Project> result = new List<Project>();
            if (startAt != default)
                result = projects.Where(p => p.StartDate == startAt);
            if (endAt != default)
                result = projects.Where(p => p.CompletionDate == endAt);
            if (priority > -1)
                result = projects.Where(p => p.Priority == priority);
            return result;
        }
    }
}