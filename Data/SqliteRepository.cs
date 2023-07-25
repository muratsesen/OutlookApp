public class SqliteRepository : IRepository
{
    private readonly OutlookContext context;
    public SqliteRepository(OutlookContext _context)
    {
        context = _context;
    }

    public void AddUser(User user)
    {
        using (context)
        {
            context.Users.Add(user);
            context.SaveChangesAsync();
        }
    }
    public void AddUsers(List<User> userList)
    {
        using (var context = new OutlookContext())
        {
            // Retrieve existing user IDs from the database
            var existingUserIds = context.Users.Select(u => u.Id).ToList();

            foreach (var user in userList)
            {
                // Check if the user already exists in the database
                if (!existingUserIds.Contains(user.Id))
                {
                    // User does not exist, insert the user into the database
                    context.Users.Add(user);
                }
            }

            // Save the changes to the database
            context.SaveChanges();
        }
    }
    public List<User> GetAllUsers()
    {
        return context.Users.ToList();
    }
    public void AddToken(Token token)
    {
        token.CreatedAt = DateTime.UtcNow;
        context.Tokens.Add(token);
        context.SaveChanges();
    }
    public Token GetToken()
    {
        return context.Tokens.FirstOrDefault();
    }
    public void UpdateToken(Token token)
    {
        var _token = context.Tokens.FirstOrDefault();
        if (_token != null)
        {

            _token.AccessToken = token.AccessToken;
            _token.CreatedAt = DateTime.UtcNow;
            _token.ExpiresIn = token.ExpiresIn;
            _token.ExtExpiresIn = token.ExtExpiresIn;
        }
        else
        {
            context.Tokens.Add(token);
        }
        context.SaveChanges();
    }
    public void SaveUserEmails(List<Email> messages, string userId)
    {
        try
        {
            foreach (var message in messages)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Parent Folder Id: " + message.ParentFolderId);

                var folder = context.Folders.FirstOrDefault(f => f.Id == message.ParentFolderId);
                if (folder != null) Console.WriteLine("Folder Name: " + folder.DisplayName);
                else
                {
                    Console.WriteLine("** Parent Foler is null");
                    continue;
                }

                var existingData = context.Emails.FirstOrDefault(m => m.Id == message.Id);

                if (existingData != null)
                {
                    Console.WriteLine("Email already exists");
                    continue;
                }
                
                Console.WriteLine("------------------------------------");
                message.UserId = userId;
                context.Emails.Add(message);
            }
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding emails");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException);
        }

    }
    public void AddUserFolders(List<Folder> folders, string userId)
    {
        try
        {
            DeleteFolders(userId);
            int i = 1;
            foreach (var folder in folders)
            {

                Console.WriteLine(i++ + "------------------------------------");
                Console.WriteLine("Folder Name: " + folder.DisplayName);
                Console.WriteLine("Folder Id: " + folder.Id);
                Console.WriteLine("Parent Folder Id: " + folder.ParentFolderId);
                Console.WriteLine("------------------------------------");
                Console.WriteLine("User Id: " + userId);
                Console.WriteLine("------------------------------------");

                folder.UserId = userId;
                context.Folders.Add(folder);
            }
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding folders");
            Console.WriteLine(ex.Message);
        }

    }
    public void UpdateUserFolders(List<Folder> folders, string userId)
    {
        foreach (var folder in folders)
        {
            folder.UserId = userId;
            context.Folders.Add(folder);
        }
        context.SaveChanges();
    }
    public void DeleteFolders(string userId)
    {
        Console.WriteLine("Deleting folders");

        var folders = context.Folders.Where(f => f.UserId == userId).ToList();

        try
        {
            //context.Folders.RemoveRange(folders);
            foreach (var folder in folders)
            {
                context.Folders.Remove(folder);
            }
            context.SaveChanges();
        }
        catch (Exception ex)
        {

            throw;
        }
    }

}

