namespace JobsGate.DTO.Accounts
{
    public class AuthResultDTO : ResponseDTO
    {
        public string? Token { get; set; }
        public string? UserName { get; set;}
        public string? UserEmail { get; set;}
        public bool IsAuthenticated { get; set; }
    }
}
