using System.Text.Json.Serialization;
public class _UserCollectionResponse
{
    [JsonPropertyNameAttribute("value")]
    public List<User> Value { get; set; }
}