namespace JobsGate.Models
{
    public class JobApplication
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? CV {  get; set; }
        public string? CoverLetter {  get; set; }

        public string? JobId { get; set; }
        public virtual Job? Job { get; set; }
        public string? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
