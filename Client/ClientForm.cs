using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedLibrary.Enums;
using SharedLibrary.Models;

namespace Client
{
    public partial class ClientForm : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private BinaryFormatter formatter;
        private string selectedFile;
        private string savePath;
        private bool isConnected = false;
        private bool isLoggedIn = false;
        private string currentUsername;

        public ClientForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            tabFileTransfer.Enabled = false;
            btnDisconnect.Enabled = false;
            lblLoginStatus.Text = "Not connected";
            lblLoginStatus.ForeColor = Color.Red;
            lblRegStatus.Text = "Not connected";
            lblRegStatus.ForeColor = Color.Red;
        }

        private void UpdateConnectionStatus(bool connected, string message = "")
        {
            isConnected = connected;

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateConnectionStatus(connected, message)));
                return;
            }

            if (connected)
            {
                lblConnectionStatus.Text = $"Status: Connected to {txtServerIP.Text}:{numPort.Value}";
                lblConnectionStatus.ForeColor = Color.Green;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;

                lblLoginStatus.Text = "Ready to login";
                lblLoginStatus.ForeColor = Color.Gray;
                lblRegStatus.Text = "Ready to register";
                lblRegStatus.ForeColor = Color.Gray;
            }
            else
            {
                lblConnectionStatus.Text = $"Status: {message}";
                lblConnectionStatus.ForeColor = Color.Red;
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;

                lblLoginStatus.Text = "Not connected";
                lblLoginStatus.ForeColor = Color.Red;
                lblRegStatus.Text = "Not connected";
                lblRegStatus.ForeColor = Color.Red;

                isLoggedIn = false;
                tabFileTransfer.Enabled = false;
                currentUsername = null;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                string ip = txtServerIP.Text.Trim();
                int port = (int)numPort.Value;

                if (string.IsNullOrEmpty(ip))
                {
                    MessageBox.Show("Please enter server IP address", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lblConnectionStatus.Text = "Connecting...";
                lblConnectionStatus.ForeColor = Color.Orange;

                Task.Run(() =>
                {
                    try
                    {
                        client = new TcpClient();
                        client.Connect(ip, port);
                        stream = client.GetStream();
                        formatter = new BinaryFormatter();

                        UpdateConnectionStatus(true);
                    }
                    catch (Exception ex)
                    {
                        UpdateConnectionStatus(false, $"Connection failed: {ex.Message}");
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Connection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectFromServer();
        }

        private void DisconnectFromServer()
        {
            try
            {
                if (isConnected)
                {
                    formatter.Serialize(stream, CommandType.Disconnect);
                    client.Close();
                    stream = null;
                    formatter = null;
                }
            }
            catch { }
            finally
            {
                UpdateConnectionStatus(false, "Disconnected");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private async void Login()
        {
            if (!isConnected)
            {
                lblLoginStatus.Text = "Not connected to server";
                lblLoginStatus.ForeColor = Color.Red;
                return;
            }

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblLoginStatus.Text = "Please enter username and password";
                lblLoginStatus.ForeColor = Color.Red;
                return;
            }

            lblLoginStatus.Text = "Logging in...";
            lblLoginStatus.ForeColor = Color.Orange;

            await Task.Run(() =>
            {
                try
                {
                    formatter.Serialize(stream, CommandType.Login);
                    formatter.Serialize(stream, new User
                    {
                        Username = username,
                        Password = password
                    });

                    var response = (ResponseCode)formatter.Deserialize(stream);

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            if (response == ResponseCode.LoginSuccess)
                            {
                                lblLoginStatus.Text = "Login successful!";
                                lblLoginStatus.ForeColor = Color.Green;
                                isLoggedIn = true;
                                currentUsername = username;
                                tabFileTransfer.Enabled = true;
                                tabControl.SelectedTab = tabFileTransfer;

                                // Clear password field
                                txtPassword.Clear();
                            }
                            else
                            {
                                lblLoginStatus.Text = "Login failed! Invalid credentials";
                                lblLoginStatus.ForeColor = Color.Red;
                            }
                        }));
                    }
                }
                catch (Exception ex)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            lblLoginStatus.Text = $"Login error: {ex.Message}";
                            lblLoginStatus.ForeColor = Color.Red;
                        }));
                    }
                }
            });
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register();
        }

        private async void Register()
        {
            if (!isConnected)
            {
                lblRegStatus.Text = "Not connected to server";
                lblRegStatus.ForeColor = Color.Red;
                return;
            }

            string username = txtRegUsername.Text.Trim();
            string password = txtRegPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblRegStatus.Text = "Please enter all fields";
                lblRegStatus.ForeColor = Color.Red;
                return;
            }

            if (password != confirmPassword)
            {
                lblRegStatus.Text = "Passwords don't match!";
                lblRegStatus.ForeColor = Color.Red;
                return;
            }

            if (password.Length < 6)
            {
                lblRegStatus.Text = "Password must be at least 6 characters";
                lblRegStatus.ForeColor = Color.Red;
                return;
            }

            lblRegStatus.Text = "Registering...";
            lblRegStatus.ForeColor = Color.Orange;

            await Task.Run(() =>
            {
                try
                {
                    formatter.Serialize(stream, CommandType.Register);
                    formatter.Serialize(stream, new User
                    {
                        Username = username,
                        Password = password
                    });

                    var response = (ResponseCode)formatter.Deserialize(stream);

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            if (response == ResponseCode.RegisterSuccess)
                            {
                                lblRegStatus.Text = "Registration successful!";
                                lblRegStatus.ForeColor = Color.Green;

                                // Clear fields
                                txtRegUsername.Clear();
                                txtRegPassword.Clear();
                                txtConfirmPassword.Clear();

                                // Auto-fill login fields
                                txtUsername.Text = username;
                                txtPassword.Focus();
                            }
                            else
                            {
                                lblRegStatus.Text = "Registration failed! Username may exist";
                                lblRegStatus.ForeColor = Color.Red;
                            }
                        }));
                    }
                }
                catch (Exception ex)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            lblRegStatus.Text = $"Register error: {ex.Message}";
                            lblRegStatus.ForeColor = Color.Red;
                        }));
                    }
                }
            });
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select file to upload";
                dialog.Filter = "All files (*.*)|*.*";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFile = dialog.FileName;
                    FileInfo fileInfo = new FileInfo(selectedFile);

                    lblSelectedFile.Text = $"{fileInfo.Name} ({FormatFileSize(fileInfo.Length)})";
                    btnUpload.Enabled = true;
                    progressUpload.Value = 0;
                    lblUploadStatus.Text = "Ready to upload";
                    lblUploadStatus.ForeColor = Color.Gray;
                }
            }
        }

        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            double len = bytes;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return $"{len:0.##} {sizes[order]}";
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            UploadFile();
        }

        private async void UploadFile()
        {
            if (!isConnected || !isLoggedIn)
            {
                MessageBox.Show("Please connect and login first", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(selectedFile) || !File.Exists(selectedFile))
            {
                MessageBox.Show("Please select a valid file", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnUpload.Enabled = false;
            btnBrowse.Enabled = false;
            lblUploadStatus.Text = "Preparing upload...";
            lblUploadStatus.ForeColor = Color.Orange;

            await Task.Run(() =>
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(selectedFile);
                    long fileSize = fileInfo.Length;
                    byte[] buffer = new byte[8192];
                    int totalPackets = (int)Math.Ceiling((double)fileSize / buffer.Length);

                    formatter.Serialize(stream, CommandType.SendFile);

                    using (FileStream fs = new FileStream(selectedFile, FileMode.Open, FileAccess.Read))
                    {
                        int packetNumber = 1;
                        int bytesRead;

                        while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            byte[] fileData = new byte[bytesRead];
                            Array.Copy(buffer, fileData, bytesRead);

                            var packet = new FilePacket
                            {
                                FileName = Path.GetFileName(selectedFile),
                                FileSize = fileSize,
                                FileData = fileData,
                                PacketNumber = packetNumber,
                                TotalPackets = totalPackets
                            };

                            formatter.Serialize(stream, packet);

                            // Get progress from server
                            int progress = (int)formatter.Deserialize(stream);

                            if (this.InvokeRequired)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    progressUpload.Value = progress;
                                    lblUploadStatus.Text = $"Uploading... {progress}%";
                                }));
                            }

                            packetNumber++;
                        }
                    }

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            lblUploadStatus.Text = "Upload completed successfully!";
                            lblUploadStatus.ForeColor = Color.Green;
                            btnBrowse.Enabled = true;
                            btnUpload.Enabled = false;
                            lblSelectedFile.Text = "No file selected";
                            selectedFile = null;

                            // Auto-refresh file list
                            if (tabControl.SelectedTab == tabFileTransfer)
                            {
                                RefreshFileList();
                            }
                        }));
                    }
                }
                catch (Exception ex)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            lblUploadStatus.Text = $"Upload failed: {ex.Message}";
                            lblUploadStatus.ForeColor = Color.Red;
                            btnBrowse.Enabled = true;
                            btnUpload.Enabled = true;
                        }));
                    }
                }
            });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshFileList();
        }

        private async void RefreshFileList()
        {
            if (!isConnected || !isLoggedIn)
            {
                MessageBox.Show("Please connect and login first", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lstFiles.Items.Clear();
            lstFiles.Items.Add("Loading...");

            await Task.Run(() =>
            {
                try
                {
                    formatter.Serialize(stream, CommandType.ListFiles);
                    string[] files = (string[])formatter.Deserialize(stream);

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            lstFiles.Items.Clear();

                            if (files.Length == 0)
                            {
                                lstFiles.Items.Add("No files available on server");
                            }
                            else
                            {
                                foreach (string file in files)
                                {
                                    string fileName = Path.GetFileName(file);
                                    lstFiles.Items.Add(fileName);
                                }
                            }
                        }));
                    }
                }
                catch (Exception ex)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            lstFiles.Items.Clear();
                            lstFiles.Items.Add($"Error: {ex.Message}");
                        }));
                    }
                }
            });
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem != null && !lstFiles.SelectedItem.ToString().StartsWith("Error:")
                && !lstFiles.SelectedItem.ToString().Contains("No files")
                && !lstFiles.SelectedItem.ToString().Contains("Loading"))
            {
                lblFileInfo.Text = $"Selected: {lstFiles.SelectedItem}";
                btnDownload.Enabled = true;
            }
            else
            {
                btnDownload.Enabled = false;
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Select location to save file";
                dialog.Filter = "All files (*.*)|*.*";
                dialog.OverwritePrompt = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    savePath = dialog.FileName;
                    lblDownloadPath.Text = $"Save to: {Path.GetFileName(savePath)}";
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadFile();
        }

        private async void DownloadFile()
        {
            if (!isConnected || !isLoggedIn)
            {
                MessageBox.Show("Please connect and login first", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lstFiles.SelectedItem == null || lstFiles.SelectedItem.ToString().StartsWith("Error:")
                || lstFiles.SelectedItem.ToString().Contains("No files")
                || lstFiles.SelectedItem.ToString().Contains("Loading"))
            {
                MessageBox.Show("Please select a valid file", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(savePath))
            {
                MessageBox.Show("Please select a save location first", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fileName = lstFiles.SelectedItem.ToString();

            btnDownload.Enabled = false;
            btnRefresh.Enabled = false;
            progressDownload.Value = 0;

            await Task.Run(() =>
            {
                try
                {
                    formatter.Serialize(stream, CommandType.RequestFile);
                    formatter.Serialize(stream, fileName);

                    bool fileExists = (bool)formatter.Deserialize(stream);
                    if (!fileExists)
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                MessageBox.Show("File not found on server", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                btnDownload.Enabled = true;
                                btnRefresh.Enabled = true;
                            }));
                        }
                        return;
                    }

                    using (FileStream fs = new FileStream(savePath, FileMode.Create))
                    {
                        while (true)
                        {
                            var packet = (FilePacket)formatter.Deserialize(stream);
                            fs.Write(packet.FileData, 0, packet.FileData.Length);

                            int progress = (int)((packet.PacketNumber * 100.0) / packet.TotalPackets);

                            if (this.InvokeRequired)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    progressDownload.Value = progress;
                                }));
                            }

                            if (packet.PacketNumber == packet.TotalPackets)
                                break;
                        }
                    }

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            progressDownload.Value = 100;
                            MessageBox.Show($"File downloaded successfully!\n\nSaved to: {savePath}",
                                "Download Complete",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            btnDownload.Enabled = true;
                            btnRefresh.Enabled = true;
                            savePath = null;
                            lblDownloadPath.Text = "Save to: (not selected)";
                        }));
                    }
                }
                catch (Exception ex)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            MessageBox.Show($"Download failed: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnDownload.Enabled = true;
                            btnRefresh.Enabled = true;
                        }));
                    }
                }
            });
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (isConnected)
                {
                    formatter.Serialize(stream, CommandType.Disconnect);
                    client.Close();
                }
            }
            catch { }
        }
    }
}