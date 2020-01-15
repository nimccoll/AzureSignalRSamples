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
using Microsoft.Owin;
using Owin;
using System.Configuration;
using System.Net;

[assembly: OwinStartup(typeof(MultipleHubServerFilter.Startup))]

namespace MultipleHubServerFilter
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string connectionString = ConfigurationManager.ConnectionStrings["Azure:SignalR:ConnectionString"].ToString();
            // By default Azure SignalR allocates 5 server connections per hub. This includes 
            // 5 server connections for the default hub. Since the Free tier of the service typically
            // used for development purposes only allows a total of 10 server connections override the
            // default number of server connections per hub and set it to 1 during development.
            app.MapAzureSignalR("MultipleHubServerFilter", options =>
            {
                options.ConnectionCount = 1;
                options.ConnectionString = connectionString;
            });
        }
    }
}
