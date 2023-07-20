public static class FolderMapper
{
    public static Folder Map(CustomFolder folderDto)
    {
        return new Folder
        {
            Id = folderDto.Id,
            DisplayName = folderDto.DisplayName,
            ParentFolderId = folderDto.ParentFolderId,
            ChildFolderCount = folderDto.ChildFolderCount,
            UnreadItemCount = folderDto.UnreadItemCount,
            TotalItemCount = folderDto.TotalItemCount,
            SizeInBytes = folderDto.SizeInBytes,
            IsHidden = folderDto.IsHidden,
        };
    }
    public static List<Folder> MapList(List<CustomFolder> folderDtos)
    {
        var folders = new List<Folder>();
        foreach (var folderDto in folderDtos)
        {
            folders.Add(Map(folderDto));
        }
        return folders;
    }
}