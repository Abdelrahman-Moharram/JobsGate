namespace JobsGate.Models
{
    public class Category
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }

        public string? IndustryId { get; set; }
        public virtual  Industry? Industry { get; set; }
        public virtual List<Job>? Jobs { get; set; }


    }
}
