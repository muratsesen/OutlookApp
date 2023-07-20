using System.ComponentModel.DataAnnotations.Schema;
public class Email 
{
    public string Id { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? LastModifiedDateTime { get; set; }

    public string? ChangeKey { get; set; }

    //public List<object> Categories { get; set; }

    public DateTime? ReceivedDateTime { get; set; }

    public DateTime? SentDateTime { get; set; }

    public bool? HasAttachments { get; set; }

    public string? InternetMessageId { get; set; }

    public string? Subject { get; set; }

    public string? BodyPreview { get; set; }

    public string? Importance { get; set; }
    [ForeignKey("Folder")]
    public string? ParentFolderId { get; set; }

    public string? ConversationId { get; set; }

    public string? ConversationIndex { get; set; }

    //public object IsDeliveryReceiptRequested { get; set; }

    public bool? IsReadReceiptRequested { get; set; }

    public bool? IsRead { get; set; }

    public bool? IsDraft { get; set; }

    public string? WebLink { get; set; }

    public string? InferenceClassification { get; set; }

    public string? MeetingMessageType { get; set; }

    public string? Type { get; set; }

    public bool? IsOutOfDate { get; set; }

    public bool? IsAllDay { get; set; }

    public bool? IsDelegated { get; set; }

    public bool? ResponseRequested { get; set; }

    //public object AllowNewTimeProposals { get; set; }

    public string? MeetingRequestType { get; set; }

    //public Body Body { get; set; }

    public string? Sender { get; set; }

    public string? From { get; set; }

    public string? ToRecipients { get; set; }

    public string? CcRecipients { get; set; }

    public string? BccRecipients { get; set; }

    public string? ReplyTo { get; set; }

    public string? Flag { get; set; } //notFlagged or flagged

    public DateTimeOffset? StartDateTime { get; set; }

    public DateTimeOffset? EndDateTime { get; set; }

    //public Location Location { get; set; }

    // public object Recurrence { get; set; }

    // public object PreviousLocation { get; set; }

    // public object PreviousStartDateTime { get; set; }

    // public object PreviousEndDateTime { get; set; }

    public string UserId { get; set; }
    public User User { get; set; }
    
    public Folder Folder { get; set; }
}