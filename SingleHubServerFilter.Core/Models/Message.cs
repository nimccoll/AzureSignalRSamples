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
using System;
using System.Runtime.Serialization;

namespace SingleHubServerFilter.Core.Models
{
    [Serializable]
    [DataContract]
    public class Message
    {
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string MessageId { get; set; }
    }
}
