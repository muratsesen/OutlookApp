// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
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
while(choice != 0)
{
    Console.WriteLine("Select a user");
    Console.WriteLine("0 to Exit");
    int i = 1;
    foreach (var item in repository.GetAllUsers())
    {
        Console.WriteLine($"{i++} - {item.DisplayName}");
    }

    try
    {
        choice = int.Parse(Console.ReadLine() ?? string.Empty);
    }
    catch (System.FormatException)
    {
        // Set to invalid value
        choice = -1;
    }
    if (choice > 0 && choice <= repository.GetAllUsers().Count)
    {
        int action = -1;
        while(action != 0)
        {
            Console.WriteLine("Select an action");
            Console.WriteLine("0 to Exit");
            Console.WriteLine("1 - List Inbox");
            Console.WriteLine("2 - List Outbox");
            Console.WriteLine("3 - List Drafts");
            Console.WriteLine("4 - List Sent Items");
            Console.WriteLine("5 - List Deleted Items");
            Console.WriteLine("6 - List Calendar Events");
            Console.WriteLine("7 - List Calendar Todos");
            try
            {
                action = int.Parse(Console.ReadLine() ?? string.Empty);
            }
            catch (System.FormatException)
            {
                // Set to invalid value
                action = -1;
            }
            ShowSelectedActionAsync(action);

        }
    }

}
async Task ShowSelectedActionAsync(int action)
{
    switch (action)
    {
        case 1:
            await ListInboxAsync();
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

var users = repository.GetAllUsers();
}

// <GreetUserSnippet>
async Task GreetUserAsync()
{
    try
    {
        var user = await GraphHelper.GetUserAsync();
        Console.WriteLine($"Hello, {user?.DisplayName}!");
        // For Work/school accounts, email is in Mail property
        // Personal accounts, email is in UserPrincipalName
        Console.WriteLine($"Email: {user?.Mail ?? user?.UserPrincipalName ?? ""}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error getting user: {ex.Message}");
    }
}

// <DisplayAccessTokenSnippet>
async Task DisplayAccessTokenAsync()
{
    try
    {
        var userToken = await GraphHelper.GetUserTokenAsync();
        Console.WriteLine($"User token: {userToken}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error getting user access token: {ex.Message}");
    }
}
// </DisplayAccessTokenSnippet>

// <ListInboxSnippet>
async Task ListInboxAsync()
{
    try
    {
        var messagePage = await GraphHelper.GetInboxAsync();

        if (messagePage?.Value == null)
        {
            Console.WriteLine("No results returned.");
            return;
        }

        var count = 0;
        // Output each message's details
        foreach (var message in messagePage.Value)
        {
            Console.WriteLine($"Count:{++count}");
            Console.WriteLine($"Message: {message.Subject ?? "NO SUBJECT"}");
            Console.WriteLine($"Body: {message.Body}");
            Console.WriteLine($"HasAttachments: {message.HasAttachments}");
            Console.WriteLine($"  From: {message.From?.EmailAddress?.Name}");
            Console.WriteLine($"  Status: {(message.IsRead!.Value ? "Read" : "Unread")}");
            Console.WriteLine($"  Received: {message.ReceivedDateTime?.ToLocalTime().ToString()}");
        }

        // If NextPageRequest is not null, there are more messages
        // available on the server
        // Access the next page like:
        // var nextPageRequest = new MessagesRequestBuilder(messagePage.OdataNextLink, _userClient.RequestAdapter);
        // var nextPage = await nextPageRequest.GetAsync();
        var moreAvailable = !string.IsNullOrEmpty(messagePage.OdataNextLink);

        Console.WriteLine($"\nMore messages available? {moreAvailable}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error getting user's inbox: {ex.Message}");
    }
}
// </ListInboxSnippet>

// <SendMailSnippet>
async Task SendMailAsync()
{
    try
    {
        // Send mail to the signed-in user
        // Get the user for their email address
        var user = await GraphHelper.GetUserAsync();

        var userEmail = user?.Mail ?? user?.UserPrincipalName;

        if (string.IsNullOrEmpty(userEmail))
        {
            Console.WriteLine("Couldn't get your email address, canceling...");
            return;
        }

        await GraphHelper.SendMailAsync("Testing Microsoft Graph",
            "Hello world!", userEmail);

        Console.WriteLine("Mail sent.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error sending mail: {ex.Message}");
    }
}
// </SendMailSnippet>

// <MakeGraphCallSnippet>
async Task MakeGraphCallAsync()
{
    await GraphHelper.MakeGraphCallAsync();
}
// </MakeGraphCallSnippet>
