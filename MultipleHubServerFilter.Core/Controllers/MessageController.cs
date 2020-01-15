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
using MultipleHubServerFilter.Core.Hubs;
using MultipleHubServerFilter.Core.Models;

namespace MultipleHubServerFilter.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private static IHubContext<NorthMessageHub> _northContext = null;
        private static IHubContext<SouthMessageHub> _southContext = null;
        private static IHubContext<EastMessageHub> _eastContext = null;
        private static IHubContext<WestMessageHub> _westContext = null;

        public MessageController(IHubContext<NorthMessageHub> northContext, IHubContext<SouthMessageHub> southContext, IHubContext<EastMessageHub> eastContext, IHubContext<WestMessageHub> westContext)
        {
            // In ASP.Net Core hub instances will be injected by the dependency injection container
            _northContext = northContext;
            _southContext = southContext;
            _eastContext = eastContext;
            _westContext = westContext;
        }

        public void Post(Message message)
        {
            switch (message.Location)
            {
                case "North":
                    _northContext.Clients.All.SendAsync("displayMessage", message);
                    break;
                case "South":
                    _southContext.Clients.All.SendAsync("displayMessage", message);
                    break;
                case "East":
                    _eastContext.Clients.All.SendAsync("displayMessage", message);
                    break;
                case "West":
                    _westContext.Clients.All.SendAsync("displayMessage", message);
                    break;
                default:
                    break;
            }
        }
    }
}