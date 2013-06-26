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
    partial class BookViewControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label18;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label21;
            System.Windows.Forms.Label label23;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label22;
            System.Windows.Forms.Label label24;
            this.securityIdComboBox = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.securityDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.orderBookGroupBox = new System.Windows.Forms.GroupBox();
            this.lvlBuy5 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlBuy4 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlBuy3 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlBuy2 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlBuy1 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlBuy10 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlBuy9 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlBuy8 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlBuy7 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlBuy6 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlSell5 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlSell4 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlSell3 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlSell2 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlSell1 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlSell10 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlSell9 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlSell8 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlSell7 = new CmeFastHandlerSample.PriceLevelControl();
            this.lvlSell6 = new CmeFastHandlerSample.PriceLevelControl();
            this.tradeStatisticsGroupBox = new System.Windows.Forms.GroupBox();
            this.highestTradePriceTextBox = new System.Windows.Forms.TextBox();
            this.lowestTradePriceTextBox = new System.Windows.Forms.TextBox();
            this.lastTradeQuantityTextBox = new System.Windows.Forms.TextBox();
            this.lastTradePriceTextBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            this.orderBookGroupBox.SuspendLayout();
            this.tradeStatisticsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label1.Location = new System.Drawing.Point(29, 14);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(68, 15);
            label1.TabIndex = 1;
            label1.Text = "Security ID:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label18.Location = new System.Drawing.Point(216, 14);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(72, 15);
            label18.TabIndex = 38;
            label18.Text = "Description:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(97, 29);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(88, 13);
            label19.TabIndex = 0;
            label19.Text = "Last Trade Price:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(97, 53);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(103, 13);
            label20.TabIndex = 2;
            label20.Text = "Last Trade Quantity:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(407, 29);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(102, 13);
            label21.TabIndex = 4;
            label21.Text = "Lowest Trade Price:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(406, 53);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(104, 13);
            label23.TabIndex = 6;
            label23.Text = "Highest Trade Price:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label2.Location = new System.Drawing.Point(64, 21);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 16);
            label2.TabIndex = 2;
            label2.Text = "Buy:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label3.Location = new System.Drawing.Point(63, 44);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(42, 16);
            label3.TabIndex = 3;
            label3.Text = "Price:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label4.Location = new System.Drawing.Point(145, 44);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(59, 16);
            label4.TabIndex = 4;
            label4.Text = "Quantity:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label15.Location = new System.Drawing.Point(457, 45);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(59, 16);
            label15.TabIndex = 22;
            label15.Text = "Quantity:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label16.Location = new System.Drawing.Point(376, 45);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(42, 16);
            label16.TabIndex = 21;
            label16.Text = "Price:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label22.Location = new System.Drawing.Point(229, 44);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(82, 16);
            label22.TabIndex = 38;
            label22.Text = "Order Count:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label24.Location = new System.Drawing.Point(541, 45);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(82, 16);
            label24.TabIndex = 44;
            label24.Text = "Order Count:";
            // 
            // securityIdComboBox
            // 
            this.securityIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.securityIdComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.securityIdComboBox.FormattingEnabled = true;
            this.securityIdComboBox.Location = new System.Drawing.Point(101, 10);
            this.securityIdComboBox.Name = "securityIdComboBox";
            this.securityIdComboBox.Size = new System.Drawing.Size(109, 23);
            this.securityIdComboBox.TabIndex = 0;
            this.securityIdComboBox.SelectedIndexChanged += new System.EventHandler(this.securityIDsComboBox_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(377, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 16);
            this.label17.TabIndex = 20;
            this.label17.Text = "Sell:";
            // 
            // securityDescriptionTextBox
            // 
            this.securityDescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.securityDescriptionTextBox.Location = new System.Drawing.Point(289, 11);
            this.securityDescriptionTextBox.Name = "securityDescriptionTextBox";
            this.securityDescriptionTextBox.ReadOnly = true;
            this.securityDescriptionTextBox.Size = new System.Drawing.Size(104, 21);
            this.securityDescriptionTextBox.TabIndex = 39;
            // 
            // orderBookGroupBox
            // 
            this.orderBookGroupBox.Controls.Add(this.lvlBuy5);
            this.orderBookGroupBox.Controls.Add(this.lvlBuy4);
            this.orderBookGroupBox.Controls.Add(this.lvlBuy3);
            this.orderBookGroupBox.Controls.Add(this.lvlBuy2);
            this.orderBookGroupBox.Controls.Add(this.lvlBuy1);
            this.orderBookGroupBox.Controls.Add(this.lvlBuy10);
            this.orderBookGroupBox.Controls.Add(this.lvlBuy9);
            this.orderBookGroupBox.Controls.Add(this.lvlBuy8);
            this.orderBookGroupBox.Controls.Add(this.lvlBuy7);
            this.orderBookGroupBox.Controls.Add(this.lvlBuy6);
            this.orderBookGroupBox.Controls.Add(this.lvlSell5);
            this.orderBookGroupBox.Controls.Add(this.lvlSell4);
            this.orderBookGroupBox.Controls.Add(this.lvlSell3);
            this.orderBookGroupBox.Controls.Add(this.lvlSell2);
            this.orderBookGroupBox.Controls.Add(this.lvlSell1);
            this.orderBookGroupBox.Controls.Add(this.lvlSell10);
            this.orderBookGroupBox.Controls.Add(this.lvlSell9);
            this.orderBookGroupBox.Controls.Add(this.lvlSell8);
            this.orderBookGroupBox.Controls.Add(this.lvlSell7);
            this.orderBookGroupBox.Controls.Add(this.lvlSell6);
            this.orderBookGroupBox.Controls.Add(label24);
            this.orderBookGroupBox.Controls.Add(label22);
            this.orderBookGroupBox.Controls.Add(label2);
            this.orderBookGroupBox.Controls.Add(label3);
            this.orderBookGroupBox.Controls.Add(label4);
            this.orderBookGroupBox.Controls.Add(label15);
            this.orderBookGroupBox.Controls.Add(this.label17);
            this.orderBookGroupBox.Controls.Add(label16);
            this.orderBookGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orderBookGroupBox.Location = new System.Drawing.Point(19, 43);
            this.orderBookGroupBox.Name = "orderBookGroupBox";
            this.orderBookGroupBox.Size = new System.Drawing.Size(639, 369);
            this.orderBookGroupBox.TabIndex = 40;
            this.orderBookGroupBox.TabStop = false;
            this.orderBookGroupBox.Text = "Order Book:";
            // 
            // lvlBuy5
            // 
            this.lvlBuy5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlBuy5.Level = 5;
            this.lvlBuy5.Location = new System.Drawing.Point(6, 172);
            this.lvlBuy5.Name = "lvlBuy5";
            this.lvlBuy5.Size = new System.Drawing.Size(303, 24);
            this.lvlBuy5.TabIndex = 124;
            // 
            // lvlBuy4
            // 
            this.lvlBuy4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlBuy4.Level = 4;
            this.lvlBuy4.Location = new System.Drawing.Point(6, 145);
            this.lvlBuy4.Name = "lvlBuy4";
            this.lvlBuy4.Size = new System.Drawing.Size(303, 24);
            this.lvlBuy4.TabIndex = 123;
            // 
            // lvlBuy3
            // 
            this.lvlBuy3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlBuy3.Level = 3;
            this.lvlBuy3.Location = new System.Drawing.Point(6, 118);
            this.lvlBuy3.Name = "lvlBuy3";
            this.lvlBuy3.Size = new System.Drawing.Size(303, 24);
            this.lvlBuy3.TabIndex = 122;
            // 
            // lvlBuy2
            // 
            this.lvlBuy2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlBuy2.Level = 2;
            this.lvlBuy2.Location = new System.Drawing.Point(6, 91);
            this.lvlBuy2.Name = "lvlBuy2";
            this.lvlBuy2.Size = new System.Drawing.Size(303, 24);
            this.lvlBuy2.TabIndex = 121;
            // 
            // lvlBuy1
            // 
            this.lvlBuy1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlBuy1.Level = 1;
            this.lvlBuy1.Location = new System.Drawing.Point(6, 64);
            this.lvlBuy1.Name = "lvlBuy1";
            this.lvlBuy1.Size = new System.Drawing.Size(303, 24);
            this.lvlBuy1.TabIndex = 120;
            // 
            // lvlBuy10
            // 
            this.lvlBuy10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlBuy10.Level = 10;
            this.lvlBuy10.Location = new System.Drawing.Point(6, 307);
            this.lvlBuy10.Name = "lvlBuy10";
            this.lvlBuy10.Size = new System.Drawing.Size(303, 24);
            this.lvlBuy10.TabIndex = 119;
            // 
            // lvlBuy9
            // 
            this.lvlBuy9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlBuy9.Level = 9;
            this.lvlBuy9.Location = new System.Drawing.Point(6, 280);
            this.lvlBuy9.Name = "lvlBuy9";
            this.lvlBuy9.Size = new System.Drawing.Size(303, 24);
            this.lvlBuy9.TabIndex = 118;
            // 
            // lvlBuy8
            // 
            this.lvlBuy8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlBuy8.Level = 8;
            this.lvlBuy8.Location = new System.Drawing.Point(6, 253);
            this.lvlBuy8.Name = "lvlBuy8";
            this.lvlBuy8.Size = new System.Drawing.Size(303, 24);
            this.lvlBuy8.TabIndex = 117;
            // 
            // lvlBuy7
            // 
            this.lvlBuy7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlBuy7.Level = 7;
            this.lvlBuy7.Location = new System.Drawing.Point(6, 226);
            this.lvlBuy7.Name = "lvlBuy7";
            this.lvlBuy7.Size = new System.Drawing.Size(303, 24);
            this.lvlBuy7.TabIndex = 116;
            // 
            // lvlBuy6
            // 
            this.lvlBuy6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlBuy6.Level = 6;
            this.lvlBuy6.Location = new System.Drawing.Point(6, 199);
            this.lvlBuy6.Name = "lvlBuy6";
            this.lvlBuy6.Size = new System.Drawing.Size(303, 24);
            this.lvlBuy6.TabIndex = 115;
            // 
            // lvlSell5
            // 
            this.lvlSell5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlSell5.Level = 5;
            this.lvlSell5.Location = new System.Drawing.Point(319, 172);
            this.lvlSell5.Name = "lvlSell5";
            this.lvlSell5.Size = new System.Drawing.Size(303, 24);
            this.lvlSell5.TabIndex = 114;
            // 
            // lvlSell4
            // 
            this.lvlSell4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlSell4.Level = 4;
            this.lvlSell4.Location = new System.Drawing.Point(319, 145);
            this.lvlSell4.Name = "lvlSell4";
            this.lvlSell4.Size = new System.Drawing.Size(303, 24);
            this.lvlSell4.TabIndex = 113;
            // 
            // lvlSell3
            // 
            this.lvlSell3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlSell3.Level = 3;
            this.lvlSell3.Location = new System.Drawing.Point(319, 118);
            this.lvlSell3.Name = "lvlSell3";
            this.lvlSell3.Size = new System.Drawing.Size(303, 24);
            this.lvlSell3.TabIndex = 112;
            // 
            // lvlSell2
            // 
            this.lvlSell2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlSell2.Level = 2;
            this.lvlSell2.Location = new System.Drawing.Point(319, 91);
            this.lvlSell2.Name = "lvlSell2";
            this.lvlSell2.Size = new System.Drawing.Size(303, 24);
            this.lvlSell2.TabIndex = 111;
            // 
            // lvlSell1
            // 
            this.lvlSell1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlSell1.Level = 1;
            this.lvlSell1.Location = new System.Drawing.Point(319, 64);
            this.lvlSell1.Name = "lvlSell1";
            this.lvlSell1.Size = new System.Drawing.Size(303, 24);
            this.lvlSell1.TabIndex = 110;
            // 
            // lvlSell10
            // 
            this.lvlSell10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlSell10.Level = 10;
            this.lvlSell10.Location = new System.Drawing.Point(319, 307);
            this.lvlSell10.Name = "lvlSell10";
            this.lvlSell10.Size = new System.Drawing.Size(303, 24);
            this.lvlSell10.TabIndex = 104;
            // 
            // lvlSell9
            // 
            this.lvlSell9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlSell9.Level = 9;
            this.lvlSell9.Location = new System.Drawing.Point(319, 280);
            this.lvlSell9.Name = "lvlSell9";
            this.lvlSell9.Size = new System.Drawing.Size(303, 24);
            this.lvlSell9.TabIndex = 103;
            // 
            // lvlSell8
            // 
            this.lvlSell8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlSell8.Level = 8;
            this.lvlSell8.Location = new System.Drawing.Point(319, 253);
            this.lvlSell8.Name = "lvlSell8";
            this.lvlSell8.Size = new System.Drawing.Size(303, 24);
            this.lvlSell8.TabIndex = 102;
            // 
            // lvlSell7
            // 
            this.lvlSell7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlSell7.Level = 7;
            this.lvlSell7.Location = new System.Drawing.Point(319, 226);
            this.lvlSell7.Name = "lvlSell7";
            this.lvlSell7.Size = new System.Drawing.Size(303, 24);
            this.lvlSell7.TabIndex = 101;
            // 
            // lvlSell6
            // 
            this.lvlSell6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvlSell6.Level = 6;
            this.lvlSell6.Location = new System.Drawing.Point(319, 199);
            this.lvlSell6.Name = "lvlSell6";
            this.lvlSell6.Size = new System.Drawing.Size(303, 24);
            this.lvlSell6.TabIndex = 100;
            // 
            // tradeStatisticsGroupBox
            // 
            this.tradeStatisticsGroupBox.Controls.Add(this.highestTradePriceTextBox);
            this.tradeStatisticsGroupBox.Controls.Add(label23);
            this.tradeStatisticsGroupBox.Controls.Add(this.lowestTradePriceTextBox);
            this.tradeStatisticsGroupBox.Controls.Add(label21);
            this.tradeStatisticsGroupBox.Controls.Add(this.lastTradeQuantityTextBox);
            this.tradeStatisticsGroupBox.Controls.Add(label20);
            this.tradeStatisticsGroupBox.Controls.Add(this.lastTradePriceTextBox);
            this.tradeStatisticsGroupBox.Controls.Add(label19);
            this.tradeStatisticsGroupBox.Location = new System.Drawing.Point(19, 449);
            this.tradeStatisticsGroupBox.Name = "tradeStatisticsGroupBox";
            this.tradeStatisticsGroupBox.Size = new System.Drawing.Size(630, 87);
            this.tradeStatisticsGroupBox.TabIndex = 41;
            this.tradeStatisticsGroupBox.TabStop = false;
            this.tradeStatisticsGroupBox.Text = "Trade Statistics:";
            // 
            // highestTradePriceTextBox
            // 
            this.highestTradePriceTextBox.Location = new System.Drawing.Point(514, 49);
            this.highestTradePriceTextBox.Name = "highestTradePriceTextBox";
            this.highestTradePriceTextBox.Size = new System.Drawing.Size(100, 20);
            this.highestTradePriceTextBox.TabIndex = 7;
            // 
            // lowestTradePriceTextBox
            // 
            this.lowestTradePriceTextBox.Location = new System.Drawing.Point(514, 25);
            this.lowestTradePriceTextBox.Name = "lowestTradePriceTextBox";
            this.lowestTradePriceTextBox.Size = new System.Drawing.Size(100, 20);
            this.lowestTradePriceTextBox.TabIndex = 5;
            // 
            // lastTradeQuantityTextBox
            // 
            this.lastTradeQuantityTextBox.Location = new System.Drawing.Point(206, 49);
            this.lastTradeQuantityTextBox.Name = "lastTradeQuantityTextBox";
            this.lastTradeQuantityTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastTradeQuantityTextBox.TabIndex = 3;
            // 
            // lastTradePriceTextBox
            // 
            this.lastTradePriceTextBox.Location = new System.Drawing.Point(206, 25);
            this.lastTradePriceTextBox.Name = "lastTradePriceTextBox";
            this.lastTradePriceTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastTradePriceTextBox.TabIndex = 1;
            // 
            // BookViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tradeStatisticsGroupBox);
            this.Controls.Add(this.orderBookGroupBox);
            this.Controls.Add(this.securityDescriptionTextBox);
            this.Controls.Add(label18);
            this.Controls.Add(label1);
            this.Controls.Add(this.securityIdComboBox);
            this.Name = "BookViewControl";
            this.Size = new System.Drawing.Size(754, 587);
            this.orderBookGroupBox.ResumeLayout(false);
            this.orderBookGroupBox.PerformLayout();
            this.tradeStatisticsGroupBox.ResumeLayout(false);
            this.tradeStatisticsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox securityIdComboBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox securityDescriptionTextBox;
        private System.Windows.Forms.GroupBox orderBookGroupBox;
        private System.Windows.Forms.GroupBox tradeStatisticsGroupBox;
        private System.Windows.Forms.TextBox lastTradePriceTextBox;
        private System.Windows.Forms.TextBox lastTradeQuantityTextBox;
        private System.Windows.Forms.TextBox highestTradePriceTextBox;
        private System.Windows.Forms.TextBox lowestTradePriceTextBox;
        private PriceLevelControl lvlSell10;
        private PriceLevelControl lvlSell9;
        private PriceLevelControl lvlSell8;
        private PriceLevelControl lvlSell7;
        private PriceLevelControl lvlSell6;
        private PriceLevelControl lvlBuy5;
        private PriceLevelControl lvlBuy4;
        private PriceLevelControl lvlBuy3;
        private PriceLevelControl lvlBuy2;
        private PriceLevelControl lvlBuy1;
        private PriceLevelControl lvlBuy10;
        private PriceLevelControl lvlBuy9;
        private PriceLevelControl lvlBuy8;
        private PriceLevelControl lvlBuy7;
        private PriceLevelControl lvlBuy6;
        private PriceLevelControl lvlSell5;
        private PriceLevelControl lvlSell4;
        private PriceLevelControl lvlSell3;
        private PriceLevelControl lvlSell2;
        private PriceLevelControl lvlSell1;
    }
}
