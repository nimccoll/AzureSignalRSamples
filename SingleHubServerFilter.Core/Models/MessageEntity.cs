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
using Microsoft.Azure.Cosmos.Table;
using System;

namespace SingleHubServerFilter.Core.Models
{
    public class MessageEntity : TableEntity
    {
        public MessageEntity() { }

        public MessageEntity(string location, DateTime timestamp, string messageId)
        {
            this.PartitionKey = location;
            this.RowKey = timestamp.ToString("yyyyMMddHHmmssfffff");
            this.MessageId = messageId;
        }

        public string MessageId { get; set; }
    }
}
