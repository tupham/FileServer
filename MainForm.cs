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

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Windows.Forms;
using Onixs.CmeFastHandler;

namespace CmeFastHandlerSample
{
    public partial class MainForm : Form
    {
        private bool cacheSecurityDefinitions;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string environment;
            var updateTime = new DateTime();

            var channelConfigurationFile = ConfigurationManager.AppSettings["ChannelConfigurationFile"];
            this.channels_ = CmeChannelConfigurationReader.ReadConfiguration(channelConfigurationFile, out environment, out updateTime);

            foreach (var channel in this.channels_)
            {
                this.channelIdComboBox.Items.Add(channel.Id);
            }

            var configuredChannelId = ConfigurationManager.AppSettings["ChannelId"];
            var channelIndex = this.channelIdComboBox.Items.IndexOf(configuredChannelId);
            if (-1 == channelIndex)
            {
                channelIndex = 0;
            }

            this.channelIdComboBox.SelectedIndex = channelIndex;

            this.environmentLabel.Text = environment;
            this.updateTimeLabel.Text = updateTime.ToString("u", CultureInfo.InvariantCulture);

            ConstructHandler();
        }

        private void ConstructHandler()
        {
            this.handler_ = new Handler(this.channels_[this.channelIdComboBox.SelectedIndex].Id);

            Handler.LogTrace("Sample Application 2.0.0.0");

            this.handler_.ChannelConfigurationFile = ConfigurationManager.AppSettings["ChannelConfigurationFile"];

            this.handler_.FastTemplateFile = ConfigurationManager.AppSettings["FastTemplateFile"];

            this.handler_.UseInstrumentReplayFeedA = true;
            this.handler_.UseInstrumentReplayFeedB = false;

            this.handler_.UseSnapshotFeedA = true;
            this.handler_.UseSnapshotFeedB = false;

            if (ConfigurationManager.AppSettings["DisposeFixMessages"] != null)
            {
                if (ConfigurationManager.AppSettings["DisposeFixMessages"].ToLowerInvariant() == "true")
                {
                    this.handler_.DisposeFixMessages = true;
                }
                else if (ConfigurationManager.AppSettings["DisposeFixMessages"].ToLowerInvariant() == "false")
                {
                    this.handler_.DisposeFixMessages = false;
                }
            }

            if (ConfigurationManager.AppSettings["RecoverSecurityDefinitionsOnGap"] != null)
            {
                if (ConfigurationManager.AppSettings["RecoverSecurityDefinitionsOnGap"].ToLowerInvariant() == "true")
                {
                    this.handler_.RecoverSecurityDefinitionsOnGap = true;
                }
                else if (ConfigurationManager.AppSettings["RecoverSecurityDefinitionsOnGap"].ToLowerInvariant() == "false")
                {
                    this.handler_.RecoverSecurityDefinitionsOnGap = false;
                }
            }

            if (ConfigurationManager.AppSettings["SubchannelsFilter"] != null)
            {
                var strValues = ConfigurationManager.AppSettings["SubchannelsFilter"].Split(new[] {';', ','}, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < strValues.Length; i++)
                {
                    this.handler_.AddSubchannelFilter(int.Parse(strValues[i]));
                }
            }

            if (ConfigurationManager.AppSettings["SecurityIdsFilter"] != null)
            {
                var strValues = ConfigurationManager.AppSettings["SecurityIdsFilter"].Split(new[] {';', ','}, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < strValues.Length; i++)
                {
                    this.handler_.AddSecurityIdFilter(strValues[i]);
                }
            }

            if (ConfigurationManager.AppSettings["SecurityDescriptionsFilter"] != null)
            {
                var strValues = ConfigurationManager.AppSettings["SecurityDescriptionsFilter"].Split(new[] {';', ','}, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < strValues.Length; i++)
                {
                    this.handler_.AddSecurityDescriptionFilter(strValues[i]);
                }
            }

            if (ConfigurationManager.AppSettings["CacheSecurityDefinitions"] != null)
            {
                bool.TryParse(ConfigurationManager.AppSettings["CacheSecurityDefinitions"], out this.cacheSecurityDefinitions);
            }

            var localNetworkInterface = ConfigurationManager.AppSettings["LocalNetworkInterface"];
            if (!String.IsNullOrEmpty(localNetworkInterface))
            {
                this.handler_.LocalNetworkInterface = IPAddress.Parse(localNetworkInterface);
            }

            this.handler_.ReplayFinished += handler_ReplayFinished;
            this.handler_.ReplayError += handler_ReplayError;

            this.handler_.SecurityDefinitionReceived += this.securityDefinitionView_.OnSecurityDefinitionReceived;

            this.handler_.SecurityDefinitionReceived += this.bookView_.OnSecurityDefinitionReceived;

            this.handler_.SecurityDefinitionReceived += handler_SecurityDefinitionReceived;

            this.handler_.ConsolidatedOrderBookUpdated += this.bookView_.OnConsolidatedOrderBookUpdated;
            this.handler_.RegularOrderBookUpdated += handler_RegularOrderBookUpdated;
            this.handler_.ImpliedOrderBookUpdated += handler_ImpliedOrderBookUpdated;
            this.handler_.ConsolidatedOrderBookUpdated += handler_ConsolidatedOrderBookUpdated;

            this.handler_.NewsReceived += handler_NewsReceived;

            this.handler_.Error += handler_Error;

            this.handler_.Warning += handler_Warning;

            this.handler_.Info += handler_Info;

            this.handler_.NoDataOnFeedReceived += handler_NoDataOnFeedReceived;

            this.handler_.StateChanged += handler_StateChanged;

            this.handler_.SecurityStatusChanged += handler_SecurityStatusChanged;

            this.handler_.MessageProcessingFinished += handler_MessageProcessingFinished;

            this.handler_.Trade += handler_Trade;

            this.handler_.Statistics += handler_Statistics;
        }

