using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedLibrary.Enums;
using SharedLibrary.Models;
using SharedLibrary.Protocol;

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

            lblVersion.Text = $"v1.0.0 • {DateTime.Now.Year} • TCP File Transfer Client";
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

        private async void ConnectToServer()
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

                await Task.Run(() =>
                {
                    try
                    {
                        client = new TcpClient();

                        client.ReceiveTimeout = 30000; 
                        client.SendTimeout = 30000; 

                        // Kết nối với timeout
                        IAsyncResult result = client.BeginConnect(ip, port, null, null);
                        bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(10));

                        if (!success)
                        {
                            throw new TimeoutException("Connection timeout");
                        }

                        client.EndConnect(result);

                        stream = client.GetStream();
                        formatter = new BinaryFormatter();

                        UpdateConnectionStatus(true);
                    }
                    catch (TimeoutException)
                    {
                        UpdateConnectionStatus(false, "Connection timeout (10 seconds)");
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
                if (isConnected && stream != null)
                {
                    FileTransferProtocol.SendString(stream, CommandType.Disconnect.ToString());
                }
            }
            catch { }
            finally
            {
                try
                {
                    client?.Close();
                }
                catch { }
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
                    FileTransferProtocol.SendString(stream, CommandType.Login.ToString());

                    FileTransferProtocol.SendString(stream, username);
                    FileTransferProtocol.SendString(stream, password);

                    string response = FileTransferProtocol.ReceiveString(stream);

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            if (response == ResponseCode.LoginSuccess.ToString())
                            {
                                lblLoginStatus.Text = "Login successful!";
                                lblLoginStatus.ForeColor = Color.Green;
                                isLoggedIn = true;
                                currentUsername = username;
                                tabFileTransfer.Enabled = true;
                                tabControl.SelectedTab = tabFileTransfer;

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
                    FileTransferProtocol.SendString(stream, CommandType.Register.ToString());

                    FileTransferProtocol.SendString(stream, username);
                    FileTransferProtocol.SendString(stream, password);

                    string response = FileTransferProtocol.ReceiveString(stream);

                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            if (response == ResponseCode.RegisterSuccess.ToString())
                            {
                                lblRegStatus.Text = "Registration successful!";
                                lblRegStatus.ForeColor = Color.Green;

                                txtRegUsername.Clear();
                                txtRegPassword.Clear();
                                txtConfirmPassword.Clear();

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

            FileInfo fileInfo = new FileInfo(selectedFile);
            if (fileInfo.Length >  1024 * 1024 * 1024)
            {
                MessageBox.Show("File size is too large (max 1GB)", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnUpload.Enabled = false;
            btnBrowse.Enabled = false;
            lblUploadStatus.Text = "Preparing upload...";
            lblUploadStatus.ForeColor = Color.Orange;
            progressUpload.Value = 0;

            try
            {
                NetworkStream uploadStream = client.GetStream();

                await Task.Run(() =>
                {
                    try
                    {
                        FileTransferProtocol.SendString(uploadStream, CommandType.SendFile.ToString());

                        string fileName = Path.GetFileName(selectedFile);
                        FileTransferProtocol.SendString(uploadStream, fileName);

                        FileTransferProtocol.SendFile(uploadStream, selectedFile, progress =>
                        {
                            
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    progressUpload.Value = progress;
                                    lblUploadStatus.Text = $"Uploading... {progress}%";

                                    if (progress < 30)
                                        lblUploadStatus.ForeColor = Color.Orange;
                                    else if (progress < 70)
                                        lblUploadStatus.ForeColor = Color.Blue;
                                    else
                                        lblUploadStatus.ForeColor = Color.Green;
                                }));
                            }
                        });

                        string response = FileTransferProtocol.ReceiveString(uploadStream);

                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                if (response == ResponseCode.FileReceived.ToString())
                                {
                                    progressUpload.Value = 100;
                                    lblUploadStatus.Text = "✅ Upload completed successfully!";
                                    lblUploadStatus.ForeColor = Color.Green;
                                }
                                else if (response.StartsWith("ERROR:"))
                                {
                                    string errorMsg = response.Substring(6);
                                    lblUploadStatus.Text = $"❌ {errorMsg}";
                                    lblUploadStatus.ForeColor = Color.Red;
                                    btnUpload.Enabled = true;
                                }
                                else
                                {
                                    lblUploadStatus.Text = $"⚠️ Unknown response: {response}";
                                    lblUploadStatus.ForeColor = Color.Orange;
                                    btnUpload.Enabled = true;
                                }

                                btnBrowse.Enabled = true;
                                lblSelectedFile.Text = "No file selected";
                                selectedFile = null;

                                RefreshFileList();
                            }));
                        }
                    }
                    catch (IOException ioEx)
                    {
                        throw new Exception($"File I/O error: {ioEx.Message}");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Upload failed: {ex.Message}");
                    }
                });
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        lblUploadStatus.Text = $"❌ {ex.Message}";
                        lblUploadStatus.ForeColor = Color.Red;
                        btnBrowse.Enabled = true;
                        btnUpload.Enabled = true;

                        if (!client.Connected)
                        {
                            UpdateConnectionStatus(false, "Connection lost");
                        }
                    }));
                }
            }
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

            try
            {
                NetworkStream listStream = client.GetStream();

                await Task.Run(() =>
                {
                    try
                    {
                        FileTransferProtocol.SendString(listStream, CommandType.ListFiles.ToString());

                        string fileListData = FileTransferProtocol.ReceiveString(listStream);

                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                lstFiles.Items.Clear();

                                if (fileListData == "ERROR")
                                {
                                    lstFiles.Items.Add("Error getting file list");
                                    return;
                                }

                                string[] lines = fileListData.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                                if (lines.Length == 0)
                                {
                                    lstFiles.Items.Add("No files available on server");
                                }
                                else
                                {
                                    foreach (string line in lines)
                                    {
                                        string[] parts = line.Split('|');
                                        if (parts.Length >= 1)
                                        {
                                            string displayText = parts[0];
                                            if (parts.Length >= 2)
                                            {
                                                long fileSize = long.Parse(parts[1]);
                                                displayText += $" ({FormatFileSize(fileSize)})";
                                            }
                                            lstFiles.Items.Add(displayText);
                                        }
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
            catch (Exception ex)
            {
                lstFiles.Items.Clear();
                lstFiles.Items.Add($"Error: {ex.Message}");
            }
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

            if (lstFiles.SelectedItem == null ||
                lstFiles.SelectedItem.ToString().StartsWith("Error:") ||
                lstFiles.SelectedItem.ToString().Contains("No files") ||
                lstFiles.SelectedItem.ToString().Contains("Loading"))
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

            string selectedItem = lstFiles.SelectedItem.ToString();
            string fileName = selectedItem.Split('(')[0].Trim();

            btnDownload.Enabled = false;
            btnRefresh.Enabled = false;
            progressDownload.Value = 0;
            lblFileInfo.Text = $"Downloading: {fileName}";

            try
            {
                NetworkStream downloadStream = client.GetStream();

                await Task.Run(() =>
                {
                    try
                    {
                        FileTransferProtocol.SendString(downloadStream, CommandType.RequestFile.ToString());

                        FileTransferProtocol.SendString(downloadStream, fileName);

                        string response = FileTransferProtocol.ReceiveString(downloadStream);

                        if (response != "FILE_EXISTS")
                        {
                            throw new Exception("File not found on server");
                        }

                        FileTransferProtocol.ReceiveFile(downloadStream, savePath, progress =>
                        {
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    progressDownload.Value = progress;
                                }));
                            }
                        });

                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                progressDownload.Value = 100;
                                MessageBox.Show($"✅ File downloaded successfully!\n\nSaved to: {savePath}",
                                    "Download Complete",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                btnDownload.Enabled = true;
                                btnRefresh.Enabled = true;
                                savePath = null;
                                lblDownloadPath.Text = "Save to: (not selected)";
                                lblFileInfo.Text = "No file selected";
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Download failed: {ex.Message}");
                    }
                });
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show($"❌ {ex.Message}", "Download Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnDownload.Enabled = true;
                        btnRefresh.Enabled = true;
                    }));
                }
            }
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (isConnected && stream != null)
                {
                    FileTransferProtocol.SendString(stream, CommandType.Disconnect.ToString());
                    client.Close();
                }
            }
            catch { }
        }

        private void grpDownload_Enter(object sender, EventArgs e)
        {

        }

        private void panelDownload_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabFileTransfer_Click(object sender, EventArgs e)
        {

        }

        private void numPort_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblConfirmPassword_Click(object sender, EventArgs e)
        {

        }
    }
}