using JobsGate.DTO.Jobs;
using JobsGate.Models;
using JobsGate.Repository;
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

        [HttpGet("jobs")]
        public async Task<IActionResult> Jobs(int start = 0, int end = 20)
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
                    Employer = job.Employer?.UserName,
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
