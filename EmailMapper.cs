using System.Text.Json;
public static class EmailMapper
{
    public static Email Map(CustomMessage customMessage)
    {
        var email = new Email
        {
            Id = customMessage.Id,
            CreatedDateTime = customMessage.CreatedDateTime,
            LastModifiedDateTime = customMessage.LastModifiedDateTime,
            ChangeKey = customMessage.ChangeKey,
            ReceivedDateTime = customMessage.ReceivedDateTime,
            SentDateTime = customMessage.SentDateTime,
            HasAttachments = customMessage.HasAttachments,
            InternetMessageId = customMessage.InternetMessageId,
            Subject = customMessage.Subject,
            BodyPreview = customMessage.BodyPreview,
            Importance = customMessage.Importance,
            ParentFolderId = customMessage.ParentFolderId,
            ConversationId = customMessage.ConversationId,
            ConversationIndex = customMessage.ConversationIndex,
            IsReadReceiptRequested = customMessage.IsReadReceiptRequested,
            IsRead = customMessage.IsRead,
            IsDraft = customMessage.IsDraft,
            WebLink = customMessage.WebLink,
            InferenceClassification = customMessage.InferenceClassification,
            MeetingMessageType = customMessage.MeetingMessageType,
            Type = customMessage.Type,
            IsOutOfDate = customMessage.IsOutOfDate,
            IsAllDay = customMessage.IsAllDay,
            IsDelegated = customMessage.IsDelegated,
            ResponseRequested = customMessage.ResponseRequested,
            MeetingRequestType = customMessage.MeetingRequestType,
            Sender = customMessage.Sender?.EmailAddress?.Address,
            From = customMessage.From?.EmailAddress?.Address,
            ToRecipients = JsonSerializer.Serialize(customMessage.ToRecipients),
            CcRecipients = JsonSerializer.Serialize(customMessage.CcRecipients),
            BccRecipients = JsonSerializer.Serialize(customMessage.BccRecipients),
            Flag = customMessage.Flag?.FlagStatus,
            StartDateTime = customMessage.StartDateTime?.DateTime ?? DateTimeOffset.MinValue,
            EndDateTime = customMessage.EndDateTime?.DateTime ?? DateTimeOffset.MinValue,
        };

        return email;
    }
    public static List<Email> MapToEmailList(List<CustomMessage> customMessages)
    {
        var emails = new List<Email>();
        foreach (var customMessage in customMessages)
        {
            emails.Add(Map(customMessage));
        }
        return emails;
    }
}
