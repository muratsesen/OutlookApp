public class Folder
{
    public string Id { get; set; }
    public string DisplayName { get; set; }
    public string? ParentFolderId { get; set; }
    public int? ChildFolderCount { get; set; }
    public int? UnreadItemCount { get; set; }
    public int? TotalItemCount { get; set; }
    public int? SizeInBytes { get; set; }
    public bool? IsHidden { get; set; }

    public List<Email> Emails { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}