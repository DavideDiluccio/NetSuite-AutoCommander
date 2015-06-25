namespace NetSuite_AutoCommander
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelLogin = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.btnLoadCommands = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.rtbLogCommand = new System.Windows.Forms.RichTextBox();
            this.statusBarConnection = new System.Windows.Forms.StatusStrip();
            this.lblStatusConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panelLogin.SuspendLayout();
            this.statusBarConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogin.Controls.Add(this.lblError);
            this.panelLogin.Controls.Add(this.btnConnect);
            this.panelLogin.Controls.Add(this.lblEmail);
            this.panelLogin.Controls.Add(this.lblPassword);
            this.panelLogin.Controls.Add(this.txtPassword);
            this.panelLogin.Controls.Add(this.txtEmail);
            this.panelLogin.Controls.Add(this.lblAccount);
            this.panelLogin.Controls.Add(this.cmbAccount);
            this.panelLogin.Location = new System.Drawing.Point(5, 12);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(693, 102);
            this.panelLogin.TabIndex = 0;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(603, 36);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(54, 26);
            this.lblError.TabIndex = 1;
            this.lblError.Text = "Qui Errore\r\nLog In";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(477, 31);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(79, 29);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(256, 19);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(256, 62);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password :";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(330, 59);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(129, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(330, 16);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(129, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(21, 39);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(53, 13);
            this.lblAccount.TabIndex = 1;
            this.lblAccount.Text = "Account :";
            // 
            // cmbAccount
            // 
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(99, 36);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(121, 21);
            this.cmbAccount.TabIndex = 0;
            // 
            // btnLoadCommands
            // 
            this.btnLoadCommands.Location = new System.Drawing.Point(24, 127);
            this.btnLoadCommands.Name = "btnLoadCommands";
            this.btnLoadCommands.Size = new System.Drawing.Size(114, 42);
            this.btnLoadCommands.TabIndex = 1;
            this.btnLoadCommands.Text = "Load Commands";
            this.btnLoadCommands.UseVisualStyleBackColor = true;
            this.btnLoadCommands.Click += new System.EventHandler(this.btnLoadCommands_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(24, 241);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(76, 28);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // rtbLogCommand
            // 
            this.rtbLogCommand.Location = new System.Drawing.Point(24, 284);
            this.rtbLogCommand.Name = "rtbLogCommand";
            this.rtbLogCommand.ReadOnly = true;
            this.rtbLogCommand.Size = new System.Drawing.Size(674, 171);
            this.rtbLogCommand.TabIndex = 3;
            this.rtbLogCommand.Text = "";
            // 
            // statusBarConnection
            // 
            this.statusBarConnection.BackColor = System.Drawing.SystemColors.Highlight;
            this.statusBarConnection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusConnection});
            this.statusBarConnection.Location = new System.Drawing.Point(0, 485);
            this.statusBarConnection.Name = "statusBarConnection";
            this.statusBarConnection.Size = new System.Drawing.Size(708, 22);
            this.statusBarConnection.TabIndex = 4;
            this.statusBarConnection.Text = "statusStrip1";
            // 
            // lblStatusConnection
            // 
            this.lblStatusConnection.ForeColor = System.Drawing.Color.White;
            this.lblStatusConnection.Name = "lblStatusConnection";
            this.lblStatusConnection.Size = new System.Drawing.Size(127, 17);
            this.lblStatusConnection.Text = "Qui Stato Connessione";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 507);
            this.Controls.Add(this.statusBarConnection);
            this.Controls.Add(this.rtbLogCommand);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnLoadCommands);
            this.Controls.Add(this.panelLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "NetSuite - AutoCommander";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.statusBarConnection.ResumeLayout(false);
            this.statusBarConnection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Button btnLoadCommands;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RichTextBox rtbLogCommand;
        private System.Windows.Forms.StatusStrip statusBarConnection;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusConnection;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

