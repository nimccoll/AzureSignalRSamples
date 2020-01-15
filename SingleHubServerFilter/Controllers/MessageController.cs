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
using SingleHubServerFilter.Hubs;
using SingleHubServerFilter.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SingleHubServerFilter.Controllers
{
    public class MessageController : ApiController
    {
        private static IHubContext _context = null;

        public MessageController()
        {
            if (_context == null) _context = GlobalHost.ConnectionManager.GetHubContext("MessageHub");
        }

        public void Post(Message message)
        {
            List<KeyValuePair<string, Client>> selectedClients = MessageHub.RegisteredClients.Where(c => c.Value.Location == message.Location).ToList();
            if (selectedClients != null)
            {
                foreach (KeyValuePair<string, Client> client in selectedClients)
                {
                    _context.Clients.Client(client.Value.ConnectionId).displayMessage(message);
                }
            }
        }
    }
}