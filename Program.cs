
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Graph.Models;
using Azure.Identity;

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


int i = 1;
List<User> users = repository.GetAllUsers();

var userId = users[2].Id;
GraphHelper.userId = users[2].Id;
Console.WriteLine("Selected user id: " + GraphHelper.userId);

//Folder
//await CreateFolderAsync();
//await DeleteFolderAsync();
//await GetFoldersAsync(userId);
//await UpdateFolder(userId);

//Get user list
// var userDtoList = await GraphHelper.GetUsersAsync();
// repository.AddUsers(UserMapper.MapList(userDtoList));



async Task ShowSelectedActionAsync(int action, string userId)
{
    if (action < 0) return;

    switch (action)
    {
        case 1:
            await ListEmailAsync(userId);
            break;
        case 8:
            await GetFoldersAsync(userId);
            break;
        case 9:
            await ListEmailByDateAsync(userId);
            break;
        case 10:
            await ListEmailByDateAndFolderAsync(userId);
            break;
        case 11:
            await ListEmailByCustomSearchAsync();
            break;
        case 12:
            await SendEmailAsync();
            break;
    }
}

async Task ListEmailAsync(string userId)
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
async Task ListEmailByDateAsync(string userId)
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
async Task ListEmailByDateAndFolderAsync(string userId)
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
async Task ListEmailByCustomSearchAsync()
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
//Folder Methods
async Task GetFoldersAsync(string userId)
{
    //Folder email foreign key olayını çöz
    var folders = await GraphHelper.GetFoldersAsync();

    if (folders != null)
    {
        Console.WriteLine("Saving Folders...");
        Console.WriteLine(folders.Count);
        repository.AddUserFolders(FolderMapper.MapList(folders), userId);
    }
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
async Task DeleteFolderAsync(string folderId)
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
async Task UpdateFolder(string userId)
{
    try
    {
        var testFolderId = "AAMkADg4MDZlMWFjLWM0MWEtNDkxOS04NDE4LTA5ZGU3MjQ0ZjZlYQAuAAAAAADwB27-tbzMR4fKxnJNQWu0AQBwoKHBUBf5Tp89QVe-iBX9AAALQa0tAAA=";
        var res = await GraphHelper.UpdateFolderAsync(testFolderId, "Deneme Klasör4 ");
        if(res.Success)
        Console.WriteLine("Folder updated...");
        else
        {
            Console.WriteLine("Error  updating folder: ");
            Console.WriteLine(res.Content);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error  updating folder: {ex.Message}");
    }
    Console.ReadLine();

}