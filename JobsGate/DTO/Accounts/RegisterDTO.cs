using System.ComponentModel.DataAnnotations;

namespace JobsGate.DTO.Accounts
{
    public class RegisterDTO
    {
        [Required, MinLength(2)]
        public string UserName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string RegisterAs { get; set; }
    }
}
