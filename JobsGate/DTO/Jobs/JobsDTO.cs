using JobsGate.Models;

namespace JobsGate.DTO.Jobs
{
    public class JobsDTO
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int vacancies { get; set; }
        public DateTime PostedAt { get; set; }

        public decimal? Salary { get; set; }

        public int Experience {get; set;}
        public string? JobTypeId {get; set;}
        public string? JobTypeName { get; set;}
        public string? EmployerName {get; set; }
        public string? EmployerId {get; set; }
        public string? EmployerJobTitle { get; set; }
        public string? CategoryTitle { get; set; }
        public string? CategoryId { get; set; }
        public string? IndustryId { get; set; }
        public string? IndustryTitle {get; set;}


    }
}
