namespace JobsGate.Models
{
    public class Employee:ApplicationUser
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string? Headline { get; set; }

        public string IndustryId { get; set; }
        public virtual Industry? Industry { get; set; }

    }
}
