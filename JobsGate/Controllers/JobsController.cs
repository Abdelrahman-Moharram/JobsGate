using JobsGate.DTO;
using JobsGate.DTO.Jobs;
using JobsGate.Helpers;
using JobsGate.Models;
using JobsGate.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
        private readonly IBaseRepository<Employee> EmployeeRepository;
        private readonly IBaseRepository<JobApplication> JobApplicationRepository;
        public JobsController(
            IBaseRepository<Job> _JobRepository, 
            IBaseRepository<Employer> _EmployerRepository,
            IBaseRepository<Employee> _EmployeeRepository,
            IBaseRepository<JobApplication> _JobApplicationRepository
            )
        {
            JobRepository = _JobRepository;
            EmployerRepository = _EmployerRepository;  
            EmployeeRepository = _EmployeeRepository;
            JobApplicationRepository = _JobApplicationRepository;

        }


        private JobsDTO MapJob(Job job)
        {
            return new JobsDTO
            {
                Id = job.Id,
                Title = job.Title,
                CategoryTitle = job?.Category?.Title,
                CategoryId = job?.Category?.Id,
                Description = job?.Description,
                EmployerName = job?.Employer?.User.UserName,
                EmployerId = job?.Employer?.Id,
                EmployerJobTitle = job?.Employer?.JobTitle,
                Experience = job.Experience,
                PostedAt = job.PostedAt,
                Salary = job.Salary,
                IndustryId = job.Industry?.Id,
                IndustryTitle = job.Industry?.Title,
                vacancies = job.Vacancies,
                JobTypeId = job.JobType?.Id,
                JobTypeName = job.JobType?.Name

            };
        }
        private async Task<bool> IsJobPublisherOrAdmin(IEnumerable<Claim> claims, string EmployerId)
        {
            var userId = claims.FirstOrDefault(i => i.Type == "userId")?.Value;
            var Employer = await EmployerRepository.FindAsync(i => i.UserId == userId);
            var roles = claims.FirstOrDefault(i => i.Type == ClaimTypes.Role)?.Value;

            if (Employer?.Id == EmployerId || roles.ToLower().Contains("admin"))
                return true;

            return false;
        }
        private async Task<bool> IsAlreadyApplied(string EmployeeId, string JobId)
        {

            if (await JobApplicationRepository.FindAsync(i=>i.EmployeeId == EmployeeId && i.JobId == JobId) != null)
                return true;

            return false;
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
            if(await JobRepository.GetByIdAsync(id) == null)
                return NotFound(new ResponseDTO{Message = "Job Not Found"});

            if (await IsJobPublisherOrAdmin(User.Claims, job.EmployerId))
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


        [HttpDelete("{id}/Delete")]
        [Authorize(Roles = "Employer, Admin")]
        public async Task<IActionResult> DeleteJob([FromRoute] string id)
        {
            var job =  await JobRepository.GetByIdAsync(id);
            if (job == null)
                return NotFound();

            if (await IsJobPublisherOrAdmin(User.Claims, job.EmployerId))
            {
                var j = MapJob(await JobRepository.DeleteAsync(job));
                JobRepository.Save();
                return Ok(j);
            }

            return BadRequest("Invalid user credintials or job not found");
        }




        [HttpGet("{id}/Applications")]
        [Authorize(Roles = "Employer, Admin")]
        public async Task<IActionResult> JobApplications(string id)
        {
            var job = await JobRepository.GetByIdAsync(id);
            if (job == null)
                return NotFound();
            var result = await IsJobPublisherOrAdmin(User.Claims, job.EmployerId);
            if (result)
            {
                var applications = new  List<JobApplicationDTO>() ;
                foreach (var application in await JobApplicationRepository.GetAllAsync())
                {
                    applications.Add(new JobApplicationDTO
                    {
                        EmployeeName = application?.Employee?.User.UserName,
                        CoverLetter = application?.CoverLetter,
                        JobName = application?.Job?.Title,
                        JobId = application?.JobId,
                        EmployeeId = application?.EmployeeId,
                    }); 
                }
                return Ok(applications);
            }
            return BadRequest("Invalid user credintials or job not found");
        }


        [HttpPost("{id}/apply")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> ApplyJob(string id,[FromForm] JobApplicationDTO applicationDTO, IFormFile CV)
        {
            
            ModelState.Remove("CV");
            FileUpload fileUpload = new FileUpload();
            var userId = User.Claims.FirstOrDefault(i => i.Type == "userId")?.Value;
            var Employee = await EmployeeRepository.FindAsync(i => i.UserId == userId);
            if (id == applicationDTO.JobId && Employee.Id == applicationDTO.EmployeeId && ModelState.IsValid)
            {
                if (await IsAlreadyApplied(applicationDTO.EmployeeId, applicationDTO.JobId))
                    return BadRequest("This Employee Already Applied !");


                JobApplicationRepository.AddAsync(new JobApplication
                {
                    CV = fileUpload.UploadCV(CV),
                    CoverLetter = applicationDTO.CoverLetter,
                    EmployeeId = applicationDTO.EmployeeId,
                    JobId = applicationDTO.JobId,
                });
                JobRepository.Save();
                return Ok(new ResponseDTO
                {
                    Message="Data Saved Successfully"
                });
            }
            return BadRequest(new ResponseDTO
            {
                Message = "Received Data is Invalid"
            });
        }
    }
}
