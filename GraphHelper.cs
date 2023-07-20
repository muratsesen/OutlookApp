
using System.Text.Json;
class GraphHelper
{
    public static string userId = "";
    internal static async Task<List<CustomMessage>> GetMessagesAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Get an access token for the user.
                var token = await Auth.GetAccessTokenAsync();
                HttpHelper httpHelper = new HttpHelper(token);

                var response = await httpHelper.GetAsync($"users/{userId}/messages");

                var messageResponse = JsonSerializer.Deserialize<MessageResponse>(response);

                if (messageResponse != null)
                {
                    return messageResponse.Value;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return null;
        }
    }
    internal static async Task<List<CustomMessage>> GetMessagesAsync( DateTime startDate, DateTime endDate)
    {
        string endDateString = endDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
        string startDateString = startDate.ToString("yyyy-MM-ddTHH:mm:ssZ");

        string filter = $"receivedDateTime ge {startDateString} and receivedDateTime le {endDateString}";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Get an access token for the user.
                var token = await Auth.GetAccessTokenAsync();
                HttpHelper httpHelper = new HttpHelper(token);

                var response = await httpHelper.GetAsync($"users/{userId}/messages?$filter={filter}");

                var messageResponse = JsonSerializer.Deserialize<MessageResponse>(response);

                if (messageResponse != null)
                {
                    return messageResponse.Value;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return null;
        }
    }
    internal static async Task<List<CustomMessage>> GetMessagesAsync( DateTime? startDate, DateTime? endDate, string folderId)
    {

        string filter = "";

        if(folderId != null)
        {
            filter = $"parentFolderId eq '{folderId}'";
        }
        if (startDate != null && endDate != null)
        {
            string endDateString = endDate?.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string startDateString = startDate?.ToString("yyyy-MM-ddTHH:mm:ssZ");
            filter += $" and (receivedDateTime ge {startDateString} and receivedDateTime le {endDateString})";
        }

        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Get an access token for the user.
                var token = await Auth.GetAccessTokenAsync();
                HttpHelper httpHelper = new HttpHelper(token);

                var response = await httpHelper.GetAsync($"users/{userId}/messages?$filter={filter}");

                var messageResponse = JsonSerializer.Deserialize<MessageResponse>(response);

                if (messageResponse != null)
                {
                    return messageResponse.Value;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return null;
        }
    }
    internal static async Task<List<CustomMessage>> GetMessagesAsync( string folderId=null, string from=null, string? toRecipients=null, string? ccRecipients=null, string? subject=null, string? keyword=null, DateTime? startDate=null, DateTime? endDate=null, bool? hasAttachment=false)
    {

        string filter = "";

        if(folderId != null)
        {
            filter = $"parentFolderId eq '{folderId}'";
        }
        if(from != null)
        {
            var and = filter.Length > 0 ? " and " : "";
            filter += $"{and}from/emailAddress/address eq '{from}'";
        }
        if (toRecipients != null)
        {
            var and = filter.Length > 0 ? " and " : "";
            filter += $"{and}toRecipients/emailAddress/address eq '{toRecipients}'";
        }
        if (ccRecipients != null)
        {
            var and = filter.Length > 0 ? " and " : "";
            filter += $"{and}ccRecipients/emailAddress/address eq 'cc-{ccRecipients}'";
        }
        if (subject != null)
        {
            var and = filter.Length > 0 ? " and " : "";
            filter += $"{and}contains(subject,'{subject}')";
        }
        if (keyword != null)
        {
            var and = filter.Length > 0 ? " and " : "";
            filter += $"{and}(body/contentType eq 'text' and contains(body/content, '{keyword}')) ";
        }
        if (startDate != null && endDate != null)
        {
            string endDateString = endDate?.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string startDateString = startDate?.ToString("yyyy-MM-ddTHH:mm:ssZ");
            var and = filter.Length > 0 ? " and " : "";
            filter += $"{and}(receivedDateTime ge {startDateString} and receivedDateTime le {endDateString})";
        }
        if (hasAttachment == true)
        {
            var and = filter.Length > 0 ? " and " : "";
            filter += $"{and}attachments/any()";
        } 
        

        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Get an access token for the user.
                var token = await Auth.GetAccessTokenAsync();
                HttpHelper httpHelper = new HttpHelper(token);

                var response = await httpHelper.GetAsync($"users/{userId}/messages?$filter={filter}");

                var messageResponse = JsonSerializer.Deserialize<MessageResponse>(response);

                if (messageResponse != null)
                {
                    return messageResponse.Value;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return null;
        }
    }
    internal static async Task<List<UserDto>> GetUsersAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Get an access token for the user.
                var token = await Auth.GetAccessTokenAsync();
                HttpHelper httpHelper = new HttpHelper(token);

                var response = await httpHelper.GetAsync($"users");

                var folderResponse = JsonSerializer.Deserialize<UserResponse>(response);

                if (folderResponse != null)
                {
                    return folderResponse.Value;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return null;
        }

    }
    internal static async Task<List<CustomFolder>> SendMessageAsync(SendMessageDto sendMessageDto)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Get an access token for the user.
                var token = await Auth.GetAccessTokenAsync();
                HttpHelper httpHelper = new HttpHelper(token);

                var data = JsonSerializer.Serialize(sendMessageDto);
                Console.WriteLine(data);
                
                var response = await httpHelper.PostAsync($"users/{userId}/sendMail",data);
                //var response = await httpHelper.PostAsync($"users/{userId}/sendMail",data);
                Console.WriteLine(response);

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return null;
        }
    }
    internal static async Task<List<CustomFolder>> GetFoldersAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Get an access token for the user.
                var token = await Auth.GetAccessTokenAsync();
                HttpHelper httpHelper = new HttpHelper(token);

                var response = await httpHelper.GetAsync($"users/{userId}/mailFolders");

                var folderResponse = JsonSerializer.Deserialize<FolderResponse>(response);

                if (folderResponse != null)
                {
                    return folderResponse.Value;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return null;
        }
    }
    //TODO
     internal static async Task DeleteFolderAsync(string folderId)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Get an access token for the user.
                var token = await Auth.GetAccessTokenAsync();
                HttpHelper httpHelper = new HttpHelper(token);

                var response = await httpHelper.DeleteAsync($"users/{userId}/mailFolders/{folderId}");

                Console.WriteLine(response);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
    internal static async Task DeleteMessageAsync(string messageId)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Get an access token for the user.
                var token = await Auth.GetAccessTokenAsync();
                HttpHelper httpHelper = new HttpHelper(token);

                var response = await httpHelper.DeleteAsync($"users/{userId}/messages/{messageId}");

                Console.WriteLine(response);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
    internal static async Task DeleteMessagesAsync(List<string> messageIds)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Get an access token for the user.
                var token = await Auth.GetAccessTokenAsync();
                HttpHelper httpHelper = new HttpHelper(token);

                var request = new DeleteMessagesRequest();

                int i =1;
                foreach (var messageId in messageIds)
                {
                    request.Requests.Add(new Request() { Id = i++, Method = "DELETE",Url= $"users/{userId}/messages/{messageId}" });
                }

                var data = JsonSerializer.Serialize(request);

                var response = await httpHelper.PostAsync($"https://graph.microsoft.com/v1.0/","$batch", data);

                Console.WriteLine(response);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    } 
    internal static async Task CreateFoldersAsync(string folderName)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Get an access token for the user.
                var token = await Auth.GetAccessTokenAsync();
                HttpHelper httpHelper = new HttpHelper(token);

                       var jsonData = @"{'displayName': '" + folderName + "'}";

                var response = await httpHelper.PostAsync($"users/{userId}/mailFolders",jsonData);

                Console.WriteLine(response);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    
    }
    internal static async Task MoveMessagesToSpamFolderAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Get an access token for the user.
                var token = await Auth.GetAccessTokenAsync();
                HttpHelper httpHelper = new HttpHelper(token);

                var response = await httpHelper.PostAsync($"users/{userId}/messages/moveToSpam","");

                Console.WriteLine(response);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
    internal static async Task MoveMessagesToTrashFolderAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Get an access token for the user.
                var token = await Auth.GetAccessTokenAsync();
                HttpHelper httpHelper = new HttpHelper(token);

                var response = await httpHelper.PostAsync($"users/{userId}/messages/moveToTrash","");

                Console.WriteLine(response);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
    internal static async Task MoveMessagesToFolderAsync(string folderId)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Get an access token for the user.
                var token = await Auth.GetAccessTokenAsync();
                HttpHelper httpHelper = new HttpHelper(token);

                var response = await httpHelper.PostAsync($"users/{userId}/messages/moveToFolder","");

                Console.WriteLine(response);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
    //tag message
    internal static async Task TagMessageAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Get an access token for the user.
                var token = await Auth.GetAccessTokenAsync();
                HttpHelper httpHelper = new HttpHelper(token);

                var response = await httpHelper.PostAsync($"users/{userId}/messages/tag","");

                Console.WriteLine(response);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}