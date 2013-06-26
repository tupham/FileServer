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
    partial class NewsForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.headlineTextBox = new System.Windows.Forms.TextBox();
            this.newsBodyTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(52, 13);
            label1.TabIndex = 0;
            label1.Text = "Headline:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(29, 54);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(31, 13);
            label2.TabIndex = 1;
            label2.Text = "Text:";
            // 
            // headlineTextBox
            // 
            this.headlineTextBox.Location = new System.Drawing.Point(62, 13);
            this.headlineTextBox.Name = "headlineTextBox";
            this.headlineTextBox.ReadOnly = true;
            this.headlineTextBox.Size = new System.Drawing.Size(301, 20);
            this.headlineTextBox.TabIndex = 2;
            // 
            // newsBodyTextBox
            // 
            this.newsBodyTextBox.Location = new System.Drawing.Point(62, 51);
            this.newsBodyTextBox.Multiline = true;
            this.newsBodyTextBox.Name = "newsBodyTextBox";
            this.newsBodyTextBox.ReadOnly = true;
            this.newsBodyTextBox.Size = new System.Drawing.Size(301, 116);
            this.newsBodyTextBox.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(155, 182);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // NewsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 219);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.newsBodyTextBox);
            this.Controls.Add(this.headlineTextBox);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Name = "NewsForm";
            this.Text = "NewsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox headlineTextBox;
        private System.Windows.Forms.TextBox newsBodyTextBox;
        private System.Windows.Forms.Button okButton;
    }
}