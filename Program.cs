
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Graph.Models;
using Azure.Identity;
// <ProgramSnippet>
Console.WriteLine("Outlook Application\n");
//

//Settings
string clientId = "feffd4f2-d721-4a5f-9c11-2739c8411d94";
string clientSecret = "p_98Q~sf-gvt2oEEGGgR~cKXOIr.3QaEbgDHbdnN";
string tenantId = "061ae77b-7d54-4dc9-ae30-e3eef15f739d";
string userEmail = "muratsesen@tbj78.onmicrosoft.com";
//

OutlookContext context = new OutlookContext();
SqliteRepository repository = new SqliteRepository(context);


var choice = -1;
while (choice != 0)
{
    Console.WriteLine("Select a user");
    Console.WriteLine("0 to Exit");
    Console.WriteLine($"-1 Get Users");

    int i = 1;
    List<User> users = repository.GetAllUsers();
    foreach (var item in users)
    {
        Console.WriteLine($"{i++} - {item.DisplayName}");
    }

    try
    {
        choice = 3;//int.Parse(Console.ReadLine() ?? string.Empty);
        GraphHelper.userId = users[choice - 1].Id;
        Console.WriteLine("User 1 selected...");
    }
    catch (System.FormatException)
    {
        // Set to invalid value
        choice = -1;
    }

    if (choice > 0 && choice <= users.Count)
    {
        int action = -1;
        while (action != 0)
        {
            Console.WriteLine("-------------- Select an action ---------------");
            Console.WriteLine("0 to Exit");
            Console.WriteLine("1 - Get User Messages");
            Console.WriteLine("2 - *List Outbox");
            Console.WriteLine("3 - *List Drafts");
            Console.WriteLine("4 - *List Sent Items");
            Console.WriteLine("5 - *List Deleted Items");
            Console.WriteLine("6 - *List Calendar Events");
            Console.WriteLine("7 - *List Calendar Todos");
            Console.WriteLine("8 - GetFolders");
            Console.WriteLine("9 - Get User Messages by date");
            Console.WriteLine("10 - Get User Messages by date and folder=Inbox");
            Console.WriteLine("11 - Custom Search");
            Console.WriteLine("12 - Sent Email");
            try
            {
                action = 12; //int.Parse(Console.ReadLine() ?? string.Empty);
            }
            catch (System.FormatException)
            {
                // Set to invalid value
                action = -1;
            }

            await ShowSelectedActionAsync(action, GraphHelper.userId);

            break;
        }
    }
    else
    {
        var userDtoList = await GraphHelper.GetUsersAsync();
        repository.AddUsers(UserMapper.MapList(userDtoList));
    }
}
async Task ShowSelectedActionAsync(int action, string userId)
{
    if (action < 0) return;
    
    //await  CreateFolderAsync();
    //await DeleteFolderAsync();
    await ListFoldersAsync(userId);
    //await CreateMessageAsync();
    //await DeleteMessageAsync();
    //await MoveMessageAsync();
    //await CopyMessageAsync();
    //await ReplyMessageAsync();
    //await ReplyAllMessageAsync();
    //await ForwardMessageAsync();
    //await SendMeetingRequestAsync();
    //await SendMeetingResponseAsync();
    //await SendTaskRequestAsync();
    //await SendTaskResponseAsync();
    //await SendEmailAsync();
    //await SendSmsAsync();
    //await SendAppointmentRequestAsync();
    //await SendAppointmentResponseAsync();
    //await SendAppointmentCancellationAsync();
    //await SendAppointmentUpdateAsync();
    //await SendAppointmentCancellationUpdateAsync();
    //await SendAppointmentResponseUpdateAsync();
    //await SendAppointmentUpdateResponseAsync();
    //await SendAppointmentCancellationResponseUpdateAsync();
    //await SendAppointmentResponseCancellationUpdateAsync();
    //await SendAppointmentUpdateResponseCancellationUpdateAsync();
    //await SendAppointmentUpdateResponseCancellationResponseUpdateAsync();
    return;
    switch (action)
    {
        case 1:
            await ListMessagesAsync(userId);
            break;
        case 2:
            await ListOutboxAsync();
            break;
        case 3:
            await ListDraftsAsync();
            break;
        case 4:
            await ListSentItemsAsync();
            break;
        case 5:
            await ListDeletedItemsAsync();
            break;
        case 6:
            await ListCalendarEventsAsync();
            break;
        case 7:
            await ListCalendarTodosAsync();
            break;
        case 8:
            await ListFoldersAsync(userId);
            break;
        case 9:
            await ListMessagesByDateAsync(userId);
            break;
        case 10:
            await ListMessagesByDateAndFolderAsync(userId);
            break;
        case 11:
            await ListMessagesByCustomSearchAsync();
            break;
        case 12:
            await SendEmailAsync();
            break;
    }
}

Task ListCalendarTodosAsync()
{
    throw new NotImplementedException();
}

Task ListCalendarEventsAsync()
{
    throw new NotImplementedException();
}

Task ListDeletedItemsAsync()
{
    throw new NotImplementedException();
}

