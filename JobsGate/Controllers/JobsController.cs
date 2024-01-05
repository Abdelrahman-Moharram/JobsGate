using JobsGate.DTO;
using JobsGate.DTO.Jobs;
using JobsGate.Models;
using JobsGate.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
namespace JobsGate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IBaseRepository<Job> JobRepository;
        private readonly IBaseRepository<Employer> EmployerRepository;
        public JobsController(IBaseRepository<Job> _JobRepository, IBaseRepository<Employer> _EmployerRepository)
        {
            JobRepository = _JobRepository;
            EmployerRepository = _EmployerRepository;   

        }


        private JobsDTO MapJob(Job job)
        {
            return new JobsDTO
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
            };
        }



        [HttpGet]
        public async Task<IActionResult> Jobs([FromQuery] int start = 0, [FromQuery] int end = 10)
        {
            var jobs = await JobRepository.PaginateAsync(start, end);
            List<JobsDTO> jobsListDTOs = new List<JobsDTO>();
            foreach (var job in jobs)
            {
                jobsListDTOs.Add(MapJob(job));

            }
            return Ok(jobsListDTOs);
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> Job(string id)
        {
            var job = await JobRepository.GetByIdAsync(id);
            if (job != null)
                return Ok(MapJob(job));
            return NotFound();
        }

        [HttpPost("add")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> AddJob([FromBody] Job job)
        {
            if (ModelState.IsValid)
            {
                JobRepository.AddAsync(job);
                JobRepository.Save();
                return Ok(MapJob(job));
            }
            return BadRequest(job);
        }


        [HttpPut("{id}/Edit")]
        [Authorize(Roles = "Employer, Admin")]
        public async Task<IActionResult> EditJob([FromBody] Job job, [FromRoute] string id)
        {
            var userId = User.Claims.FirstOrDefault(i => i.Type == "userId")?.Value;
            var Employer =  await EmployerRepository.FindAsync(i=>i.UserId == userId);
            var roles = User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.Role)?.Value;
            if (Employer?.Id == job.EmployerId || roles.ToLower().Contains("admin"))
            {

                if (id == job.Id && ModelState.IsValid)
                {
                    JobRepository.UpdateAsync(job);
                    JobRepository.Save();
                    return Ok(MapJob(job));
                }
                return BadRequest();
            }
            
            return BadRequest(new ResponseDTO
            {
                Message="Invalid user credintials"
            });
        }
    }
}
