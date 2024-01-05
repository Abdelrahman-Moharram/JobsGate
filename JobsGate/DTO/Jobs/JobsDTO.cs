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
        public string? JobType {get; set;}
        public string? Employer {get; set; }
        public string? Industry {get; set;}
        public string? Category { get; set; }

    }
}
