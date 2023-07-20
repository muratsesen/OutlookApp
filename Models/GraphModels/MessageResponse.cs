using System.Text.Json.Serialization;

class MessageResponse
{
    [JsonPropertyName("value")]
    public List<CustomMessage> Value { get; set; }
}

public class CustomMessage
{
    [JsonPropertyName("@odata.type")]
    public string ODataType { get; set; }

    [JsonPropertyName("@odata.etag")]
    public string ODataEtag { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime CreatedDateTime { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime LastModifiedDateTime { get; set; }

    [JsonPropertyName("changeKey")]
    public string ChangeKey { get; set; }

    [JsonPropertyName("categories")]
    public List<object> Categories { get; set; }

    [JsonPropertyName("receivedDateTime")]
    public DateTime ReceivedDateTime { get; set; }

    [JsonPropertyName("sentDateTime")]
    public DateTime SentDateTime { get; set; }

    [JsonPropertyName("hasAttachments")]
    public bool HasAttachments { get; set; }

    [JsonPropertyName("internetMessageId")]
    public string InternetMessageId { get; set; }

    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    [JsonPropertyName("bodyPreview")]
    public string BodyPreview { get; set; }

    [JsonPropertyName("importance")]
    public string Importance { get; set; }

    [JsonPropertyName("parentFolderId")]
    public string ParentFolderId { get; set; }

    [JsonPropertyName("conversationId")]
    public string ConversationId { get; set; }

    [JsonPropertyName("conversationIndex")]
    public string ConversationIndex { get; set; }

    [JsonPropertyName("isDeliveryReceiptRequested")]
    public object IsDeliveryReceiptRequested { get; set; }

    [JsonPropertyName("isReadReceiptRequested")]
    public bool IsReadReceiptRequested { get; set; }

    [JsonPropertyName("isRead")]
    public bool IsRead { get; set; }

    [JsonPropertyName("isDraft")]
    public bool IsDraft { get; set; }

    [JsonPropertyName("webLink")]
    public string WebLink { get; set; }

    [JsonPropertyName("inferenceClassification")]
    public string InferenceClassification { get; set; }

    [JsonPropertyName("meetingMessageType")]
    public string MeetingMessageType { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("isOutOfDate")]
    public bool IsOutOfDate { get; set; }

    [JsonPropertyName("isAllDay")]
    public bool IsAllDay { get; set; }

    [JsonPropertyName("isDelegated")]
    public bool IsDelegated { get; set; }

    [JsonPropertyName("responseRequested")]
    public bool ResponseRequested { get; set; }

    [JsonPropertyName("allowNewTimeProposals")]
    public object AllowNewTimeProposals { get; set; }

    [JsonPropertyName("meetingRequestType")]
    public string MeetingRequestType { get; set; }

    [JsonPropertyName("body")]
    public Body Body { get; set; }

    [JsonPropertyName("sender")]
    public Sender Sender { get; set; }

    [JsonPropertyName("from")]
    public From From { get; set; }

    [JsonPropertyName("toRecipients")]
    public List<Recipient> ToRecipients { get; set; }

    [JsonPropertyName("ccRecipients")]
    public List<object> CcRecipients { get; set; }

    [JsonPropertyName("bccRecipients")]
    public List<object> BccRecipients { get; set; }

    [JsonPropertyName("replyTo")]
    public List<object> ReplyTo { get; set; }

    [JsonPropertyName("flag")]
    public Flag Flag { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTimeTimeZone StartDateTime { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTimeTimeZone EndDateTime { get; set; }

    [JsonPropertyName("location")]
    public Location Location { get; set; }

    [JsonPropertyName("recurrence")]
    public object Recurrence { get; set; }

    [JsonPropertyName("previousLocation")]
    public object PreviousLocation { get; set; }

    [JsonPropertyName("previousStartDateTime")]
    public object PreviousStartDateTime { get; set; }

    [JsonPropertyName("previousEndDateTime")]
    public object PreviousEndDateTime { get; set; }
}

public class Body
{
    [JsonPropertyName("contentType")]
    public string ContentType { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }
}
public class Sender
{
    [JsonPropertyName("emailAddress")]
    public EmailAddress EmailAddress { get; set; }
}

public class From
{
    [JsonPropertyName("emailAddress")]
    public EmailAddress EmailAddress { get; set; }
}

public class EmailAddress
{
    // [JsonPropertyName("name")]
    // public string Name { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }
}

public class Recipient
{
    [JsonPropertyName("emailAddress")]
    public EmailAddress EmailAddress { get; set; }
}

public class Flag
{
    [JsonPropertyName("flagStatus")]
    public string FlagStatus { get; set; }
}

public class DateTimeTimeZone
{
    [JsonPropertyName("dateTime")]
    public DateTime DateTime { get; set; }

    [JsonPropertyName("timeZone")]
    public string TimeZone { get; set; }
}

public class Location
{
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("locationType")]
    public string LocationType { get; set; }

    [JsonPropertyName("uniqueIdType")]
    public string UniqueIdType { get; set; }
}
