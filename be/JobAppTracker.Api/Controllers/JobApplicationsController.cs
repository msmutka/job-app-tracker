using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobAppTracker.Api.Data;
using JobAppTracker.Api.Models;

namespace JobAppTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobApplicationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JobApplicationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobApplication>>> GetAll()
        {
            return await _context.JobApplications.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplication>> GetById(Guid id)
        {
            var job = await _context.JobApplications.FindAsync(id);
            if (job == null) return NotFound();
            return job;
        }

        [HttpPost]
        public async Task<ActionResult<JobApplication>> Create(JobApplication job)
        {
            Console.WriteLine("jsem tuuuu");
            job.Id = Guid.NewGuid();
            job.AppliedOn = DateTime.UtcNow;
            _context.JobApplications.Add(job);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, JobApplication job)
        {
            if (id != job.Id) return BadRequest();
            _context.Entry(job).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var job = await _context.JobApplications.FindAsync(id);
            if (job == null) return NotFound();
            _context.JobApplications.Remove(job);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
