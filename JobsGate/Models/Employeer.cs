namespace JobsGate.Models
{
    public class Employeer : ApplicationUser
    {
        public string Id {  get; set; } = Guid.NewGuid().ToString();
        public string? JobTitle {  get; set; }
        public virtual List<Job>? Jobs { get; set; }
    }
}
