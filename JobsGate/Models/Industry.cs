namespace JobsGate.Models
{
    public class Industry
    {
        // software-engineering || Design & Creative || Sales & Marketing || Writing & Translation 
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public virtual List<Category>? Categories { get; set; }
        public virtual List<Job>? Jobs { get; set; }
    }
}
