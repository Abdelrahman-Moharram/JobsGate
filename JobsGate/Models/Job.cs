namespace JobsGate.Models
{
    public class Job
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PostedAt { get; set; }

        

        public int Vacancies { get; set; }

        public decimal? Salary { get; set; }

        public int Experience { get; set; }


        public string EmployerId { get; set; }
        public virtual Employer? Employer { get; set; }

        public string IndustryId { get; set; }
        public virtual Industry? Industry { get; set; }

        public string CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        
        public string JobTypeId { get; set; }
        public virtual JobType? JobType { get; set; }

        public virtual List<JobApplication>? JobsApplications { get; set; }
        public virtual List<Employee>? Employees{ get; set; }

    }
}
