using System.Text.Json.Serialization;
public class SendMessageDto
{
    [JsonPropertyName("message")]
    public Message Message { get; set; }

}
public class Message
{
    [JsonPropertyName("subject")]
    public string Subject { get; set; }
    [JsonPropertyName("body")]
    public Body Body { get; set; }
    [JsonPropertyName("toRecipients")]
    public List<ToRecipient> ToRecipients { get; set; }
}
public class ToRecipient
{
    [JsonPropertyName("emailAddress")]
    public EmailAddress EmailAddress { get; set; }
}

