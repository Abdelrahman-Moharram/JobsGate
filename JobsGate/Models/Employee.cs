namespace JobsGate.Models
{
    public class Employee
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string? Headline { get; set; }

        public string? IndustryId { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Industry? Industry { get; set; }
        public virtual List<JobApplication>? JobsApplications { get; set; }
        public virtual List<Job>? Jobs{ get; set; }


    }
}
