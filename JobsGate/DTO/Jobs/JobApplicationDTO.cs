using JobsGate.Models;
using System.ComponentModel.DataAnnotations;

namespace JobsGate.DTO.Jobs
{
    public class JobApplicationDTO
    {
        [Required]
        /*public string CV { get; set; }*/
        public string? CoverLetter { get; set; }
        public string? JobId { get; set; }
        public string? JobName { get; set; }
        public string? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }

    }
}
