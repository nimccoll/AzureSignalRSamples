using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageSender
{
    public partial class FSingleHubServerFilterCore : Form
    {
        public FSingleHubServerFilterCore()
        {
            InitializeComponent();
        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44349/");
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
