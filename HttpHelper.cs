using System.Net;
using System.Text;
using System.Net.Http.Headers;

public class HttpHelper
{
    private readonly string token;
    private readonly string baseUrl = "https://graph.microsoft.com/v1.0/";

    public HttpHelper(string token)
    {
        this.token = token;
    }
    public async Task<string> GetAsync(string url, string? data = null)
    {
        using (var client = new HttpClient())
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseUrl + url);

                request.Headers.Add("User-Agent", "OutlookApp/1.0");
                request.Headers.Add("Authorization", "Bearer " + token);

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine(responseBody);
                    FileHelper.WriteAllText("data.json", responseBody);
                    return responseBody;
                }
                else
                {
                    Console.WriteLine("Request failed with status code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error");
                Console.WriteLine(url + ex.Message);

                throw;
            }
            var result = client.GetAsync(url).Result;
            return result.Content.ReadAsStringAsync().Result;
        }
    }
    public async Task<string> PostAsync(string apiUrl, string jsonBody)
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                var jsonData = @"{
  ""message"": {
    ""subject"": ""Meet for lunch2?"",
    ""body"": {
      ""contentType"": ""Text"",
      ""content"": ""Are you coming bro?""
    },
    ""toRecipients"": [
      {
        ""emailAddress"": {
          ""address"": ""sesenmurat@hotmail.com""
        }
      }
    ]
  }
}";
                // Set the base URL of the API
                httpClient.BaseAddress = new Uri(baseUrl + apiUrl);
                // httpClient.BaseAddress = new Uri("https://localhost:7243/post");

                // Set the authorization header with the Bearer token
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Set the content type to application/json
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Convert the JSON body to a StringContent object
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // Send the POST request and get the response
                var response = await httpClient.PostAsync(baseUrl + apiUrl, content);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read and return the response content as a string
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                // Handle any exceptions that may occur during the request
                Console.WriteLine($"Error making the request: {ex.Message}");

                // Check if the response is available
                // if (ex.InnerException is HttpResponseMessage response)
                // {
                //     // Get additional details from the response content if available
                //     var responseContent = await response.Content.ReadAsStringAsync();
                //     Console.WriteLine($"Response content: {responseContent}");
                // }


                return null;
            }
        }
    }
    public async Task<string> PostAsync(string baseUrl, string apiUrl, string jsonBody)
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                //httpClient.BaseAddress = new Uri(baseUrl + apiUrl);
                httpClient.BaseAddress = new Uri("https://localhost:7243/post");

                // Set the authorization header with the Bearer token
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Set the content type to application/json
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Convert the JSON body to a StringContent object
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // Send the POST request and get the response
                var response = await httpClient.PostAsync(baseUrl + apiUrl, content);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read and return the response content as a string
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                // Handle any exceptions that may occur during the request
                Console.WriteLine($"Error making the request: {ex.Message}");

                // Check if the response is available
                // if (ex.InnerException is HttpResponseMessage response)
                // {
                //     // Get additional details from the response content if available
                //     var responseContent = await response.Content.ReadAsStringAsync();
                //     Console.WriteLine($"Response content: {responseContent}");
                // }


                return null;
            }
        }
    }
    public async Task<string> DeleteAsync(string apiUrl)
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                // Set the base URL of the API
                httpClient.BaseAddress = new Uri(baseUrl + apiUrl);

                // Set the authorization header with the Bearer token
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Send the DELETE request and get the response
                var response = await httpClient.DeleteAsync(apiUrl);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read and return the response content as a string
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                // Handle any exceptions that may occur during the request
                Console.WriteLine($"Error making the request: {ex.Message}");

                // Check if the response is available
                // if (ex.InnerException is HttpResponseMessage response)
                // {
                //     // Get additional details from the response content if available
                //     var responseContent = await response.Content.ReadAsStringAsync();
                //     Console.WriteLine($"Response content: {responseContent
            }
            return null;
        }
    }
    public async Task<string> PutAsync(string apiUrl, string jsonBody)
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                // Set the base URL of the API
                httpClient.BaseAddress = new Uri(baseUrl + apiUrl);

                // Set the authorization header with the Bearer token
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Set the content type to application/json
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Convert the JSON body to a StringContent object
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // Send the PUT request and get the response
                var response = await httpClient.PutAsync(apiUrl, content);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read and return the response content as a string
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                // Handle any exceptions that may occur during the request
                Console.WriteLine($"Error making the request: {ex.Message}");
            }
            return null;
        }
    }
    public async Task<ApiResponse> PatchAsync(string apiUrl, string jsonBody)
    {
        using (var httpClient = new HttpClient())
        {
            try
            {
                // Set the base URL of the API
                httpClient.BaseAddress = new Uri(baseUrl + apiUrl);

                // Set the authorization header with the Bearer token
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Set the content type to application/json
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Convert the JSON body to a StringContent object
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // Send the PUT request and get the response
                var response = await httpClient.PatchAsync(baseUrl + apiUrl, content);

                // Ensure the request was successful
                response.EnsureSuccessStatusCode();

                // Read and return the response content as a string
                return new  ApiResponse { Success = true, Content = await response.Content.ReadAsStringAsync() };
            }
            catch (HttpRequestException ex)
            {
                // Handle any exceptions that may occur during the request
                Console.WriteLine($"Error making the request: {ex.Message}");
                return new  ApiResponse { Success = false, Content = ex.Message};
            }
        }
    }
}