using System.Text.Json;
public static class TokenHelper
{
    public static async Task<Token> RequestToken()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Prepare the request data
                var requestData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("client_id", "27fbac7c-66a3-41ab-a003-3a63714d0721"),
                    new KeyValuePair<string, string>("scope", "https://graph.microsoft.com/.default"),
                    new KeyValuePair<string, string>("client_secret", "VmF8Q~hquYptDjteXCgv1YuI6RV_lJqRFL6Ypc1R"),
                    new KeyValuePair<string, string>("grant_type", "client_credentials")
                });

                // Send the POST request
                Console.WriteLine("Sending request");
              // Add the Content-Type header
                requestData.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

                // Send the POST request
                HttpResponseMessage response = await client.PostAsync("https://login.microsoftonline.com/061ae77b-7d54-4dc9-ae30-e3eef15f739d/oauth2/v2.0/token", requestData);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the response JSON
                    var token = JsonSerializer.Deserialize<Token>(responseBody);
                    return token;
                }
                else
                {
                    Console.WriteLine("Request failed with status code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        return null;
    }
}