namespace MessageSender
{
    partial class FMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSingleHubServerFilter = new System.Windows.Forms.Button();
            this.btnSingleHubClientFilter = new System.Windows.Forms.Button();
            this.btnMultipleHubServerFilter = new System.Windows.Forms.Button();
            this.btnMultipleHubServerFilterCore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSingleHubServerFilter
            // 
            this.btnSingleHubServerFilter.Location = new System.Drawing.Point(367, 156);
            this.btnSingleHubServerFilter.Margin = new System.Windows.Forms.Padding(6);
            this.btnSingleHubServerFilter.Name = "btnSingleHubServerFilter";
            this.btnSingleHubServerFilter.Size = new System.Drawing.Size(334, 44);
            this.btnSingleHubServerFilter.TabIndex = 0;
            this.btnSingleHubServerFilter.Text = "Single Hub Server Filter";
            this.btnSingleHubServerFilter.UseVisualStyleBackColor = true;
            this.btnSingleHubServerFilter.Click += new System.EventHandler(this.btnSingleHubServerFilter_Click);
            // 
            // btnSingleHubClientFilter
            // 
            this.btnSingleHubClientFilter.Location = new System.Drawing.Point(367, 246);
            this.btnSingleHubClientFilter.Margin = new System.Windows.Forms.Padding(6);
            this.btnSingleHubClientFilter.Name = "btnSingleHubClientFilter";
            this.btnSingleHubClientFilter.Size = new System.Drawing.Size(334, 44);
            this.btnSingleHubClientFilter.TabIndex = 1;
            this.btnSingleHubClientFilter.Text = "Single Hub Client Filter";
            this.btnSingleHubClientFilter.UseVisualStyleBackColor = true;
            this.btnSingleHubClientFilter.Click += new System.EventHandler(this.btnSingleHubClientFilter_Click);
            // 
            // btnMultipleHubServerFilter
            // 
            this.btnMultipleHubServerFilter.Location = new System.Drawing.Point(367, 336);
            this.btnMultipleHubServerFilter.Margin = new System.Windows.Forms.Padding(6);
            this.btnMultipleHubServerFilter.Name = "btnMultipleHubServerFilter";
            this.btnMultipleHubServerFilter.Size = new System.Drawing.Size(334, 44);
            this.btnMultipleHubServerFilter.TabIndex = 2;
            this.btnMultipleHubServerFilter.Text = "Multiple Hub Server Filter";
            this.btnMultipleHubServerFilter.UseVisualStyleBackColor = true;
            this.btnMultipleHubServerFilter.Click += new System.EventHandler(this.btnMultipleHubServerFilter_Click);
            // 
            // btnMultipleHubServerFilterCore
            // 
            this.btnMultipleHubServerFilterCore.Location = new System.Drawing.Point(367, 426);
            this.btnMultipleHubServerFilterCore.Margin = new System.Windows.Forms.Padding(6);
            this.btnMultipleHubServerFilterCore.Name = "btnMultipleHubServerFilterCore";
            this.btnMultipleHubServerFilterCore.Size = new System.Drawing.Size(334, 44);
            this.btnMultipleHubServerFilterCore.TabIndex = 3;
            this.btnMultipleHubServerFilterCore.Text = "Multiple Hub Server Filter Core";
            this.btnMultipleHubServerFilterCore.UseVisualStyleBackColor = true;
            this.btnMultipleHubServerFilterCore.Click += new System.EventHandler(this.btnMultipleHubServerFilterCore_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 598);
            this.Controls.Add(this.btnMultipleHubServerFilterCore);
            this.Controls.Add(this.btnMultipleHubServerFilter);
            this.Controls.Add(this.btnSingleHubClientFilter);
            this.Controls.Add(this.btnSingleHubServerFilter);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignalR Message Sender";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSingleHubServerFilter;
        private System.Windows.Forms.Button btnSingleHubClientFilter;
        private System.Windows.Forms.Button btnMultipleHubServerFilter;
        private System.Windows.Forms.Button btnMultipleHubServerFilterCore;
    }
}

