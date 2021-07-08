using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private TrackerDbContext _dbContext;

        public ProjectController(TrackerDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Project> View(int id)
        {
            var proj = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
            if (proj is null)
                return NotFound();
            return proj;
        }

        [HttpGet]
        public ActionResult<List<Project>> ViewAll()
        {
            return _dbContext.Projects.ToList();
        }

        [HttpPost]
        public IActionResult Create(Project proj)
        {
            _dbContext.Add(proj);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(Create), new {id = proj.Id}, proj);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, Project proj)
        {
            if (id != proj.Id)
                return BadRequest();
            var ex = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
            if (ex is null)
                return NotFound();
            _dbContext.Projects.Update(proj);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var exProj = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
            if (exProj is null)
                return NotFound();
            _dbContext.Remove(exProj);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}