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
using System.Windows.Forms;

namespace MessageSender
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
        }

        private void btnSingleHubServerFilter_Click(object sender, EventArgs e)
        {
            FSingleHubServerFilter form = new FSingleHubServerFilter();
            form.Show();
        }

        private void btnSingleHubClientFilter_Click(object sender, EventArgs e)
        {
            FSingleHubClientFilter form = new FSingleHubClientFilter();
            form.Show();

        }

        private void btnMultipleHubServerFilter_Click(object sender, EventArgs e)
        {
            FMultipleHubServerFilter form = new FMultipleHubServerFilter();
            form.Show();
        }

        private void btnMultipleHubServerFilterCore_Click(object sender, EventArgs e)
        {
            FMultipleHubServerFilterCore form = new FMultipleHubServerFilterCore();
            form.Show();
        }
    }
}
