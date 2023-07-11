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
        token.CreatedAt = DateTime.Now;
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
        _token.AccessToken = token.AccessToken;
        context.SaveChanges();
    }
}