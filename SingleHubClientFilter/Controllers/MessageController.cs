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
using SingleHubClientFilter.Models;
using System.Web.Http;

namespace SingleHubClientFilter.Controllers
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
            _context.Clients.All.displayMessage(message);
        }
    }
}