Task ListSentItemsAsync()
{
    throw new NotImplementedException();
}

Task ListDraftsAsync()
{
    throw new NotImplementedException();
}

Task ListOutboxAsync()
{
    throw new NotImplementedException();
}
async Task ListFoldersAsync(string userId)
{
    var folders = await GraphHelper.GetFoldersAsync();

    if (folders != null)
    {
        repository.AddUserFolders(FolderMapper.MapList(folders), userId);
    }
}


// <ListInboxSnippet>
async Task ListMessagesAsync(string userId)
{
    try
    {

        var messages = await GraphHelper.GetMessagesAsync();

        if (messages == null)
        {
            Console.WriteLine("No results returned.");
            return;
        }

        // int i = 1;
        // foreach (var message in messages)
        // {
        //     Console.WriteLine(i++ + "-" + message.Subject);
        // }

        Console.WriteLine("Saving Messages...");

        repository.SaveUserEmails(EmailMapper.MapToEmailList(messages), userId);

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error getting user's inbox: {ex.Message}");
    }
}
// </ListInboxSnippet>

async Task ListMessagesByDateAsync(string userId)
{
    try
    {
        var endDate = DateTime.UtcNow;
        var startDate = DateTime.UtcNow.AddDays(-7);

        var messages = await GraphHelper.GetMessagesAsync(startDate, endDate);


        if (messages == null)
        {
            Console.WriteLine("No results returned.");
            return;
        }

        // int i = 1;
        // foreach (var message in messages)
        // {
        //     Console.WriteLine(i++ + "-" + message.Subject);
        // }

        Console.WriteLine("Saving Messages...");

        repository.SaveUserEmails(EmailMapper.MapToEmailList(messages), userId);

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error getting user's inbox: {ex.Message}");
    }
}
async Task ListMessagesByDateAndFolderAsync(string userId)
{
    try
    {
        var endDate = DateTime.UtcNow;
        var startDate = DateTime.UtcNow.AddDays(-7);

        var messages = await GraphHelper.GetMessagesAsync(startDate, endDate, folderId: "AAMkADg4MDZlMWFjLWM0MWEtNDkxOS04NDE4LTA5ZGU3MjQ0ZjZlYQAuAAAAAADwB27-tbzMR4fKxnJNQWu0AQBwoKHBUBf5Tp89QVe-iBX9AAAAAAEMAAA=");


        if (messages == null)
        {
            Console.WriteLine("No results returned.");
            return;
        }

        // int i = 1;
        // foreach (var message in messages)
        // {
        //     Console.WriteLine(i++ + "-" + message.Subject);
        // }

        Console.WriteLine("Saving Messages...");

        repository.SaveUserEmails(EmailMapper.MapToEmailList(messages), userId);

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error getting user's inbox: {ex.Message}");
    }
}
async Task ListMessagesByCustomSearchAsync()
{
    try
    {
        var endDate = DateTime.UtcNow;
        var startDate = DateTime.UtcNow.AddDays(-7);
        var folderId = "AAMkADg4MDZlMWFjLWM0MWEtNDkxOS04NDE4LTA5ZGU3MjQ0ZjZlYQAuAAAAAADwB27-tbzMR4fKxnJNQWu0AQBwoKHBUBf5Tp89QVe-iBX9AAAAAAEMAAA=";
        var from = "sesenmurat@hotmail.com";
        var ccRecipents = "msesenceng@gmail.com";

        var messages = await GraphHelper.GetMessagesAsync(
            null, null, null, ccRecipents, null, null, null, null, null);


        if (messages == null)
        {
            Console.WriteLine("No results returned.");
            return;
        }

        Console.WriteLine("Recieved Messages: ", messages.Count);

        // int i = 1;Saving Messages...");

        //repository.SaveUserEmails(messages, userId);

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error getting user's inbox: {ex.Message}");
    }

    Console.ReadLine();
}

async Task SendEmailAsync()
{        
    try
    {

        SendMessageDto sendMessageDto = new SendMessageDto()
        {
            Message = new Message()
            {
                Subject = "Test",
                Body = new Body()
                {
                    Content = "Test",
                    ContentType = "Text"
                },
                ToRecipients = new List<ToRecipient>
                {
                    new ToRecipient(){
                       EmailAddress = new EmailAddress()
                        {
                            Address = "sesenmurat@hotmail.com"
                        }
                    }
                }
            }
        };

        await GraphHelper.SendMessageAsync(sendMessageDto);

        Console.WriteLine("Mail sent...");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error sending mail: {ex.Message}");
    }
    Console.ReadLine();
}
async Task CreateFolderAsync()
{        
    try
    {

        await GraphHelper.CreateFoldersAsync("Deneme Klasör2 ");

        Console.WriteLine("Mail sent...");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error sending mail: {ex.Message}");
    }
    Console.ReadLine();
}
async Task DeleteFolderAsync( string folderId)
{        
    try
    {

        await GraphHelper.DeleteFolderAsync(folderId);

        Console.WriteLine("Folder deleted...");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error  deleting folder: {ex.Message}");
    }
    Console.ReadLine();

}