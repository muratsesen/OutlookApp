public static class Auth{
    private static string AccessToken { get; set; }
    private static OutlookContext context = new OutlookContext();
    private static SqliteRepository repo = new SqliteRepository(context);
    public static async Task<string> GetAccessTokenAsync()
    {
        Console.WriteLine("Getting Access Token");
        //Check if there is a token in db
        var token = repo.GetToken();
        if(token == null)
        {
            Console.WriteLine("No token found in db");
            Console.WriteLine("Requesting new token");
            token = await TokenHelper.RequestToken();
            if(token != null)
            {
                repo.AddToken(token);
                AccessToken = token.AccessToken;
            }
        }
        else if(!token.IsValid()){
            Console.WriteLine("Token is not valid");
            Console.WriteLine("Requesting new token");
            var newToken = await TokenHelper.RequestToken();
            if(newToken != null)
            {
                repo.UpdateToken(newToken);
                AccessToken = newToken.AccessToken;
            }
        }
        else {
            Console.WriteLine("Token is valid");
            AccessToken = token.AccessToken;
        }
        

        return AccessToken;
    }
    public static async void RefreshAccessToken()
    {
        var token =  await TokenHelper.RequestToken();
        repo.UpdateToken(token);
    }

}