namespace CmeFastHandlerSample
{
	partial class ConnectionSettingsForm
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
			this.dataGridViewConnections = new System.Windows.Forms.DataGridView();
			this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnHostIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bOk = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewConnections)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewConnections
			// 
			this.dataGridViewConnections.AllowUserToAddRows = false;
			this.dataGridViewConnections.AllowUserToDeleteRows = false;
			this.dataGridViewConnections.AllowUserToResizeRows = false;
			this.dataGridViewConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewConnections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewConnections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnCategory,
            this.ColumnIp,
            this.ColumnHostIp,
            this.ColumnPort});
			this.dataGridViewConnections.Location = new System.Drawing.Point(12, 12);
			this.dataGridViewConnections.Name = "dataGridViewConnections";
			this.dataGridViewConnections.Size = new System.Drawing.Size(634, 282);
			this.dataGridViewConnections.TabIndex = 0;
			this.dataGridViewConnections.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewConnections_CellValidating);
			// 
			// ColumnId
			// 
			this.ColumnId.DataPropertyName = "Id";
			this.ColumnId.HeaderText = "Id";
			this.ColumnId.Name = "ColumnId";
			this.ColumnId.ReadOnly = true;
			this.ColumnId.Visible = false;
			// 
			// ColumnCategory
			// 
			this.ColumnCategory.DataPropertyName = "Category";
			this.ColumnCategory.HeaderText = "Category";
			this.ColumnCategory.Name = "ColumnCategory";
			this.ColumnCategory.ReadOnly = true;
			this.ColumnCategory.Width = 150;
			// 
			// ColumnIp
			// 
			this.ColumnIp.DataPropertyName = "Ip";
			this.ColumnIp.HeaderText = "IP";
			this.ColumnIp.Name = "ColumnIp";
			// 
			// ColumnHostIp
			// 
			this.ColumnHostIp.DataPropertyName = "HostIp";
			this.ColumnHostIp.HeaderText = "Host IP";
			this.ColumnHostIp.Name = "ColumnHostIp";
			// 
			// ColumnPort
			// 
			this.ColumnPort.DataPropertyName = "Port";
			this.ColumnPort.HeaderText = "Port";
			this.ColumnPort.Name = "ColumnPort";
			this.ColumnPort.Width = 80;
			// 
			// bOk
			// 
			this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bOk.Location = new System.Drawing.Point(490, 300);
			this.bOk.Name = "bOk";
			this.bOk.Size = new System.Drawing.Size(75, 23);
			this.bOk.TabIndex = 1;
			this.bOk.Text = "Ok";
			this.bOk.UseVisualStyleBackColor = true;
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// bCancel
			// 
			this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancel.Location = new System.Drawing.Point(571, 300);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(75, 23);
			this.bCancel.TabIndex = 2;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = true;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// ConnectionSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(658, 332);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.dataGridViewConnections);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ConnectionSettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ConnectionSettingsForm";
			this.Load += new System.EventHandler(this.ConnectionSettingsForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectionSettingsForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewConnections)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewConnections;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCategory;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIp;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHostIp;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPort;
		private System.Windows.Forms.Button bOk;
		private System.Windows.Forms.Button bCancel;
	}
}