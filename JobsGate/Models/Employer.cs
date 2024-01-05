namespace JobsGate.Models
{
    public class Employer 
    {
        public string Id {  get; set; } = Guid.NewGuid().ToString();
        public string? JobTitle {  get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual List<Job>? Jobs { get; set; }
    }
}
