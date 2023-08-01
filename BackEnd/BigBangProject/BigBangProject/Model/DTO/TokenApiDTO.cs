namespace BigBangProject.Model.DTO
{
    public class TokenApiDTO
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? Name { get; set; }
        public int UserId { get; set; }
    }
}
