namespace Queue_Monitoring
{
    partial class cMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cMainForm));
            this.cPreferencesmenuStrip = new System.Windows.Forms.MenuStrip();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPhoneStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripAnalystList = new System.Windows.Forms.ToolStripComboBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportIssuesOrAskForToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutQueueMonitoringSageERPX3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QueueGroupBox = new System.Windows.Forms.GroupBox();
            this.cReadyTextBox = new System.Windows.Forms.TextBox();
            this.cReadyQueue_HyperLink = new System.Windows.Forms.LinkLabel();
            this.cToolsTextBox = new System.Windows.Forms.TextBox();
            this.cToolsQueue_HyperLink = new System.Windows.Forms.LinkLabel();
            this.cQueueCycle = new System.Windows.Forms.Timer(this.components);
            this.PhoneStatusGroupBox = new System.Windows.Forms.GroupBox();
            this.cPhoneStatustextBox = new System.Windows.Forms.TextBox();
            this.cStatusPictureBox = new System.Windows.Forms.PictureBox();
            this.cCheckSchedule = new System.Windows.Forms.Timer(this.components);
            this.MasterTimer = new System.Windows.Forms.Timer(this.components);
            this.SnoozeTimer = new System.Windows.Forms.Timer(this.components);
            this.cPreferencesmenuStrip.SuspendLayout();
            this.QueueGroupBox.SuspendLayout();
            this.PhoneStatusGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cStatusPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cPreferencesmenuStrip
            // 
            this.cPreferencesmenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.cPreferencesmenuStrip.Location = new System.Drawing.Point(0, 0);
            this.cPreferencesmenuStrip.Name = "cPreferencesmenuStrip";
            this.cPreferencesmenuStrip.Size = new System.Drawing.Size(353, 24);
            this.cPreferencesmenuStrip.TabIndex = 4;
            this.cPreferencesmenuStrip.Text = "menuStrip1";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPhoneStatusToolStripMenuItem,
            this.alwaysOnTopToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripAnalystList});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences ";
            // 
            // showPhoneStatusToolStripMenuItem
            // 
            this.showPhoneStatusToolStripMenuItem.Checked = true;
            this.showPhoneStatusToolStripMenuItem.CheckOnClick = true;
            this.showPhoneStatusToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPhoneStatusToolStripMenuItem.Name = "showPhoneStatusToolStripMenuItem";
            this.showPhoneStatusToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.showPhoneStatusToolStripMenuItem.Text = "Show Phone Status";
            this.showPhoneStatusToolStripMenuItem.Visible = false;
            this.showPhoneStatusToolStripMenuItem.Click += new System.EventHandler(this.showPhoneStatusToolStripMenuItem_Click);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.CheckOnClick = true;
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "Always on Top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox1.Enabled = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 16);
            this.toolStripTextBox1.Text = "Analyst Name";
            this.toolStripTextBox1.Visible = false;
            // 
            // toolStripAnalystList
            // 
            this.toolStripAnalystList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.toolStripAnalystList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.toolStripAnalystList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripAnalystList.DropDownWidth = 130;
            this.toolStripAnalystList.Enabled = false;
            this.toolStripAnalystList.MaxDropDownItems = 20;
            this.toolStripAnalystList.Name = "toolStripAnalystList";
            this.toolStripAnalystList.Size = new System.Drawing.Size(121, 23);
            this.toolStripAnalystList.Sorted = true;
            this.toolStripAnalystList.Visible = false;
            this.toolStripAnalystList.DropDownClosed += new System.EventHandler(this.toolStripAnalystList_Leave);
            this.toolStripAnalystList.SelectedIndexChanged += new System.EventHandler(this.toolStripAnalystList_SelectedIndexChanged);
            this.toolStripAnalystList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripAnalystList_MouseDown);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseToolStripMenuItem,
            this.changeLogToolStripMenuItem,
            this.reportIssuesOrAskForToolStripMenuItem,
            this.aboutQueueMonitoringSageERPX3ToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.howToUseToolStripMenuItem.Text = "How to use";
            this.howToUseToolStripMenuItem.Visible = false;
            // 
            // changeLogToolStripMenuItem
            // 
            this.changeLogToolStripMenuItem.Name = "changeLogToolStripMenuItem";
            this.changeLogToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.changeLogToolStripMenuItem.Text = "Change Log";
            this.changeLogToolStripMenuItem.Click += new System.EventHandler(this.changeLogToolStripMenuItem_Click);
            // 
            // reportIssuesOrAskForToolStripMenuItem
            // 
            this.reportIssuesOrAskForToolStripMenuItem.Enabled = false;
            this.reportIssuesOrAskForToolStripMenuItem.Name = "reportIssuesOrAskForToolStripMenuItem";
            this.reportIssuesOrAskForToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.reportIssuesOrAskForToolStripMenuItem.Text = "Report Issues or ask for an Enhancement";
            this.reportIssuesOrAskForToolStripMenuItem.Visible = false;
            this.reportIssuesOrAskForToolStripMenuItem.Click += new System.EventHandler(this.reportIssuesOrAskForToolStripMenuItem_Click);
            // 
            // aboutQueueMonitoringSageERPX3ToolStripMenuItem
            // 
            this.aboutQueueMonitoringSageERPX3ToolStripMenuItem.Name = "aboutQueueMonitoringSageERPX3ToolStripMenuItem";
            this.aboutQueueMonitoringSageERPX3ToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.aboutQueueMonitoringSageERPX3ToolStripMenuItem.Text = "About Queue Monitoring Sage ERP X3";
            this.aboutQueueMonitoringSageERPX3ToolStripMenuItem.Click += new System.EventHandler(this.aboutQueueMonitoringSageERPX3ToolStripMenuItem_Click);
            // 
            // QueueGroupBox
            // 
            this.QueueGroupBox.Controls.Add(this.cReadyTextBox);
            this.QueueGroupBox.Controls.Add(this.cReadyQueue_HyperLink);
            this.QueueGroupBox.Controls.Add(this.cToolsTextBox);
            this.QueueGroupBox.Controls.Add(this.cToolsQueue_HyperLink);
            this.QueueGroupBox.Location = new System.Drawing.Point(12, 27);
            this.QueueGroupBox.Name = "QueueGroupBox";
            this.QueueGroupBox.Size = new System.Drawing.Size(329, 103);
            this.QueueGroupBox.TabIndex = 6;
            this.QueueGroupBox.TabStop = false;
            this.QueueGroupBox.Text = "Queue";
            // 
            // cReadyTextBox
            // 
            this.cReadyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cReadyTextBox.Location = new System.Drawing.Point(159, 63);
            this.cReadyTextBox.Name = "cReadyTextBox";
            this.cReadyTextBox.ReadOnly = true;
            this.cReadyTextBox.Size = new System.Drawing.Size(164, 13);
            this.cReadyTextBox.TabIndex = 7;
            this.cReadyTextBox.TabStop = false;
            // 
            // cReadyQueue_HyperLink
            // 
            this.cReadyQueue_HyperLink.AutoSize = true;
            this.cReadyQueue_HyperLink.Location = new System.Drawing.Point(15, 63);
            this.cReadyQueue_HyperLink.Name = "cReadyQueue_HyperLink";
            this.cReadyQueue_HyperLink.Size = new System.Drawing.Size(138, 13);
            this.cReadyQueue_HyperLink.TabIndex = 6;
            this.cReadyQueue_HyperLink.TabStop = true;
            this.cReadyQueue_HyperLink.Text = "Number of Ready Analysts :";
            this.cReadyQueue_HyperLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cReadyQueue_HyperLink_LinkClicked_1);
            // 
            // cToolsTextBox
            // 
            this.cToolsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cToolsTextBox.Location = new System.Drawing.Point(160, 30);
            this.cToolsTextBox.Name = "cToolsTextBox";
            this.cToolsTextBox.ReadOnly = true;
            this.cToolsTextBox.Size = new System.Drawing.Size(163, 13);
            this.cToolsTextBox.TabIndex = 5;
            this.cToolsTextBox.TabStop = false;
            this.cToolsTextBox.TextChanged += new System.EventHandler(this.cToolsTextBox_TextChanged);
            // 
            // cToolsQueue_HyperLink
            // 
            this.cToolsQueue_HyperLink.AutoSize = true;
            this.cToolsQueue_HyperLink.Location = new System.Drawing.Point(16, 30);
            this.cToolsQueue_HyperLink.Name = "cToolsQueue_HyperLink";
            this.cToolsQueue_HyperLink.Size = new System.Drawing.Size(137, 13);
            this.cToolsQueue_HyperLink.TabIndex = 2;
            this.cToolsQueue_HyperLink.TabStop = true;
            this.cToolsQueue_HyperLink.Text = "Sage ERP X3 Call Queue : ";
            this.cToolsQueue_HyperLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cToolsQueue_HyperLink_LinkClicked);
            // 
            // cQueueCycle
            // 
            this.cQueueCycle.Interval = 4000;
            this.cQueueCycle.Tick += new System.EventHandler(this.cQueueCycle_Tick);
            // 
            // PhoneStatusGroupBox
            // 
            this.PhoneStatusGroupBox.Controls.Add(this.cPhoneStatustextBox);
            this.PhoneStatusGroupBox.Controls.Add(this.cStatusPictureBox);
            this.PhoneStatusGroupBox.Location = new System.Drawing.Point(3, 150);
            this.PhoneStatusGroupBox.Name = "PhoneStatusGroupBox";
            this.PhoneStatusGroupBox.Size = new System.Drawing.Size(338, 113);
            this.PhoneStatusGroupBox.TabIndex = 7;
            this.PhoneStatusGroupBox.TabStop = false;
            this.PhoneStatusGroupBox.Text = "Your Phone Status";
            // 
            // cPhoneStatustextBox
            // 
            this.cPhoneStatustextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cPhoneStatustextBox.Location = new System.Drawing.Point(169, 19);
            this.cPhoneStatustextBox.Name = "cPhoneStatustextBox";
            this.cPhoneStatustextBox.ReadOnly = true;
            this.cPhoneStatustextBox.Size = new System.Drawing.Size(100, 13);
            this.cPhoneStatustextBox.TabIndex = 1;
            this.cPhoneStatustextBox.TabStop = false;
            // 
            // cStatusPictureBox
            // 
            this.cStatusPictureBox.BackgroundImage = global::Queue_Monitoring.Properties.Resources.OffReady;
            this.cStatusPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cStatusPictureBox.Location = new System.Drawing.Point(9, 19);
            this.cStatusPictureBox.Name = "cStatusPictureBox";
            this.cStatusPictureBox.Size = new System.Drawing.Size(100, 88);
            this.cStatusPictureBox.TabIndex = 0;
            this.cStatusPictureBox.TabStop = false;
            // 
            // cCheckSchedule
            // 
            this.cCheckSchedule.Interval = 300000;
            this.cCheckSchedule.Tick += new System.EventHandler(this.cCheckSchedule_Tick);
            // 
            // MasterTimer
            // 
            this.MasterTimer.Enabled = true;
            this.MasterTimer.Interval = 10000;
            this.MasterTimer.Tick += new System.EventHandler(this.MasterTimer_Tick);
            // 
            // SnoozeTimer
            // 
            this.SnoozeTimer.Interval = 300000;
            this.SnoozeTimer.Tick += new System.EventHandler(this.SnoozeTimer_Tick);
            // 
            // cMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(353, 276);
            this.Controls.Add(this.PhoneStatusGroupBox);
            this.Controls.Add(this.QueueGroupBox);
            this.Controls.Add(this.cPreferencesmenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.cPreferencesmenuStrip;
            this.MaximizeBox = false;
            this.Name = "cMainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Queue Monitoring Sage ERP X3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.cMainForm_FormClosing);
            this.Load += new System.EventHandler(this.cMainForm_Load);
            this.cPreferencesmenuStrip.ResumeLayout(false);
            this.cPreferencesmenuStrip.PerformLayout();
            this.QueueGroupBox.ResumeLayout(false);
            this.QueueGroupBox.PerformLayout();
            this.PhoneStatusGroupBox.ResumeLayout(false);
            this.PhoneStatusGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cStatusPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip cPreferencesmenuStrip;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.GroupBox QueueGroupBox;
        private System.Windows.Forms.TextBox cToolsTextBox;
        private System.Windows.Forms.LinkLabel cToolsQueue_HyperLink;
        private System.Windows.Forms.Timer cQueueCycle;
        private System.Windows.Forms.GroupBox PhoneStatusGroupBox;
        private System.Windows.Forms.TextBox cPhoneStatustextBox;
        private System.Windows.Forms.PictureBox cStatusPictureBox;
        private System.Windows.Forms.ToolStripMenuItem showPhoneStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripAnalystList;
        private System.Windows.Forms.Timer cCheckSchedule;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.Timer MasterTimer;
        private System.Windows.Forms.Timer SnoozeTimer;
        private System.Windows.Forms.TextBox cReadyTextBox;
        private System.Windows.Forms.LinkLabel cReadyQueue_HyperLink;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportIssuesOrAskForToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutQueueMonitoringSageERPX3ToolStripMenuItem;
    }
}

