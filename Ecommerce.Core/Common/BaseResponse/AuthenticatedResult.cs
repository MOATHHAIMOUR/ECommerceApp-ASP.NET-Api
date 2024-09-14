namespace Ecommerce.Application.Common.BaseResponse
{
    public class AuthenticatedResult
    {
        public string Token { get; set; }
        public string TokenType { get; set; }
        public string ExpiresIn { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public List<string> Roles { get; set; }
    }
}
