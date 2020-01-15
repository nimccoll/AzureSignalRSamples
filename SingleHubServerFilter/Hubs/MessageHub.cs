//===============================================================================
// Microsoft FastTrack for Azure
// Azure SignalR Service Examples
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using Microsoft.AspNet.SignalR;
using SingleHubServerFilter.Models;
using System.Threading.Tasks;

namespace SingleHubServerFilter.Hubs
{
    public class MessageHub : Hub
    {
        public static System.Collections.Concurrent.ConcurrentDictionary<string, Client> RegisteredClients = new System.Collections.Concurrent.ConcurrentDictionary<string, Client>();

        public void Register(string location)
        {
            Client client = null;
            if (RegisteredClients.TryGetValue(this.Context.ConnectionId, out client))
            {
                Client updatedClient = new Client() { ConnectionId = this.Context.ConnectionId, Location = location };
                RegisteredClients.TryUpdate(this.Context.ConnectionId, updatedClient, client);
            }
            else
            {
                client = new Client() { ConnectionId = this.Context.ConnectionId, Location = location };
                RegisteredClients.TryAdd(this.Context.ConnectionId, client);
            }
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Client client = null;
            RegisteredClients.TryRemove(this.Context.ConnectionId, out client);

            return base.OnDisconnected(stopCalled);
        }
    }
}