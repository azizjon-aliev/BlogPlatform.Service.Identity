namespace Identity.Domain.Entities;

public class TokenInfo
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    
    public string TokenType { get; set; } = "Bearer";

    public DateTime ExpireTime { get; set; } = DateTime.UtcNow.AddMinutes(30);

}