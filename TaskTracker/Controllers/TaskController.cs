using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Models;
using TaskTracker.Services;

namespace TaskTracker.Controllers
{
    // все в контроллер, потом вытащить в сервис
    [ApiController]
    [Route("api/controller")]
    public class TaskController : ControllerBase
    {
        private TrackerDbContext _dbContext;
        public TaskController(TrackerDbContext db)
        {
            _dbContext = db;
        }

        [HttpGet]
        public ActionResult<List<Task>> ViewAll()
        {
            return _dbContext.Tasks.ToList();
        }
        
        [HttpGet]
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
        
        // TODO: is it support "remove task from a project"?
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
            var t = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
            if (t is null)
                return NotFound();
            _dbContext.Tasks.Remove(t);
            _dbContext.SaveChanges();
            return NoContent(); 
        }
    }
}