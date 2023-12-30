using Microsoft.AspNetCore.Identity;

namespace JobsGate.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
        public string? region { get; set; }
        public string? city { get; set; }
        public string? Image {  get; set; }

    }
}
