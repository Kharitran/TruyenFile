namespace Client
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.TabPage tabFileTransfer;
        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblLoginStatus;
        private System.Windows.Forms.GroupBox grpRegister;
        private System.Windows.Forms.Label lblRegUsername;
        private System.Windows.Forms.TextBox txtRegUsername;
        private System.Windows.Forms.Label lblRegPassword;
        private System.Windows.Forms.TextBox txtRegPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblRegStatus;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.GroupBox grpUpload;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblSelectedFile;
        private System.Windows.Forms.ProgressBar progressUpload;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label lblUploadStatus;
        private System.Windows.Forms.GroupBox grpDownload;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ProgressBar progressDownload;
        private System.Windows.Forms.Label lblClientTitle;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblFileInfo;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Label lblDownloadPath;
        private System.Windows.Forms.Panel panelUpload;
        private System.Windows.Forms.Panel panelDownload;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label lblClientIcon;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelMain;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.panelMain = new System.Windows.Forms.Panel();
            this.grpRegister = new System.Windows.Forms.GroupBox();
            this.lblRegStatus = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtRegPassword = new System.Windows.Forms.TextBox();
            this.lblRegPassword = new System.Windows.Forms.Label();
            this.txtRegUsername = new System.Windows.Forms.TextBox();
            this.lblRegUsername = new System.Windows.Forms.Label();
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.lblLoginStatus = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.tabFileTransfer = new System.Windows.Forms.TabPage();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.grpDownload = new System.Windows.Forms.GroupBox();
            this.panelDownload = new System.Windows.Forms.Panel();
            this.lblDownloadPath = new System.Windows.Forms.Label();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.lblFileInfo = new System.Windows.Forms.Label();
            this.progressDownload = new System.Windows.Forms.ProgressBar();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.grpUpload = new System.Windows.Forms.GroupBox();
            this.panelUpload = new System.Windows.Forms.Panel();
            this.lblUploadStatus = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.progressUpload = new System.Windows.Forms.ProgressBar();
            this.lblSelectedFile = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblClientIcon = new System.Windows.Forms.Label();
            this.lblClientTitle = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabLogin.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.grpRegister.SuspendLayout();
            this.grpLogin.SuspendLayout();
            this.grpConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.tabFileTransfer.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.grpDownload.SuspendLayout();
            this.panelDownload.SuspendLayout();
            this.grpUpload.SuspendLayout();
            this.panelUpload.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabLogin);
            this.tabControl.Controls.Add(this.tabFileTransfer);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 80);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(898, 612);
            this.tabControl.TabIndex = 0;
            // 
            // tabLogin
            // 
            this.tabLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabLogin.Controls.Add(this.panelMain);
            this.tabLogin.Location = new System.Drawing.Point(4, 29);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Padding = new System.Windows.Forms.Padding(20);
            this.tabLogin.Size = new System.Drawing.Size(890, 579);
            this.tabLogin.TabIndex = 0;
            this.tabLogin.Text = "Login/Register";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Controls.Add(this.grpRegister);
            this.panelMain.Controls.Add(this.grpLogin);
            this.panelMain.Controls.Add(this.grpConnection);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(20, 20);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(850, 539);
            this.panelMain.TabIndex = 3;
            // 
            // grpRegister
            // 
            this.grpRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRegister.BackColor = System.Drawing.Color.White;
            this.grpRegister.Controls.Add(this.lblRegStatus);
            this.grpRegister.Controls.Add(this.btnRegister);
            this.grpRegister.Controls.Add(this.txtConfirmPassword);
            this.grpRegister.Controls.Add(this.lblConfirmPassword);
            this.grpRegister.Controls.Add(this.txtRegPassword);
            this.grpRegister.Controls.Add(this.lblRegPassword);
            this.grpRegister.Controls.Add(this.txtRegUsername);
            this.grpRegister.Controls.Add(this.lblRegUsername);
            this.grpRegister.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.grpRegister.Location = new System.Drawing.Point(0, 330);
            this.grpRegister.Name = "grpRegister";
            this.grpRegister.Size = new System.Drawing.Size(850, 200);
            this.grpRegister.TabIndex = 2;
            this.grpRegister.TabStop = false;
            this.grpRegister.Text = "REGISTER NEW ACCOUNT";
            // 
            // lblRegStatus
            // 
            this.lblRegStatus.AutoSize = true;
            this.lblRegStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblRegStatus.Location = new System.Drawing.Point(150, 140);
            this.lblRegStatus.Name = "lblRegStatus";
            this.lblRegStatus.Size = new System.Drawing.Size(50, 20);
            this.lblRegStatus.TabIndex = 7;
            this.lblRegStatus.Text = "Ready";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(20, 135);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(120, 40);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(154, 104);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.Size = new System.Drawing.Size(250, 27);
            this.txtConfirmPassword.TabIndex = 5;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblConfirmPassword.Location = new System.Drawing.Point(20, 103);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(130, 20);
            this.lblConfirmPassword.TabIndex = 4;
            this.lblConfirmPassword.Text = "Confirm Password:";
            this.lblConfirmPassword.Click += new System.EventHandler(this.lblConfirmPassword_Click);
            // 
            // txtRegPassword
            // 
            this.txtRegPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegPassword.Location = new System.Drawing.Point(104, 71);
            this.txtRegPassword.Name = "txtRegPassword";
            this.txtRegPassword.PasswordChar = '●';
            this.txtRegPassword.Size = new System.Drawing.Size(250, 27);
            this.txtRegPassword.TabIndex = 3;
            // 
            // lblRegPassword
            // 
            this.lblRegPassword.AutoSize = true;
            this.lblRegPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblRegPassword.Location = new System.Drawing.Point(20, 73);
            this.lblRegPassword.Name = "lblRegPassword";
            this.lblRegPassword.Size = new System.Drawing.Size(73, 20);
            this.lblRegPassword.TabIndex = 2;
            this.lblRegPassword.Text = "Password:";
            // 
            // txtRegUsername
            // 
            this.txtRegUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegUsername.Location = new System.Drawing.Point(104, 29);
            this.txtRegUsername.Name = "txtRegUsername";
            this.txtRegUsername.Size = new System.Drawing.Size(250, 27);
            this.txtRegUsername.TabIndex = 1;
            // 
            // lblRegUsername
            // 
            this.lblRegUsername.AutoSize = true;
            this.lblRegUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblRegUsername.Location = new System.Drawing.Point(20, 33);
            this.lblRegUsername.Name = "lblRegUsername";
            this.lblRegUsername.Size = new System.Drawing.Size(78, 20);
            this.lblRegUsername.TabIndex = 0;
            this.lblRegUsername.Text = "Username:";
            // 
            // grpLogin
            // 
            this.grpLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLogin.BackColor = System.Drawing.Color.White;
            this.grpLogin.Controls.Add(this.lblLoginStatus);
            this.grpLogin.Controls.Add(this.btnLogin);
            this.grpLogin.Controls.Add(this.txtPassword);
            this.grpLogin.Controls.Add(this.lblPassword);
            this.grpLogin.Controls.Add(this.txtUsername);
            this.grpLogin.Controls.Add(this.lblUsername);
            this.grpLogin.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.grpLogin.Location = new System.Drawing.Point(0, 160);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(850, 150);
            this.grpLogin.TabIndex = 1;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "LOGIN";
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.AutoSize = true;
            this.lblLoginStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblLoginStatus.Location = new System.Drawing.Point(150, 110);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(50, 20);
            this.lblLoginStatus.TabIndex = 5;
            this.lblLoginStatus.Text = "Ready";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(20, 105);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(120, 40);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(104, 71);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(250, 27);
            this.txtPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblPassword.Location = new System.Drawing.Point(20, 73);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 20);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(104, 31);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(250, 27);
            this.txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblUsername.Location = new System.Drawing.Point(20, 33);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(78, 20);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            // 
            // grpConnection
            // 
            this.grpConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConnection.BackColor = System.Drawing.Color.White;
            this.grpConnection.Controls.Add(this.btnDisconnect);
            this.grpConnection.Controls.Add(this.lblConnectionStatus);
            this.grpConnection.Controls.Add(this.btnConnect);
            this.grpConnection.Controls.Add(this.numPort);
            this.grpConnection.Controls.Add(this.lblPort);
            this.grpConnection.Controls.Add(this.txtServerIP);
            this.grpConnection.Controls.Add(this.lblServerIP);
            this.grpConnection.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConnection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.grpConnection.Location = new System.Drawing.Point(0, 0);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(850, 140);
            this.grpConnection.TabIndex = 0;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "SERVER CONNECTION";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.FlatAppearance.BorderSize = 0;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.ForeColor = System.Drawing.Color.White;
            this.btnDisconnect.Location = new System.Drawing.Point(660, 80);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(120, 40);
            this.btnDisconnect.TabIndex = 6;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblConnectionStatus.Location = new System.Drawing.Point(20, 90);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(154, 20);
            this.lblConnectionStatus.TabIndex = 5;
            this.lblConnectionStatus.Text = "Status: Not connected";
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(520, 80);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(120, 40);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // numPort
            // 
            this.numPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPort.Location = new System.Drawing.Point(684, 36);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(100, 27);
            this.numPort.TabIndex = 3;
            this.numPort.Value = new decimal(new int[] {
            8888,
            0,
            0,
            0});
            this.numPort.ValueChanged += new System.EventHandler(this.numPort_ValueChanged);
            // 
            // lblPort
            // 
            this.lblPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblPort.Location = new System.Drawing.Point(640, 38);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(38, 20);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port:";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServerIP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerIP.Location = new System.Drawing.Point(100, 36);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(540, 27);
            this.txtServerIP.TabIndex = 1;
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblServerIP.Location = new System.Drawing.Point(20, 38);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(69, 20);
            this.lblServerIP.TabIndex = 0;
            this.lblServerIP.Text = "Server IP:";
            // 
            // tabFileTransfer
            // 
            this.tabFileTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tabFileTransfer.Controls.Add(this.panelContainer);
            this.tabFileTransfer.Location = new System.Drawing.Point(4, 25);
            this.tabFileTransfer.Name = "tabFileTransfer";
            this.tabFileTransfer.Padding = new System.Windows.Forms.Padding(3);
            this.tabFileTransfer.Size = new System.Drawing.Size(890, 583);
            this.tabFileTransfer.TabIndex = 1;
            this.tabFileTransfer.Text = "File Transfer";
            this.tabFileTransfer.Click += new System.EventHandler(this.tabFileTransfer_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelContainer.Controls.Add(this.grpDownload);
            this.panelContainer.Controls.Add(this.grpUpload);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(3, 3);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(884, 577);
            this.panelContainer.TabIndex = 3;
            // 
            // grpDownload
            // 
            this.grpDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDownload.BackColor = System.Drawing.Color.Transparent;
            this.grpDownload.Controls.Add(this.panelDownload);
            this.grpDownload.Controls.Add(this.lstFiles);
            this.grpDownload.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDownload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.grpDownload.Location = new System.Drawing.Point(0, 250);
            this.grpDownload.Name = "grpDownload";
            this.grpDownload.Size = new System.Drawing.Size(890, 362);
            this.grpDownload.TabIndex = 2;
            this.grpDownload.TabStop = false;
            this.grpDownload.Text = "DOWNLOAD FILES FROM SERVER";
            this.grpDownload.Enter += new System.EventHandler(this.grpDownload_Enter);
            // 
            // panelDownload
            // 
            this.panelDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDownload.BackColor = System.Drawing.Color.White;
            this.panelDownload.Controls.Add(this.lblDownloadPath);
            this.panelDownload.Controls.Add(this.btnSaveAs);
            this.panelDownload.Controls.Add(this.lblFileInfo);
            this.panelDownload.Controls.Add(this.progressDownload);
            this.panelDownload.Controls.Add(this.btnDownload);
            this.panelDownload.Controls.Add(this.btnRefresh);
            this.panelDownload.Location = new System.Drawing.Point(20, 127);
            this.panelDownload.Name = "panelDownload";
            this.panelDownload.Size = new System.Drawing.Size(850, 214);
            this.panelDownload.TabIndex = 3;
            this.panelDownload.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDownload_Paint);
            // 
            // lblDownloadPath
            // 
            this.lblDownloadPath.AutoSize = true;
            this.lblDownloadPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblDownloadPath.Location = new System.Drawing.Point(178, 111);
            this.lblDownloadPath.Name = "lblDownloadPath";
            this.lblDownloadPath.Size = new System.Drawing.Size(156, 20);
            this.lblDownloadPath.TabIndex = 6;
            this.lblDownloadPath.Text = "Save to: (not selected)";
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnSaveAs.FlatAppearance.BorderSize = 0;
            this.btnSaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAs.ForeColor = System.Drawing.Color.White;
            this.btnSaveAs.Location = new System.Drawing.Point(20, 104);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(140, 40);
            this.btnSaveAs.TabIndex = 5;
            this.btnSaveAs.Text = "Choose Location";
            this.btnSaveAs.UseVisualStyleBackColor = false;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // lblFileInfo
            // 
            this.lblFileInfo.AutoSize = true;
            this.lblFileInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblFileInfo.Location = new System.Drawing.Point(179, 78);
            this.lblFileInfo.Name = "lblFileInfo";
            this.lblFileInfo.Size = new System.Drawing.Size(106, 20);
            this.lblFileInfo.TabIndex = 4;
            this.lblFileInfo.Text = "No file selected";
            // 
            // progressDownload
            // 
            this.progressDownload.Location = new System.Drawing.Point(20, 154);
            this.progressDownload.Name = "progressDownload";
            this.progressDownload.Size = new System.Drawing.Size(810, 25);
            this.progressDownload.TabIndex = 3;
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnDownload.FlatAppearance.BorderSize = 0;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Location = new System.Drawing.Point(20, 64);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(140, 40);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(679, 102);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 40);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh List";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.BackColor = System.Drawing.Color.White;
            this.lstFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFiles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 23;
            this.lstFiles.Location = new System.Drawing.Point(20, 33);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(808, 92);
            this.lstFiles.TabIndex = 0;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            // 
            // grpUpload
            // 
            this.grpUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUpload.BackColor = System.Drawing.Color.Transparent;
            this.grpUpload.Controls.Add(this.panelUpload);
            this.grpUpload.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUpload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.grpUpload.Location = new System.Drawing.Point(0, 0);
            this.grpUpload.Name = "grpUpload";
            this.grpUpload.Size = new System.Drawing.Size(890, 250);
            this.grpUpload.TabIndex = 0;
            this.grpUpload.TabStop = false;
            this.grpUpload.Text = "UPLOAD FILE TO SERVER";
            // 
            // panelUpload
            // 
            this.panelUpload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUpload.BackColor = System.Drawing.Color.White;
            this.panelUpload.Controls.Add(this.lblUploadStatus);
            this.panelUpload.Controls.Add(this.btnUpload);
            this.panelUpload.Controls.Add(this.progressUpload);
            this.panelUpload.Controls.Add(this.lblSelectedFile);
            this.panelUpload.Controls.Add(this.btnBrowse);
            this.panelUpload.Location = new System.Drawing.Point(20, 40);
            this.panelUpload.Name = "panelUpload";
            this.panelUpload.Size = new System.Drawing.Size(850, 200);
            this.panelUpload.TabIndex = 1;
            // 
            // lblUploadStatus
            // 
            this.lblUploadStatus.AutoSize = true;
            this.lblUploadStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUploadStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblUploadStatus.Location = new System.Drawing.Point(170, 155);
            this.lblUploadStatus.Name = "lblUploadStatus";
            this.lblUploadStatus.Size = new System.Drawing.Size(48, 20);
            this.lblUploadStatus.TabIndex = 4;
            this.lblUploadStatus.Text = "Ready";
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnUpload.Enabled = false;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Location = new System.Drawing.Point(20, 150);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(140, 40);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "Upload File";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // progressUpload
            // 
            this.progressUpload.Location = new System.Drawing.Point(20, 110);
            this.progressUpload.Name = "progressUpload";
            this.progressUpload.Size = new System.Drawing.Size(810, 25);
            this.progressUpload.TabIndex = 2;
            // 
            // lblSelectedFile
            // 
            this.lblSelectedFile.AutoSize = true;
            this.lblSelectedFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFile.Location = new System.Drawing.Point(170, 60);
            this.lblSelectedFile.Name = "lblSelectedFile";
            this.lblSelectedFile.Size = new System.Drawing.Size(113, 20);
            this.lblSelectedFile.TabIndex = 1;
            this.lblSelectedFile.Text = "No file selected";
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(20, 50);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(140, 40);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse File...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.panelHeader.Controls.Add(this.lblClientIcon);
            this.panelHeader.Controls.Add(this.lblClientTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(898, 80);
            this.panelHeader.TabIndex = 1;
            // 
            // lblClientIcon
            // 
            this.lblClientIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblClientIcon.Font = new System.Drawing.Font("Segoe MDL2 Assets", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientIcon.ForeColor = System.Drawing.Color.White;
            this.lblClientIcon.Location = new System.Drawing.Point(0, 0);
            this.lblClientIcon.Name = "lblClientIcon";
            this.lblClientIcon.Size = new System.Drawing.Size(10, 80);
            this.lblClientIcon.TabIndex = 1;
            this.lblClientIcon.Text = "";
            this.lblClientIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClientTitle
            // 
            this.lblClientTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClientTitle.Font = new System.Drawing.Font("Segoe UI Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientTitle.ForeColor = System.Drawing.Color.White;
            this.lblClientTitle.Location = new System.Drawing.Point(0, 0);
            this.lblClientTitle.Name = "lblClientTitle";
            this.lblClientTitle.Size = new System.Drawing.Size(898, 80);
            this.lblClientTitle.TabIndex = 0;
            this.lblClientTitle.Text = "File Transfer Client";
            this.lblClientTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelFooter.Controls.Add(this.lblVersion);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 692);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(898, 30);
            this.panelFooter.TabIndex = 2;
            // 
            // lblVersion
            // 
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.lblVersion.Location = new System.Drawing.Point(698, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(200, 30);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "v1.0.0 • TCP File Transfer Client";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ClientForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(898, 722);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(916, 769);
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP File Transfer Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.grpRegister.ResumeLayout(false);
            this.grpRegister.PerformLayout();
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.tabFileTransfer.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.grpDownload.ResumeLayout(false);
            this.panelDownload.ResumeLayout(false);
            this.panelDownload.PerformLayout();
            this.grpUpload.ResumeLayout(false);
            this.panelUpload.ResumeLayout(false);
            this.panelUpload.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}