        private void handler_ReplayError(object sender, Handler.ReplayErrorEventArgs e)
        {
            Invoke((MethodInvoker) (() =>
                {
                    this.disconnectButton.Enabled = false;
                    this.connectButton.Enabled = true;
                    this.connectionSettingsToolStripMenuItem.Enabled = true;
                    this.events_.LogError(e.Description);
                }
                                   ));
        }

        private void handler_ReplayFinished(object sender, EventArgs e)
        {
            Invoke((MethodInvoker) (() =>
                {
                    this.disconnectButton.Enabled = false;
                    this.connectButton.Enabled = true;
                    this.connectionSettingsToolStripMenuItem.Enabled = true;
                }
                                   ));
        }

        private void handler_RegularOrderBookUpdated(object sender, Handler.OrderBookUpdatedEventArgs e)
        {
            OrderBookHelper.Validate(e.Book);
        }

        private void handler_ImpliedOrderBookUpdated(object sender, Handler.OrderBookUpdatedEventArgs e)
        {
            OrderBookHelper.Validate(e.Book);
        }

        private void handler_ConsolidatedOrderBookUpdated(object sender, Handler.OrderBookUpdatedEventArgs e)
        {
            OrderBookHelper.Validate(e.Book);
        }

        private List<ChannelConfiguration> channels_;

        private void handler_SecurityDefinitionReceived(object sender, Handler.SecurityDefinitionReceivedEventArgs e)
        {
            ++this.numberOfProcessedMessages_;

            // XXX: We cannot update GUI from Handler's thread directly, so BeginInvoke is required.            
            this.statusStrip.BeginInvoke(new UpdateStatusBarDelegate(UpdateStatusBar), new object[] {this.numberOfProcessedMessages_});
        }

        private void handler_Trade(object sender, Handler.TradeEventArgs e)
        {
            this.events_.LogInfo(e.ToString());
        }

        private void handler_Statistics(object sender, Handler.StatisticsEventArgs e)
        {
            this.events_.LogInfo(e.ToString());
        }

        private void handler_MessageProcessingFinished(object sender, Handler.MessageProcessingFinishedEventArgs e)
        {
            if (e.ReceivingTimestamp > 0)
            {
                var latency = TimestampHelper.TicksToMicroseconds(TimestampHelper.Ticks - e.ReceivingTimestamp);
                Handler.LogTrace("Message was processed for " + latency + " microseconds.");
            }

            ++this.numberOfProcessedMessages_;

            // XXX: We cannot update GUI from Handler's thread directly, so BeginInvoke is required.            
            this.statusStrip.BeginInvoke(new UpdateStatusBarDelegate(UpdateStatusBar), new object[] {this.numberOfProcessedMessages_});
        }

        private delegate void UpdateStatusBarDelegate(int numberOfProcessedMessages);

        private void UpdateStatusBar(int numberOfProcessedMessages)
        {
            this.numberOfProcessedMessagesToolStripStatusLabel.Text = numberOfProcessedMessages.ToString();
        }

        private void handler_StateChanged(object sender, Handler.StateChangedEventArgs e)
        {
            this.events_.LogInfo("State changed from " + e.OldState + " to " + e.NewState);

            if (e.NewState == HandlerState.SecurityDefinitionsRecoveryStarted)
            {
                this.securityDefinitionView_.Clear();
            }

            if (e.NewState == HandlerState.Stopped)
            {
                this.connectionSettingsToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.connectionSettingsToolStripMenuItem.Enabled = false;
            }

            // XXX: We cannot update GUI from Handler's thread directly, so BeginInvoke is required.            
            this.statusStrip.BeginInvoke(new UpdateHandlerStateDelegate(UpdateHandlerState), new object[] {e.NewState.ToString()});
        }

        private delegate void UpdateHandlerStateDelegate(string state);

        private void UpdateHandlerState(string state)
        {
            this.handlerStateToolStripStatusLabel.Text = state;
        }

        private void handler_NoDataOnFeedReceived(object sender, Handler.NoDataOnFeedReceivedEventArgs e)
        {
            this.events_.LogWarning("There is no data on feed '" + e.FeedName + "' during " + e.Timeout + " ms");
        }

        private void handler_Info(object sender, Handler.InfoEventArgs e)
        {
            this.events_.LogInfo(e.Reason);
        }

