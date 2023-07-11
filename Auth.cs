public static class Auth{
    private static string AccessToken { get; set; }
    private static OutlookContext context = new OutlookContext();
    private static SqliteRepository repo = new SqliteRepository(context);
    public static async Task<string> GetAccessTokenAsync()
    {
        //Check if there is a token in db
        var token = repo.GetToken();
        if(token == null)
        {
            token = await TokenHelper.RequestToken();
            if(token != null)
            {
                repo.AddToken(token);
                AccessToken = token.AccessToken;
            }
        }
        else if(!token.IsValid()){
            var newToken = await TokenHelper.RequestToken();
            if(newToken != null)
            {
                repo.UpdateToken(newToken);
                AccessToken = newToken.AccessToken;
            }
        }
        else {
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