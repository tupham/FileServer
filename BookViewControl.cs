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
using Onixs.CmeFastHandler;

namespace CmeFastHandlerSample
{
    public partial class BookViewControl : UserControl
    {
        public BookViewControl()
        {
            InitializeComponent();
        }

        public void OnConsolidatedOrderBookUpdated(object sender, Handler.OrderBookUpdatedEventArgs e)
        {
            // XXX: We cannot update GUI from Handler's thread directly, so BeginInvoke is required.
            BeginInvoke(new OnConsolidatedOrderBookUpdatedDelegate(OnConsolidatedOrderBookUpdated), e);
        }

        public void OnSecurityDefinitionReceived(object sender, Handler.SecurityDefinitionReceivedEventArgs e)
        {
            this.securityId2description_[e.SecurityId] = e.SecurityDescription;
        }

        public void Clear()
        {
            this.securityId2description_.Clear();
            this.securityId2book_.Clear();
            this.securityIdComboBox.Items.Clear();
        }

        private Dictionary<string, string> securityId2description_ = new Dictionary<string, string>();

        private delegate void OnConsolidatedOrderBookUpdatedDelegate(Handler.OrderBookUpdatedEventArgs e);

        private Dictionary<string, IOrderBook> securityId2book_ = new Dictionary<string, IOrderBook>();

        private void OnConsolidatedOrderBookUpdated(Handler.OrderBookUpdatedEventArgs e)
        {
            try
            {
                if (double.NaN == e.Book.LastTradePrice)
                {
                    Trace.WriteLine("Book " + e.Book.SecurityId + " : LastTradePrice: " + e.Book.LastTradePrice);
                }

                this.securityId2book_[e.Book.SecurityId] = e.Book;

                if (null != this.securityIdComboBox.SelectedItem && this.securityIdComboBox.SelectedItem.ToString() == e.Book.SecurityId)
                {
                    UpdateOrderBookView();
                }
                else
                {
                    if (!this.securityIdComboBox.Items.Contains(e.Book.SecurityId))
                    {
                        this.securityIdComboBox.Items.Add(e.Book.SecurityId);

                        if (!this.selectedIndexWasChanged_)
                        {
                            this.securityIdComboBox.SelectedIndex = 0;
                            securityIDsComboBox_SelectedIndexChanged(this, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Unhandled Exception in BookVkewControl.OnConsolidatedOrderBookUpdated: " + ex);
            }
        }

        private void securityIDsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.selectedIndexWasChanged_)
            {
                this.selectedIndexWasChanged_ = true;
            }

            UpdateOrderBookView();
        }

        private void UpdateOrderBookView()
        {
            if (null == this.securityIdComboBox.SelectedItem)
            {
                return;
            }

            var securityId = this.securityIdComboBox.SelectedItem.ToString();

            if (this.securityId2description_.ContainsKey(securityId))
            {
                this.securityDescriptionTextBox.Text = this.securityId2description_[securityId];
            }

            var book = this.securityId2book_[securityId];

            if (book.Bids.Count > 0)
            {
                this.lvlBuy1.SetPriceLevel(book.Bids[0]);
            }
            else
            {
                this.lvlBuy1.Reset();
            }
            if (book.Bids.Count > 1)
            {
                this.lvlBuy2.SetPriceLevel(book.Bids[1]);
            }
            else
            {
                this.lvlBuy2.Reset();
            }
            if (book.Bids.Count > 2)
            {
                this.lvlBuy3.SetPriceLevel(book.Bids[2]);
            }
            else
            {
                this.lvlBuy3.Reset();
            }
            if (book.Bids.Count > 3)
            {
                this.lvlBuy4.SetPriceLevel(book.Bids[3]);
            }
            else
            {
                this.lvlBuy4.Reset();
            }
            if (book.Bids.Count > 4)
            {
                this.lvlBuy5.SetPriceLevel(book.Bids[4]);
            }
            else
            {
                this.lvlBuy5.Reset();
            }
            if (book.Bids.Count > 5)
            {
                this.lvlBuy6.SetPriceLevel(book.Bids[5]);
            }
            else
            {
                this.lvlBuy6.Reset();
            }
            if (book.Bids.Count > 6)
            {
                this.lvlBuy7.SetPriceLevel(book.Bids[6]);
            }
            else
            {
                this.lvlBuy7.Reset();
            }
            if (book.Bids.Count > 7)
            {
                this.lvlBuy8.SetPriceLevel(book.Bids[7]);
            }
            else
            {
                this.lvlBuy8.Reset();
            }
            if (book.Bids.Count > 8)
            {
                this.lvlBuy9.SetPriceLevel(book.Bids[8]);
            }
            else
            {
                this.lvlBuy9.Reset();
            }
            if (book.Bids.Count > 9)
            {
                this.lvlBuy10.SetPriceLevel(book.Bids[9]);
            }
            else
            {
                this.lvlBuy10.Reset();
            }

            if (book.Asks.Count > 0)
            {
                this.lvlSell1.SetPriceLevel(book.Asks[0]);
            }
            else
            {
                this.lvlSell1.Reset();
            }
            if (book.Asks.Count > 1)
            {
                this.lvlSell2.SetPriceLevel(book.Asks[1]);
            }
            else
            {
                this.lvlSell2.Reset();
            }
            if (book.Asks.Count > 2)
            {
                this.lvlSell3.SetPriceLevel(book.Asks[2]);
            }
            else
            {
                this.lvlSell3.Reset();
            }
            if (book.Asks.Count > 3)
            {
                this.lvlSell4.SetPriceLevel(book.Asks[3]);
            }
            else
            {
                this.lvlSell4.Reset();
            }
            if (book.Asks.Count > 4)
            {
                this.lvlSell5.SetPriceLevel(book.Asks[4]);
            }
            else
            {
                this.lvlSell5.Reset();
            }
            if (book.Asks.Count > 5)
            {
                this.lvlSell6.SetPriceLevel(book.Asks[5]);
            }
            else
            {
                this.lvlSell6.Reset();
            }
            if (book.Asks.Count > 6)
            {
                this.lvlSell7.SetPriceLevel(book.Asks[6]);
            }
            else
            {
                this.lvlSell7.Reset();
            }
            if (book.Asks.Count > 7)
            {
                this.lvlSell8.SetPriceLevel(book.Asks[7]);
            }
            else
            {
                this.lvlSell8.Reset();
            }
            if (book.Asks.Count > 8)
            {
                this.lvlSell9.SetPriceLevel(book.Asks[8]);
            }
            else
            {
                this.lvlSell9.Reset();
            }
            if (book.Asks.Count > 9)
            {
                this.lvlSell10.SetPriceLevel(book.Asks[9]);
            }
            else
            {
                this.lvlSell10.Reset();
            }

            if (double.NaN != book.HighTradePrice)
            {
                this.highestTradePriceTextBox.Text = book.HighTradePrice.ToString();
            }

            if (double.NaN != book.LowTradePrice)
            {
                this.lowestTradePriceTextBox.Text = book.LowTradePrice.ToString();
            }

            if (double.NaN != book.LastTradePrice)
            {
                this.lastTradePriceTextBox.Text = book.LastTradePrice.ToString();
            }

            this.lastTradeQuantityTextBox.Text = book.LastTradeQuantity.ToString();
        }

        private bool selectedIndexWasChanged_;
    }
}