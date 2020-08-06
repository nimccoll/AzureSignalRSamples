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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using SingleHubServerFilter.Core.Hubs;
using SingleHubServerFilter.Core.Models;
using SingleHubServerFilter.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace SingleHubServerFilter.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private static IHubContext<MessageHub> _context = null;
        private MessageCacheService _messageCacheService;

        public MessageController(IConfiguration configuration, IHubContext<MessageHub> context)
        {
            if (_context == null) _context = context;
            _messageCacheService = new MessageCacheService(configuration);
        }

        public void Post(Message message)
        {
            _messageCacheService.CacheMessage(message);

            List<KeyValuePair<string, Client>> selectedClients = MessageHub.RegisteredClients.Where(c => c.Value.Location == message.Location).ToList();
            if (selectedClients != null)
            {
                foreach (KeyValuePair<string, Client> client in selectedClients)
                {
                    _context.Clients.Client(client.Value.ConnectionId).SendAsync("displayMessage", message);
                }
            }
        }
    }
}
