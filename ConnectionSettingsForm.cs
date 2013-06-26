using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace CmeFastHandlerSample
{
    public partial class ConnectionSettingsForm : Form
    {
        #region ConnectionDescription

        private class ConnectionDescription
        {
            public string Id;

            public string Category = " ";

            public string Ip;

            public string HostIp;

            public int Port;
        }

        #endregion ConnectionDescription

        private string channelId;

        private string channelConfigurationFile;

        private bool canClose;

        public ConnectionSettingsForm(string channelId, string channelConfigurationFile)
        {
            InitializeComponent();

            this.channelId = channelId;
            this.channelConfigurationFile = channelConfigurationFile;
        }

        private void ConnectionSettingsForm_Load(object sender, EventArgs e)
        {
            Text = "Connection settings for channel: " + this.channelId;

            var doc = new XmlDocument();
            doc.Load(this.channelConfigurationFile);

            var xpath = string.Format("/configuration/channel[@id='{0}']/connections/connection", this.channelId);
            var connectionNodes = doc.SelectNodes(xpath);
            if (connectionNodes.Count == 0)
            {
                throw new Exception("Cannot find connection node for channel node with id=" + this.channelId + " in " + this.channelConfigurationFile);
            }

            var connections = new List<ConnectionDescription>();

            foreach (XmlNode connection in connectionNodes)
            {
                var description = new ConnectionDescription();
                description.Id = connection.Attributes["id"].Value;

                foreach (XmlNode parameter in connection.ChildNodes)
                {
                    switch (parameter.Name)
                    {
                        case "ip":
                            description.Ip = parameter.InnerText.Trim();
                            break;

                        case "host-ip":
                            description.HostIp = parameter.InnerText.Trim();
                            break;

                        case "port":
                            description.Port = Int32.Parse(parameter.InnerText.Trim());
                            break;

                        case "type":
                            description.Category = parameter.InnerText.Trim() + description.Category;
                            break;
                        case "feed":
                            description.Category = description.Category + parameter.InnerText.Trim();
                            break;

                        default:
                            continue;
                    }
                }
                connections.Add(description);
            }

            foreach (var item in connections)
            {
                this.dataGridViewConnections.Rows.Add(item.Id, item.Category, item.Ip, item.HostIp, item.Port);
            }
        }

        private void dataGridViewConnections_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (this.dataGridViewConnections.Rows[e.RowIndex].IsNewRow)
            {
                this.dataGridViewConnections.Rows[e.RowIndex].ErrorText = string.Empty;
                return;
            }
            if (e.FormattedValue == null || string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                this.dataGridViewConnections.Rows[e.RowIndex].ErrorText = string.Empty;
                return;
            }

            switch (e.ColumnIndex)
            {
                case 2:
                case 3:
                    IPAddress addr;
                    if (!IPAddress.TryParse(e.FormattedValue.ToString(), out addr))
                    {
                        e.Cancel = true;
                        this.dataGridViewConnections.Rows[e.RowIndex].ErrorText = "The value must be IP address";
                    }
                    else
                    {
                        this.dataGridViewConnections.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    break;

                case 4:
                    int port;
                    if (!int.TryParse(e.FormattedValue.ToString(), out port) || port < 0)
                    {
                        e.Cancel = true;
                        this.dataGridViewConnections.Rows[e.RowIndex].ErrorText = "The value must be a non-negative integer";
                    }
                    else
                    {
                        this.dataGridViewConnections.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                    break;
            }
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.canClose = true;
        }

        private void Save()
        {
            switch (MessageBox.Show(this, "File '" + this.channelConfigurationFile + "' will be changed. Do you want to continue?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    var doc = new XmlDocument();
                    doc.Load(this.channelConfigurationFile);

                    foreach (DataGridViewRow row in this.dataGridViewConnections.Rows)
                    {
                        var connectionId = row.Cells[this.ColumnId.Index].Value.ToString();
                        var xpath = string.Format("/configuration/channel[@id='{0}']/connections/connection[@id='{1}']", this.channelId, connectionId);
                        var connectionNode = doc.SelectSingleNode(xpath);

                        UpdateNode(connectionNode, "host-ip", row.Cells[this.ColumnHostIp.Index].Value);
                        UpdateNode(connectionNode, "ip", row.Cells[this.ColumnIp.Index].Value);
                        UpdateNode(connectionNode, "port", row.Cells[this.ColumnPort.Index].Value);
                    }
                    doc.Save(this.channelConfigurationFile);
                    this.canClose = true;
                    break;

                case DialogResult.No:
                    this.canClose = true;
                    break;

                default:
                case DialogResult.Cancel:
                    this.canClose = false;
                    break;
            }
        }

        private void UpdateNode(XmlNode connectionNode, string name, object value)
        {
            string stringValue;
            if (value == null)
            {
                stringValue = null;
            }
            else
            {
                stringValue = value.ToString();
            }
            var node = connectionNode.SelectSingleNode(name);
            if (node == null)
            {
                if (string.IsNullOrEmpty(stringValue))
                {
                    return;
                }
                else
                {
                    node = connectionNode.OwnerDocument.CreateElement(name);
                    node.InnerText = stringValue;
                    connectionNode.AppendChild(node);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(stringValue))
                {
                    connectionNode.RemoveChild(node);
                }
                else
                {
                    node.InnerText = stringValue;
                }
            }
        }

        private void ConnectionSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !this.canClose;
        }
    }
}