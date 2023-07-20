using System.Text.Json.Serialization;
public class Token
{
    public int Id { get; set; }
    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; }
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
    [JsonPropertyName("ext_expires_in")]
    public int ExtExpiresIn { get; set; }
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    public DateTime CreatedAt { get; set; }=DateTime.UtcNow;
    
    public bool IsValid()
    {
        DateTime expirationTime = CreatedAt.AddSeconds(ExpiresIn-5);
        return DateTime.UtcNow < expirationTime;
    }
}   