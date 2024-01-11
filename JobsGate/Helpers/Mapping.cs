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
    }
}
