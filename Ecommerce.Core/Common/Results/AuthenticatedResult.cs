namespace Ecommerce.Application.Common.Results
{
    public class AuthenticatedResult
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
    }
}
