namespace Server
{
    partial class ServerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblClients;
        private System.Windows.Forms.ListBox lstClients;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Label lblStorage;
        private System.Windows.Forms.TextBox txtStoragePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblServerTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblConnectedClients;
        private System.Windows.Forms.Label lblActivityLog;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblServerIcon;

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
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblClients = new System.Windows.Forms.Label();
            this.lstClients = new System.Windows.Forms.ListBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.lblPort = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lblStorage = new System.Windows.Forms.Label();
            this.txtStoragePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblServerTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblConnectedClients = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblActivityLog = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblServerIcon = new System.Windows.Forms.Label();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblStatus.Location = new System.Drawing.Point(20, 25);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(133, 23);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Server: Stopped";
            // 
            // lblClients
            // 
            this.lblClients.AutoSize = true;
            this.lblClients.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblClients.Location = new System.Drawing.Point(9, 30);
            this.lblClients.Name = "lblClients";
            this.lblClients.Size = new System.Drawing.Size(131, 20);
            this.lblClients.TabIndex = 1;
            this.lblClients.Text = "Connected Clients:";
            // 
            // lstClients
            // 
            this.lstClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstClients.BackColor = System.Drawing.Color.White;
            this.lstClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstClients.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lstClients.FormattingEnabled = true;
            this.lstClients.ItemHeight = 20;
            this.lstClients.Location = new System.Drawing.Point(13, 53);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(280, 180);
            this.lstClients.TabIndex = 2;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.txtLog.Location = new System.Drawing.Point(20, 50);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(380, 199);
            this.txtLog.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(20, 120);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 40);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "▶ Start Server";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnStop.Enabled = false;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(146, 120);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(134, 40);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "⏹ Stop Server";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btnClearLog.FlatAppearance.BorderSize = 0;
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLog.ForeColor = System.Drawing.Color.White;
            this.btnClearLog.Location = new System.Drawing.Point(320, 260);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(80, 30);
            this.btnClearLog.TabIndex = 6;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = false;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblPort.Location = new System.Drawing.Point(20, 170);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(38, 20);
            this.lblPort.TabIndex = 7;
            this.lblPort.Text = "Port:";
            // 
            // numPort
            // 
            this.numPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPort.Location = new System.Drawing.Point(64, 170);
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
            this.numPort.Size = new System.Drawing.Size(80, 27);
            this.numPort.TabIndex = 8;
            this.numPort.Value = new decimal(new int[] {
            8888,
            0,
            0,
            0});
            // 
            // lblStorage
            // 
            this.lblStorage.AutoSize = true;
            this.lblStorage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStorage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.lblStorage.Location = new System.Drawing.Point(20, 210);
            this.lblStorage.Name = "lblStorage";
            this.lblStorage.Size = new System.Drawing.Size(96, 20);
            this.lblStorage.TabIndex = 9;
            this.lblStorage.Text = "Storage Path:";
            // 
            // txtStoragePath
            // 
            this.txtStoragePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStoragePath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoragePath.Location = new System.Drawing.Point(122, 208);
            this.txtStoragePath.Name = "txtStoragePath";
            this.txtStoragePath.Size = new System.Drawing.Size(250, 27);
            this.txtStoragePath.TabIndex = 10;
            this.txtStoragePath.Text = "ServerStorage";
            this.txtStoragePath.TextChanged += new System.EventHandler(this.txtStoragePath_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(378, 208);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(89, 27);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblServerTitle
            // 
            this.lblServerTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServerTitle.Font = new System.Drawing.Font("Segoe UI Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerTitle.ForeColor = System.Drawing.Color.White;
            this.lblServerTitle.Location = new System.Drawing.Point(0, 0);
            this.lblServerTitle.Name = "lblServerTitle";
            this.lblServerTitle.Size = new System.Drawing.Size(800, 70);
            this.lblServerTitle.TabIndex = 12;
            this.lblServerTitle.Text = "File Transfer Server";
            this.lblServerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblServerTitle.Click += new System.EventHandler(this.lblServerTitle_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblConnectedClients);
            this.panel1.Controls.Add(this.lstClients);
            this.panel1.Controls.Add(this.lblClients);
            this.panel1.Location = new System.Drawing.Point(20, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 280);
            this.panel1.TabIndex = 13;
            // 
            // lblConnectedClients
            // 
            this.lblConnectedClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblConnectedClients.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConnectedClients.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblConnectedClients.ForeColor = System.Drawing.Color.White;
            this.lblConnectedClients.Location = new System.Drawing.Point(0, 0);
            this.lblConnectedClients.Name = "lblConnectedClients";
            this.lblConnectedClients.Size = new System.Drawing.Size(320, 30);
            this.lblConnectedClients.TabIndex = 3;
            this.lblConnectedClients.Text = "CONNECTED CLIENTS";
            this.lblConnectedClients.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblActivityLog);
            this.panel2.Controls.Add(this.txtLog);
            this.panel2.Controls.Add(this.btnClearLog);
            this.panel2.Location = new System.Drawing.Point(360, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 300);
            this.panel2.TabIndex = 14;
            // 
            // lblActivityLog
            // 
            this.lblActivityLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.lblActivityLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblActivityLog.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblActivityLog.ForeColor = System.Drawing.Color.White;
            this.lblActivityLog.Location = new System.Drawing.Point(0, 0);
            this.lblActivityLog.Name = "lblActivityLog";
            this.lblActivityLog.Size = new System.Drawing.Size(420, 30);
            this.lblActivityLog.TabIndex = 7;
            this.lblActivityLog.Text = "ACTIVITY LOG";
            this.lblActivityLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblStatus);
            this.panel3.Controls.Add(this.btnBrowse);
            this.panel3.Controls.Add(this.btnStart);
            this.panel3.Controls.Add(this.txtStoragePath);
            this.panel3.Controls.Add(this.btnStop);
            this.panel3.Controls.Add(this.lblStorage);
            this.panel3.Controls.Add(this.lblPort);
            this.panel3.Controls.Add(this.numPort);
            this.panel3.Location = new System.Drawing.Point(20, 400);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(760, 270);
            this.panel3.TabIndex = 15;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.headerPanel.Controls.Add(this.lblServerIcon);
            this.headerPanel.Controls.Add(this.lblServerTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(800, 70);
            this.headerPanel.TabIndex = 16;
            // 
            // lblServerIcon
            // 
            this.lblServerIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblServerIcon.Font = new System.Drawing.Font("Segoe MDL2 Assets", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerIcon.ForeColor = System.Drawing.Color.White;
            this.lblServerIcon.Location = new System.Drawing.Point(0, 0);
            this.lblServerIcon.Name = "lblServerIcon";
            this.lblServerIcon.Size = new System.Drawing.Size(10, 70);
            this.lblServerIcon.TabIndex = 13;
            this.lblServerIcon.Text = "";
            this.lblServerIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.footerPanel.Controls.Add(this.lblVersion);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 680);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(800, 30);
            this.footerPanel.TabIndex = 17;
            // 
            // lblVersion
            // 
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.lblVersion.Location = new System.Drawing.Point(600, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(200, 30);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "v1.0.0 • TCP File Transfer Server";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ServerForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(800, 710);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.footerPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(816, 749);
            this.Name = "ServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP File Transfer Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.footerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}