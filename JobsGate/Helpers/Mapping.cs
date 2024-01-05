using JobsGate.DTO.Jobs;
using JobsGate.Models;

namespace JobsGate.Helpers
{
    public class Mapping
    {
        public JobsDTO MapJob(Job job)
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
    }
}
