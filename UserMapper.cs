public static class UserMapper
{
    public static List<User> MapList(List<UserDto> users)
    {
        var userList = new List<User>();
        foreach (var user in users)
        {
            userList.Add(Map(user));
        }
        return userList;
    }
    public static User Map(UserDto user)
    {
        return new User
        {
            Id = user.Id,
            DisplayName = user.DisplayName,
            GivenName = user.GivenName,
            JobTitle = user.JobTitle,
            Mail = user.Mail,
            MobilePhone = user.MobilePhone,
            OfficeLocation = user.OfficeLocation,
            PreferredLanguage = user.PreferredLanguage,
            Surname = user.Surname,
            UserPrincipalName = user.UserPrincipalName,

        };
    }
}


