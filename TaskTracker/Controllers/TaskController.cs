using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Core.Models;
using TaskTracker.Infrastructure;
using TaskTracker.ViewModel;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class TaskController : ControllerBase
    {
        private TrackerDbContext _dbContext;
        public TaskController(DbContext db)
        {
            _dbContext = db as TrackerDbContext;
        }
        
        [HttpGet]
        public ActionResult<List<TaskViewModel>> ViewAll()
        {
            return _dbContext.Tasks
                .Select(t => new TaskViewModel(t))
                .ToList();
        }
        
        [HttpGet("{projId}")]
        public ActionResult<List<Task>> ViewByProject(int projId)
        {
            var proj = _dbContext.Projects.FirstOrDefault(p => p.Id == projId);
            return _dbContext.Tasks
                .Where(t=>t.Project == proj)
                .ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Task> View(int id)
        {
            var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
            if (task is null)
                return NotFound();
            return task;
        }

        [HttpPost]
        public IActionResult Create(Task task)
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(Create), new {id = task.Id}, task);
        }
        
        [HttpPut("{id}")]
        public IActionResult Edit(int id, Task task)
        {
            if (id != task.Id)
                return BadRequest();
            var existingTask = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
            if (existingTask is null)
                return NotFound();
            _dbContext.Tasks.Update(task);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delTask = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
            if (delTask is null)
                return NotFound();
            _dbContext.Tasks.Remove(delTask);
            _dbContext.SaveChanges();
            return NoContent(); 
        }

        [HttpPut("{projId}")]
        public ActionResult<Task> AddToProject(int projId, Task task)
        {
            task.Project = _dbContext.Projects.FirstOrDefault(p => p.Id == projId);
            _dbContext.Tasks.Update(task);
            _dbContext.SaveChanges();
            return task;
        }
    }
}