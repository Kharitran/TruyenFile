using Server.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerForm : Form
    {
        private TcpListener server;
        private List<ClientSession> connectedClients;
        private Thread listenerThread;
        private bool isRunning = false;
        private Authentication auth;

        public ServerForm()
        {
            InitializeComponent();
            connectedClients = new List<ClientSession>();
            auth = new Authentication();
            UpdateStatusLabel(false);

            lblVersion.Text = $"v1.0.0 • {DateTime.Now.Year} • TCP File Transfer Server";
        }

        private void UpdateStatusLabel(bool isRunning)
        {
            if (isRunning)
            {
                lblStatus.Text = "Server: Running";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.Text = "Server: Stopped";
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string rawPath = txtStoragePath.Text;
            if (string.IsNullOrWhiteSpace(rawPath)) rawPath = "ServerStorage";

            string absolutePath = Path.GetFullPath(rawPath);

            txtStoragePath.Text = absolutePath;

            StartServer((int)numPort.Value, absolutePath);
        }

        private void StartServer(int port, string storagePath)
        {
            try
            {
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                isRunning = true;

                listenerThread = new Thread(() => ListenForClients(storagePath));
                listenerThread.IsBackground = true;
                listenerThread.Start();

                UpdateUI(() =>
                {
                    UpdateStatusLabel(true);
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] ✅ Server started on port {port}\r\n");
                    txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] 📁 Storage path: {Path.GetFullPath(storagePath)}\r\n");
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting server:\n{ex.Message}", "Server Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListenForClients(string storagePath)
        {
            while (isRunning)
            {
                try
                {
                    var client = server.AcceptTcpClient();
                    var session = new ClientSession(client, storagePath, auth, this);
                    connectedClients.Add(session);

                    var endpoint = client.Client.RemoteEndPoint.ToString();
                    UpdateUI(() =>
                    {
                        lstClients.Items.Add($"{endpoint} - Not logged in");
                        txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] 🔗 Client connected: {endpoint}\r\n");
                    });

                    var clientThread = new Thread(session.HandleClient);
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
                catch (Exception ex)
                {
                    if (isRunning)
                        LogMessage($"❌ Error accepting client: {ex.Message}");
                }
            }
        }

        public void LogMessage(string message)
        {
            UpdateUI(() =>
            {
                txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\r\n");
                txtLog.SelectionStart = txtLog.Text.Length;
                txtLog.ScrollToCaret();
            });
        }

        public void UpdateClientList(ClientSession session, string username)
        {
            UpdateUI(() =>
            {
                for (int i = 0; i < lstClients.Items.Count; i++)
                {
                    if (lstClients.Items[i].ToString().Contains(session.IPAddress))
                    {
                        lstClients.Items[i] = $"{session.IPAddress} - {username}";
                        break;
                    }
                }
            });
        }

        public void RemoveClient(ClientSession session)
        {
            UpdateUI(() =>
            {
                for (int i = 0; i < lstClients.Items.Count; i++)
                {
                    if (lstClients.Items[i].ToString().Contains(session.IPAddress))
                    {
                        lstClients.Items.RemoveAt(i);
                        break;
                    }
                }
            });
            connectedClients.Remove(session);
            LogMessage($"🔌 Client disconnected: {session.Username ?? session.IPAddress}");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void StopServer()
        {
            isRunning = false;

            foreach (var client in connectedClients.ToList())
            {
                try
                {
                    client.Disconnect();
                }
                catch { }
            }

            connectedClients.Clear();

            try
            {
                server?.Stop();
            }
            catch { }

            UpdateUI(() =>
            {
                UpdateStatusLabel(false);
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                lstClients.Items.Clear();
                txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] ⏹ Server stopped\r\n");
            });
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select storage directory for uploaded files";
                dialog.ShowNewFolderButton = true;

                if (!string.IsNullOrEmpty(txtStoragePath.Text) && Directory.Exists(txtStoragePath.Text))
                {
                    dialog.SelectedPath = Path.GetFullPath(txtStoragePath.Text);
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtStoragePath.Text = dialog.SelectedPath;
                }
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRunning)
            {
                var result = MessageBox.Show("Server is still running. Do you want to stop it and exit?",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    StopServer();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void UpdateUI(Action action)
        {
            if (this.InvokeRequired)
                this.Invoke(action);
            else
                action();
        }

        internal void UpdateClientList()
        {
            throw new NotImplementedException();
        }

        private void txtStoragePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblServerTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
