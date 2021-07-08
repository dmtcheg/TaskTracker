using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using TaskTracker.Models;

namespace TaskTracker.Services
{
    public static class TaskService
    {
        private static int _nextId = 1;
        
        // TODO: replace by dbcontext.Tasks
        private static List<Task> Tasks { get; }
        public static List<Task> GetAll() => Tasks;
        
        public static Task Get(int id) => Tasks.FirstOrDefault(t=> t.Id == id);

        // TODO: what about parent project?
        public static void Add(Task t)
        {
            t.Id = _nextId++;
            Tasks.Add(t);
        }

        public static void Delete(int id)
        {
            var delT = Get(id);
            if (delT is null)
                return;
            Tasks.Remove(delT);
        }

        // TODO: what about parent project?
        public static void Update(Task task)
        {
            var index = Tasks.FindIndex(t => t.Id == task.Id);
            if (index == -1)
                return;
            Tasks[index] = task;
        }
    }
}