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
using System.Diagnostics;
using System.Windows.Forms;
using FIXForge.NET.FIX.FIX50;
using Onixs.CmeFastHandler;
using Message = FIXForge.NET.FIX.Message;

namespace CmeFastHandlerSample
{
    public partial class SecurityDefinitionControl : UserControl
    {
        public SecurityDefinitionControl()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            this.description2message_.Clear();
            this.securityComboBox.Items.Clear();
        }

        private delegate void OnSecurityDefinitionReceivedDelegate(Handler.SecurityDefinitionReceivedEventArgs e);

        public void OnSecurityDefinitionReceived(object sender, Handler.SecurityDefinitionReceivedEventArgs e)
        {
            // XXX: We cannot update GUI from the Handler's thread directly, so BeginInvoke is required.
            BeginInvoke(new OnSecurityDefinitionReceivedDelegate(OnSecurityDefinitionReceived), e);
        }

        private void OnSecurityDefinitionReceived(Handler.SecurityDefinitionReceivedEventArgs e)
        {
            var symbol = e.Definition[Tags.Symbol];

            this.securityComboBox.Items.Add(e.SecurityDescription);

            this.description2message_[e.SecurityDescription] = e.Definition;

            if (!this.selectedIndexWasChanged_)
            {
                this.securityComboBox.SelectedIndex = 0;
                securityComboBox_SelectedIndexChanged(this, null);
            }
        }

        private void ProcessSecurityDefinition(Message definition)
        {
            Debug.Assert(MsgType.SecurityDefinition == definition.Type);

            var symbol = definition[Tags.Symbol];

            var eventsGroup = definition.GetGroup(Tags.NoEvents);
            this.activationDateTextBox.Text = eventsGroup.Get(Tags.EventDate, 0);
            this.activationTimeTextBox.Text = eventsGroup.Get(1145, 0);
            this.expirationDateTextBox.Text = eventsGroup.Get(Tags.EventDate, 1);
            this.expirationTimeTextBox.Text = eventsGroup.Get(1145, 1);

            this.instrumentTypeTextBox.Text = definition.Get(Tags.CFICode);

            this.securityIDTextBox.Text = definition.Get(Tags.SecurityID);

            const int minPriceIncrementTag = 969;
            const int tradingReferencePrice = 1150;

            this.CalculatedTickValueTextBox.Text = definition.Get(minPriceIncrementTag);
            this.SettlementPriceTextBox.Text = definition.Get(tradingReferencePrice);

            var strikePrice = definition.Get(Tags.StrikePrice);
            if (null != strikePrice)
            {
                this.strikePriceTextBox.Text = strikePrice;
            }
        }

        private bool selectedIndexWasChanged_;

        private void securityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (! this.selectedIndexWasChanged_)
            {
                this.selectedIndexWasChanged_ = true;
            }

            var securityDescription = this.securityComboBox.SelectedItem.ToString();

            if (this.description2message_.ContainsKey(securityDescription))
            {
                var securityDefinition = this.description2message_[securityDescription];

                ProcessSecurityDefinition(securityDefinition);
            }
        }

        private Dictionary<string, Message> description2message_ = new Dictionary<string, Message>();
    }
}