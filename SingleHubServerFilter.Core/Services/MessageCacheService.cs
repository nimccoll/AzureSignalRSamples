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
using Microsoft.Extensions.Configuration;
using SingleHubServerFilter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SingleHubServerFilter.Core.Services
{
    public class MessageCacheService
    {
        private IConfiguration _configuration;
        private CloudStorageAccount _cloudStorageAccount;
        private CloudTableClient _cloudTableClient;
        private CloudTable _cloudTable;

        public MessageCacheService(IConfiguration configuration)
        {
            _configuration = configuration;
            _cloudStorageAccount = CloudStorageAccount.Parse(_configuration.GetValue<string>("Azure:Storage:ConnectionString"));
            _cloudTableClient = _cloudStorageAccount.CreateCloudTableClient(new TableClientConfiguration());
            _cloudTable = _cloudTableClient.GetTableReference("MessageCache");
            _cloudTable.CreateIfNotExists();
        }

        public void CacheMessage(Message message)
        {
            MessageEntity messageEntity = new MessageEntity(message.Location, DateTime.UtcNow, message.MessageId);
            TableOperation createOperation = TableOperation.Insert(messageEntity);
            TableResult result = _cloudTable.Execute(createOperation);
        }

        public List<Message> GetMessages(string location, DateTime timestamp)
        {
            List<Message> messages = new List<Message>();
            string rowKey = timestamp.ToString("yyyyMMddHHmmssfffff");
            string partitionFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, location);
            string rowFilter = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.GreaterThanOrEqual, rowKey);
            string filter = TableQuery.CombineFilters(partitionFilter, TableOperators.And, rowFilter);
            TableQuery<MessageEntity> tableQuery = new TableQuery<MessageEntity>().Where(filter);
            List<MessageEntity> messageEntities = _cloudTable.ExecuteQuery<MessageEntity>(tableQuery).ToList();
            foreach (MessageEntity me in messageEntities)
            {
                messages.Add(new Message()
                {
                    Location = me.PartitionKey,
                    MessageId = me.MessageId
                });
            }

            return messages;
        }
    }
}
