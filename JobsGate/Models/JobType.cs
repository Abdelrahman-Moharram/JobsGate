namespace JobsGate.Models
{
    public class JobType
    {
        // full time - remote - part time
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
    }
}
