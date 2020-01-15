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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace MessageSender
{
    public partial class FMultipleHubServerFilter : Form
    {
        public FMultipleHubServerFilter()
        {
            InitializeComponent();
        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:1034/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Message message = new Message() { Location = ddlLocation.SelectedItem.ToString(), MessageId = Guid.NewGuid().ToString() };
                HttpResponseMessage response = await client.PostAsJsonAsync("/api/message", message);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Message sent successfully!");
                }
            }
        }
    }
}