        private void handler_Warning(object sender, Handler.WarningEventArgs e)
        {
            this.events_.LogWarning(e.Description);
        }

        private void handler_Error(object sender, Handler.ErrorEventArgs e)
        {
            this.events_.LogError(e.Description);
        }

        private int numberOfProcessedMessages_;

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (this.replayModeCheckBox.Checked)
            {
                ReplayLogFile("SampleLog.txt");
            }
            else
            {
                Connect();
            }

            this.connectButton.Enabled = false;
            this.disconnectButton.Enabled = true;
            this.connectionSettingsToolStripMenuItem.Enabled = false;
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            Disconnect();

            this.disconnectButton.Enabled = false;
            this.connectButton.Enabled = true;
            this.connectionSettingsToolStripMenuItem.Enabled = true;
        }

        private void Connect()
        {
            this.numberOfProcessedMessages_ = 0;

            this.handler_.Start(BooksMaintenanceOptions.All, this.cacheSecurityDefinitions);
        }

        private void Disconnect()
        {
            this.handler_.Stop();

            this.securityDefinitionView_.Clear();

            this.bookView_.Clear();
        }

        private void ReplayLogFile(string fileName)
        {
            this.numberOfProcessedMessages_ = 0;

            this.securityDefinitionView_.Clear();

            this.bookView_.Clear();

            this.handler_.Start(BooksMaintenanceOptions.All, new ReplayOptions(fileName) {DelayBetweenMessages = 3});
        }

        private Handler handler_;

        private void handler_SecurityStatusChanged(object sender, Handler.SecurityStatusChangedEventArgs e)
        {
            this.events_.LogInfo(e.ToString());

            // XXX: We cannot update GUI from Handler's thread directly, so BeginInvoke is required.            
            this.statusStrip.BeginInvoke(new UpdateMarketStateDelegate(UpdateMarketState), new object[] {e.SecurityId, e.SecurityStatus});
        }

        private delegate void UpdateMarketStateDelegate(string secturityId, SecurityStatus securityStatus);

        private void UpdateMarketState(string secturityId, SecurityStatus securityStatus)
        {
            if (secturityId != null)
            {
                this.marketStateToolStripStatusLabel.Text = string.Format("SecurityId={0}, Status={1}", secturityId, securityStatus);
            }
            else
            {
                this.marketStateToolStripStatusLabel.Text = string.Format("SecurityId=, Status={0}", securityStatus);
            }
        }

        private void handler_NewsReceived(object sender, Handler.NewsReceivedEventArgs e)
        {
            // XXX: We cannot update GUI from Handler's thread directly, so BeginInvoke is required.
            BeginInvoke(new ShowNewsDelegate(ShowNews), new object[] {e.Headline, e.Body});
        }

        private delegate void ShowNewsDelegate(string headline, string text);

        private void ShowNews(string headline, string text)
        {
            using (var form = new NewsForm(headline, text))
            {
                form.ShowDialog();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new AboutDlg())
            {
                form.ShowDialog();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text;
            if (ActiveControl is SecurityDefinitionControl)
            {
                text = this.securityDefinitionView_.ActiveControl.Text;
            }
            else if (ActiveControl is BookViewControl)
            {
                text = this.bookView_.ActiveControl.Text;
            }
            else
            {
                text = ActiveControl.Text;
            }

            Clipboard.SetDataObject(text);
        }

        private void channelIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox) sender;
            this.channelLabel_.Text = this.channels_[comboBox.SelectedIndex].Lavel;

            ConstructHandler();
        }

        private void connectionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new ConnectionSettingsForm(this.channels_[this.channelIdComboBox.SelectedIndex].Id, this.handler_.ChannelConfigurationFile))
            {
                form.ShowDialog(this);
            }
        }
    }

    public static class OrderBookHelper
    {
        public static void Validate(IOrderBook book)
        {
            if (book.Asks.Count + book.Bids.Count == 0)
            {
                return;
            }

            if (book.Asks.Count > book.Depth)
            {
                throw new ApplicationException("Asks count exceeds book depth in " + book);
            }

            for (var i = 1; i < book.Asks.Count; i++)
            {
                if (book.Asks[i - 1].Price == book.Asks[i].Price)
                {
                    //throw new ApplicationException("Asks are duplicated in " + book.ToString());
                    if (book.Asks[i - 1].Price > book.Asks[i].Price)
                    {
                        throw new ApplicationException("Asks are unordered in " + book);
                    }
                }
            }

            if (book.Bids.Count > book.Depth)
            {
                throw new ApplicationException("Bids count exceeds book depth in " + book);
            }

            for (var i = 1; i < book.Bids.Count; i++)
            {
                if (book.Bids[i - 1].Price == book.Bids[i].Price)
                {
                    //throw new ApplicationException("Bids are duplicated in " + book.ToString());
                    if (book.Bids[i - 1].Price < book.Bids[i].Price)
                    {
                        throw new ApplicationException("Bids are unordered in " + book);
                    }
                }
            }
        }
    }
}