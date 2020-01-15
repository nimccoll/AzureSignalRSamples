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
using System.Threading.Tasks;

namespace MultipleHubServerFilter.Hubs
{
    public class NorthMessageHub : Hub
    {
        public override Task OnConnected()
        {
            string connectionId = this.Context.ConnectionId;

            return base.OnConnected();
        }

        public void Hello()
        {
            Clients.All.hello();
        }
    }
}