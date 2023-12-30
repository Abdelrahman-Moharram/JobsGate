namespace JobsGate.DTO.Accounts
{
    public class AuthResultDTO
    {
        public string? Token { get; set; }
        public string? Message { get; set;}
        public string? UserName { get; set;}
        public string? UserEmail { get; set;}
        public bool IsAuthenticated { get; set; }
    }
}
