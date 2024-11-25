﻿using Microsoft.AspNetCore.SignalR;

namespace backend.Hubs
{
    public class ChatHub : Hub
    {

        public async Task MessageSent(string message, string userName)
        {
            await this.Clients.All.SendAsync("messageRecieved", message, userName);
        }
    }
}
