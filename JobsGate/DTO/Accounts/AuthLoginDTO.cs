using System.ComponentModel.DataAnnotations;

namespace JobsGate.DTO.Accounts
{
    public class AuthLoginDTO
    {
        [MinLength(2)]
        public string UserName { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
    }
}
