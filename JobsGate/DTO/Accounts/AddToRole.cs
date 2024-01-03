using System.ComponentModel.DataAnnotations;

namespace JobsGate.DTO.Accounts
{
    public class AddRoleDTO
    {
        [Required]
        public string userId { get; set; }

        [Required]
        public string roleName { get; set; }
    }
}

