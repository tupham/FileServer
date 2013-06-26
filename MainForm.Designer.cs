/*
* Copyright 2005-2012 ONIX SOLUTIONS LIMITED. All rights reserved. 
* 
* This software owned by ONIX SOLUTIONS LIMITED [ONIXS] and is protected by copyright law 
* and international copyright treaties. 
* 
* Access to and use of the software is governed by the terms of the applicable ONIXS Software
* Services Agreement (the Agreement) and Customer end user license agreements granting 
* a non-assignable, non-transferable and non-exclusive license to use the software 
* for it's own data processing purposes under the terms defined in the Agreement.
* 
* Except as otherwise granted within the terms of the Agreement, copying or reproduction of any part 
* of this source code or associated reference material to any other location for further reproduction
* or redistribution, and any amendments to this copyright notice, are expressly prohibited. 
*
* Any reproduction or redistribution for sale or hiring of the Software not in accordance with 
* the terms of the Agreement is a violation of copyright law. 
*/
namespace CmeFastHandlerSample
{
    partial class MainForm
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
			System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
			System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.replayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectionSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.replayLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.connectButton = new System.Windows.Forms.Button();
			this.disconnectButton = new System.Windows.Forms.Button();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.numberOfProcessedMessagesToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.handlerStateToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.marketStateToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.eventsTabPage = new System.Windows.Forms.TabPage();
			this.events_ = new Onixs.FixControls.EventViewUserControl();
			this.securityDefinitionTabPage = new System.Windows.Forms.TabPage();
			this.securityDefinitionView_ = new CmeFastHandlerSample.SecurityDefinitionControl();
			this.bookManagementTabPage = new System.Windows.Forms.TabPage();
			this.bookView_ = new CmeFastHandlerSample.BookViewControl();
			this.channelLabel_ = new System.Windows.Forms.Label();
			this.environmentLabel = new System.Windows.Forms.Label();
			this.channelIdComboBox = new System.Windows.Forms.ComboBox();
			this.updateTimeLabel = new System.Windows.Forms.Label();
			this.replayModeCheckBox = new System.Windows.Forms.CheckBox();
			toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.eventsTabPage.SuspendLayout();
			this.securityDefinitionTabPage.SuspendLayout();
			this.bookManagementTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripStatusLabel
			// 
			toolStripStatusLabel.Name = "toolStripStatusLabel";
			toolStripStatusLabel.Size = new System.Drawing.Size(178, 19);
			toolStripStatusLabel.Text = "Number of Processed Messages:";
			// 
			// toolStripStatusLabel1
			// 
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new System.Drawing.Size(76, 19);
			toolStripStatusLabel1.Text = "Market State:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(13, 37);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(87, 13);
			label1.TabIndex = 36;
			label1.Tag = "See config.xml";
			label1.Text = "CME Channel Id:";
			// 
			// label2
			// 
			label2.Location = new System.Drawing.Point(412, 37);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(69, 13);
			label2.TabIndex = 40;
			label2.Text = "Environment:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(620, 37);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(51, 13);
			label3.TabIndex = 42;
			label3.Text = "Updated:";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.replayToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(814, 24);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
			this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.cutToolStripMenuItem.Text = "Cu&t";
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
			this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
			this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.pasteToolStripMenuItem.Text = "&Paste";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.selectAllToolStripMenuItem.Text = "Select &All";
			// 
			// replayToolStripMenuItem
			// 
			this.replayToolStripMenuItem.Name = "replayToolStripMenuItem";
			this.replayToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionSettingsToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.settingsToolStripMenuItem.Text = "&Settings";
			// 
			// connectionSettingsToolStripMenuItem
			// 
			this.connectionSettingsToolStripMenuItem.Name = "connectionSettingsToolStripMenuItem";
			this.connectionSettingsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.connectionSettingsToolStripMenuItem.Text = "&Connection Settings...";
			this.connectionSettingsToolStripMenuItem.Click += new System.EventHandler(this.connectionSettingsToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// replayLogFileToolStripMenuItem
			// 
			this.replayLogFileToolStripMenuItem.Name = "replayLogFileToolStripMenuItem";
			this.replayLogFileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			// 
			// connectButton
			// 
			this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.connectButton.Location = new System.Drawing.Point(609, 671);
			this.connectButton.Name = "connectButton";
			this.connectButton.Size = new System.Drawing.Size(75, 23);
			this.connectButton.TabIndex = 8;
			this.connectButton.Text = "Connect";
			this.toolTip.SetToolTip(this.connectButton, "Join IP Mutlicast Groups");
			this.connectButton.UseVisualStyleBackColor = true;
			this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
			// 
			// disconnectButton
			// 
			this.disconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.disconnectButton.Enabled = false;
			this.disconnectButton.Location = new System.Drawing.Point(710, 671);
			this.disconnectButton.Name = "disconnectButton";
			this.disconnectButton.Size = new System.Drawing.Size(91, 23);
			this.disconnectButton.TabIndex = 9;
			this.disconnectButton.Text = "Disconnect";
			this.toolTip.SetToolTip(this.disconnectButton, "Leave IP Multicast Groups");
			this.disconnectButton.UseVisualStyleBackColor = true;
			this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripStatusLabel,
            this.numberOfProcessedMessagesToolStripStatusLabel,
            this.toolStripStatusLabel2,
            this.handlerStateToolStripStatusLabel,
            toolStripStatusLabel1,
            this.marketStateToolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 702);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.ShowItemToolTips = true;
			this.statusStrip.Size = new System.Drawing.Size(814, 24);
			this.statusStrip.TabIndex = 6;
			this.statusStrip.Text = "statusStrip1";
			// 
			// numberOfProcessedMessagesToolStripStatusLabel
			// 
			this.numberOfProcessedMessagesToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.numberOfProcessedMessagesToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
			this.numberOfProcessedMessagesToolStripStatusLabel.Name = "numberOfProcessedMessagesToolStripStatusLabel";
			this.numberOfProcessedMessagesToolStripStatusLabel.Size = new System.Drawing.Size(17, 19);
			this.numberOfProcessedMessagesToolStripStatusLabel.Text = "0";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(81, 19);
			this.toolStripStatusLabel2.Text = "Handler State:";
			// 
			// handlerStateToolStripStatusLabel
			// 
			this.handlerStateToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.handlerStateToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
			this.handlerStateToolStripStatusLabel.Name = "handlerStateToolStripStatusLabel";
			this.handlerStateToolStripStatusLabel.Size = new System.Drawing.Size(55, 19);
			this.handlerStateToolStripStatusLabel.Text = "Stopped";
			// 
			// marketStateToolStripStatusLabel
			// 
			this.marketStateToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
						| System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.marketStateToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
			this.marketStateToolStripStatusLabel.Name = "marketStateToolStripStatusLabel";
			this.marketStateToolStripStatusLabel.Size = new System.Drawing.Size(66, 19);
			this.marketStateToolStripStatusLabel.Text = "Undefined";
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.eventsTabPage);
			this.tabControl.Controls.Add(this.securityDefinitionTabPage);
			this.tabControl.Controls.Add(this.bookManagementTabPage);
			this.tabControl.Location = new System.Drawing.Point(12, 73);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(789, 592);
			this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl.TabIndex = 35;
			// 
			// eventsTabPage
			// 
			this.eventsTabPage.Controls.Add(this.events_);
			this.eventsTabPage.Location = new System.Drawing.Point(4, 22);
			this.eventsTabPage.Name = "eventsTabPage";
			this.eventsTabPage.Size = new System.Drawing.Size(781, 566);
			this.eventsTabPage.TabIndex = 2;
			this.eventsTabPage.Text = "Events";
			this.eventsTabPage.UseVisualStyleBackColor = true;
			// 
			// events_
			// 
			this.events_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.events_.Location = new System.Drawing.Point(0, 0);
			this.events_.MinimumSize = new System.Drawing.Size(543, 100);
			this.events_.Name = "events_";
			this.events_.Size = new System.Drawing.Size(781, 566);
			this.events_.TabIndex = 0;
			// 
			// securityDefinitionTabPage
			// 
			this.securityDefinitionTabPage.Controls.Add(this.securityDefinitionView_);
			this.securityDefinitionTabPage.Location = new System.Drawing.Point(4, 22);
			this.securityDefinitionTabPage.Name = "securityDefinitionTabPage";
			this.securityDefinitionTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.securityDefinitionTabPage.Size = new System.Drawing.Size(781, 566);
			this.securityDefinitionTabPage.TabIndex = 0;
			this.securityDefinitionTabPage.Text = "Security Definition";
			this.securityDefinitionTabPage.UseVisualStyleBackColor = true;
			// 
			// securityDefinitionView_
			// 
			this.securityDefinitionView_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.securityDefinitionView_.Location = new System.Drawing.Point(3, 3);
			this.securityDefinitionView_.Name = "securityDefinitionView_";
			this.securityDefinitionView_.Size = new System.Drawing.Size(775, 560);
			this.securityDefinitionView_.TabIndex = 0;
			// 
			// bookManagementTabPage
			// 
			this.bookManagementTabPage.Controls.Add(this.bookView_);
			this.bookManagementTabPage.Location = new System.Drawing.Point(4, 22);
			this.bookManagementTabPage.Name = "bookManagementTabPage";
			this.bookManagementTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.bookManagementTabPage.Size = new System.Drawing.Size(781, 566);
			this.bookManagementTabPage.TabIndex = 1;
			this.bookManagementTabPage.Text = "Book Management";
			this.bookManagementTabPage.UseVisualStyleBackColor = true;
			// 
			// bookView_
			// 
			this.bookView_.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bookView_.Location = new System.Drawing.Point(3, 3);
			this.bookView_.Name = "bookView_";
			this.bookView_.Size = new System.Drawing.Size(775, 560);
			this.bookView_.TabIndex = 0;
			// 
			// channelLabel_
			// 
			this.channelLabel_.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.channelLabel_.Location = new System.Drawing.Point(239, 36);
			this.channelLabel_.Name = "channelLabel_";
			this.channelLabel_.Size = new System.Drawing.Size(145, 15);
			this.channelLabel_.TabIndex = 37;
			this.channelLabel_.Tag = "See config.xml";
			this.channelLabel_.Text = "Channel Label";
			// 
			// environmentLabel
			// 
			this.environmentLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.environmentLabel.Location = new System.Drawing.Point(482, 36);
			this.environmentLabel.Name = "environmentLabel";
			this.environmentLabel.Size = new System.Drawing.Size(136, 15);
			this.environmentLabel.TabIndex = 38;
			this.environmentLabel.Text = "environmentLabel";
			// 
			// channelIdComboBox
			// 
			this.channelIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.channelIdComboBox.FormattingEnabled = true;
			this.channelIdComboBox.Location = new System.Drawing.Point(101, 33);
			this.channelIdComboBox.Name = "channelIdComboBox";
			this.channelIdComboBox.Size = new System.Drawing.Size(132, 21);
			this.channelIdComboBox.TabIndex = 39;
			this.channelIdComboBox.SelectedIndexChanged += new System.EventHandler(this.channelIdComboBox_SelectedIndexChanged);
			// 
			// updateTimeLabel
			// 
			this.updateTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.updateTimeLabel.Location = new System.Drawing.Point(673, 36);
			this.updateTimeLabel.Name = "updateTimeLabel";
			this.updateTimeLabel.Size = new System.Drawing.Size(124, 15);
			this.updateTimeLabel.TabIndex = 41;
			this.updateTimeLabel.Text = "Update Time";
			// 
			// replayModeCheckBox
			// 
			this.replayModeCheckBox.AutoSize = true;
			this.replayModeCheckBox.Checked = true;
			this.replayModeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.replayModeCheckBox.Location = new System.Drawing.Point(482, 675);
			this.replayModeCheckBox.Name = "replayModeCheckBox";
			this.replayModeCheckBox.Size = new System.Drawing.Size(88, 17);
			this.replayModeCheckBox.TabIndex = 43;
			this.replayModeCheckBox.Text = "Replay mode";
			this.replayModeCheckBox.UseVisualStyleBackColor = true;
            this.replayModeCheckBox.Checked = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(814, 726);
			this.Controls.Add(this.replayModeCheckBox);
			this.Controls.Add(label3);
			this.Controls.Add(this.updateTimeLabel);
			this.Controls.Add(label2);
			this.Controls.Add(this.channelIdComboBox);
			this.Controls.Add(this.environmentLabel);
			this.Controls.Add(this.channelLabel_);
			this.Controls.Add(label1);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.disconnectButton);
			this.Controls.Add(this.connectButton);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "CME FAST Handler SAMPLE by Onix Solutions";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.eventsTabPage.ResumeLayout(false);
			this.securityDefinitionTabPage.ResumeLayout(false);
			this.bookManagementTabPage.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage securityDefinitionTabPage;
        private System.Windows.Forms.TabPage bookManagementTabPage;
        private SecurityDefinitionControl securityDefinitionView_;
        private System.Windows.Forms.ToolStripMenuItem replayToolStripMenuItem;
        private BookViewControl bookView_;
        private System.Windows.Forms.ToolStripMenuItem replayLogFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel numberOfProcessedMessagesToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel marketStateToolStripStatusLabel;
        private System.Windows.Forms.TabPage eventsTabPage;

        private Onixs.FixControls.EventViewUserControl events_;
        private System.Windows.Forms.Label channelLabel_;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel handlerStateToolStripStatusLabel;
        private System.Windows.Forms.Label environmentLabel;
        private System.Windows.Forms.ComboBox channelIdComboBox;
        private System.Windows.Forms.Label updateTimeLabel;
		private System.Windows.Forms.ToolStripMenuItem connectionSettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.CheckBox replayModeCheckBox;
    }
}

