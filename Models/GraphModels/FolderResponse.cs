using System.Text.Json.Serialization;
public class FolderResponse
{
    [JsonPropertyName("value")]
    public List<CustomFolder> Value { get; set; }
}

public class CustomFolder
{
    // "id": "AAMkADg4MDZlMWFjLWM0MWEtNDkxOS04NDE4LTA5ZGU3MjQ0ZjZlYQAuAAAAAADwB27-tbzMR4fKxnJNQWu0AQBwoKHBUBf5Tp89QVe-iBX9AAAAAAEXAAA=",
    //         "displayName": "Archive",
    //         "parentFolderId": "AAMkADg4MDZlMWFjLWM0MWEtNDkxOS04NDE4LTA5ZGU3MjQ0ZjZlYQAuAAAAAADwB27-tbzMR4fKxnJNQWu0AQBwoKHBUBf5Tp89QVe-iBX9AAAAAAEIAAA=",
    //         "childFolderCount": 0,
    //         "unreadItemCount": 0,
    //         "totalItemCount": 0,
    //         "sizeInBytes": 0,
    //         "isHidden": false 
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }
    [JsonPropertyName("parentFolderId")]
    public string ParentFolderId { get; set; }
    [JsonPropertyName("childFolderCount")]
    public int ChildFolderCount { get; set; }
    [JsonPropertyName("unreadItemCount")]
    public int UnreadItemCount { get; set; }
    [JsonPropertyName("totalItemCount")]
    public int TotalItemCount { get; set; }
    [JsonPropertyName("sizeInBytes")]
    public int SizeInBytes { get; set; }
    [JsonPropertyName("isHidden")]
    public bool IsHidden { get; set; }
}