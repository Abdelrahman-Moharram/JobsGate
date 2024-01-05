using JobsGate.DTO.Jobs;
using JobsGate.Models;
using JobsGate.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobsGate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IBaseRepository<Job> JobRepository;
        public JobsController(IBaseRepository<Job> _JobRepository)
        {
            JobRepository = _JobRepository;
        }



        [HttpPost("add")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> AddJob([FromBody] Job job)
        {
            if (ModelState.IsValid)
            {
                JobRepository.AddAsync(job);
                JobRepository.Save();
                return Ok(new JobsDTO
                {
                    Category = job?.Category?.Title,
                    Title = job?.Title,
                    Description = job?.Description,
                    Employer = job?.Employer?.User?.UserName,
                    Experience  = job.Experience,
                    Id = job?.Id,
                    Industry = job?.Industry?.Title,
                    Salary = job?.Salary
                });
            }
            return BadRequest(job);
        }

        [HttpGet("")]
        public async Task<IActionResult> Jobs([FromQuery] int start = 0, [FromQuery] int end = 10)
        {
            var jobs = await JobRepository.PaginateAsync(start, end);
            List<JobsDTO> jobsListDTOs = new List<JobsDTO>();
            foreach (var job in jobs)
            {
                jobsListDTOs.Add(new JobsDTO
                {
                    Id = job.Id,
                    Title = job.Title,
                    Category = job.Category?.Title,
                    Description = job.Description,
                    Employer = job.Employer?.User?.UserName,
                    Experience = job.Experience,
                    PostedAt = job.PostedAt,
                    Salary = job.Salary,
                    Industry = job.Industry?.Title,
                    vacancies = job.Vacancies,
                });
            }
            return Ok(jobsListDTOs);
        }




    }
}
