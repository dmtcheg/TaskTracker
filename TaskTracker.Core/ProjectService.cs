using System;
using System.Collections.Generic;
using System.Linq;
using TaskTracker.Core.Models;

namespace TaskTracker.Core
{
    public static class ProjectService
    {
        // range <=> start!=default && end!=default.
        // in other cases only one param may be != default
        public static IEnumerable<Project> DateFilter(IEnumerable<Project> projects, string option,
            DateTime start = default, DateTime end = default) =>
            option switch
            {
                "range" when (start != default && end != default) => projects.Where(p =>
                    p.StartDate >= start && p.CompletionDate <= end),
                "before" when (start != default) => projects.Where(p => p.StartDate <= start),
                "before" when (end != default) => projects.Where(p => p.CompletionDate <= end),
                "after" when (start != default) => projects.Where(p => p.StartDate >= start),
                "after" when (end != default) => projects.Where(p => p.CompletionDate >= end),
                "at" when (start != default) => projects.Where(p => p.StartDate == end),
                "at" when (end != default) => projects.Where(p => p.CompletionDate == end),
                _ => throw new ArgumentException("wrong method option", nameof(option))
            };

        public static IEnumerable<Project> PriorityFilter(IEnumerable<Project> projects, string option, int priority) =>
            option switch
            {
                "not less"=>projects.Where(p=>p.Priority>=priority),
                "exact"=>projects.Where(p=>p.Priority == priority),
                "not greater" => projects.Where(p=>p.Priority<= priority),
                _ => throw new ArgumentException("wrong method option", nameof(option))
            };

        public static List<Project> Sort(List<Project> projects)
        {
            projects.Sort(CompareProjects);
            return projects;
        }

        private static int CompareProjects(Project p1, Project p2)
        {
            if (p1.Priority != p2.Priority)
            {
                return p1.Priority.CompareTo(p2.Priority);
            }
            else
            {
                if (p1.CompletionDate != p2.CompletionDate)
                    return p1.CompletionDate.CompareTo(p2.CompletionDate);
                else
                    return p1.StartDate.CompareTo(p2.CompletionDate);
            }
        }
    }
}