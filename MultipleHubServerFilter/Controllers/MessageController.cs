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
using MultipleHubServerFilter.Models;
using System.Web.Http;

namespace MultipleHubServerFilter.Controllers
{
    public class MessageController : ApiController
    {
        private static IHubContext _northContext = null;
        private static IHubContext _southContext = null;
        private static IHubContext _eastContext = null;
        private static IHubContext _westContext = null;

        public MessageController()
        {
            if (_northContext == null) _northContext = GlobalHost.ConnectionManager.GetHubContext("NorthMessageHub");
            if (_southContext == null) _southContext = GlobalHost.ConnectionManager.GetHubContext("SouthMessageHub");
            if (_eastContext == null) _eastContext = GlobalHost.ConnectionManager.GetHubContext("EastMessageHub");
            if (_westContext == null) _westContext = GlobalHost.ConnectionManager.GetHubContext("WestMessageHub");
        }

        public void Post(Message message)
        {
            switch (message.Location)
            {
                case "North":
                    _northContext.Clients.All.displayMessage(message);
                    break;
                case "South":
                    _southContext.Clients.All.displayMessage(message);
                    break;
                case "East":
                    _eastContext.Clients.All.displayMessage(message);
                    break;
                case "West":
                    _westContext.Clients.All.displayMessage(message);
                    break;
                default:
                    break;
            }
        }
    }
}