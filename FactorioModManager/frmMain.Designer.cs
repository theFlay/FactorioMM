namespace FactorioModManager
{
    partial class frmMain
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
            this.clbModList = new System.Windows.Forms.CheckedListBox();
            this.txtbModsDirectory = new System.Windows.Forms.TextBox();
            this.pSettings = new System.Windows.Forms.Panel();
            this.cbUpdateOnlyEnabled = new System.Windows.Forms.CheckBox();
            this.btnRestoreDefaults = new System.Windows.Forms.Button();
            this.lblToken = new System.Windows.Forms.Label();
            this.txtbToken = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtbUsername = new System.Windows.Forms.TextBox();
            this.txtbModHost = new System.Windows.Forms.TextBox();
            this.lblModHost = new System.Windows.Forms.Label();
            this.lblModsDirectory = new System.Windows.Forms.Label();
            this.btnModsDirectory = new System.Windows.Forms.Button();
            this.txtbActionLog = new System.Windows.Forms.TextBox();
            this.btnUpdateMods = new System.Windows.Forms.Button();
            this.btnEnableAll = new System.Windows.Forms.Button();
            this.btnDisableAll = new System.Windows.Forms.Button();
            this.pSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbModList
            // 
            this.clbModList.FormattingEnabled = true;
            this.clbModList.Location = new System.Drawing.Point(12, 124);
            this.clbModList.Name = "clbModList";
            this.clbModList.Size = new System.Drawing.Size(212, 289);
            this.clbModList.TabIndex = 14;
            this.clbModList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbModList_ItemCheck);
            // 
            // txtbModsDirectory
            // 
            this.txtbModsDirectory.Enabled = false;
            this.txtbModsDirectory.Location = new System.Drawing.Point(96, 98);
            this.txtbModsDirectory.Name = "txtbModsDirectory";
            this.txtbModsDirectory.Size = new System.Drawing.Size(619, 20);
            this.txtbModsDirectory.TabIndex = 15;
            this.txtbModsDirectory.TextChanged += new System.EventHandler(this.txtbModsDirectory_TextChanged);
            // 
            // pSettings
            // 
            this.pSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSettings.Controls.Add(this.cbUpdateOnlyEnabled);
            this.pSettings.Controls.Add(this.btnRestoreDefaults);
            this.pSettings.Controls.Add(this.lblToken);
            this.pSettings.Controls.Add(this.txtbToken);
            this.pSettings.Controls.Add(this.lblUsername);
            this.pSettings.Controls.Add(this.txtbUsername);
            this.pSettings.Controls.Add(this.txtbModHost);
            this.pSettings.Controls.Add(this.lblModHost);
            this.pSettings.Location = new System.Drawing.Point(12, 12);
            this.pSettings.Name = "pSettings";
            this.pSettings.Size = new System.Drawing.Size(733, 80);
            this.pSettings.TabIndex = 16;
            // 
            // cbUpdateOnlyEnabled
            // 
            this.cbUpdateOnlyEnabled.AutoSize = true;
            this.cbUpdateOnlyEnabled.Location = new System.Drawing.Point(576, 5);
            this.cbUpdateOnlyEnabled.Name = "cbUpdateOnlyEnabled";
            this.cbUpdateOnlyEnabled.Size = new System.Drawing.Size(152, 17);
            this.cbUpdateOnlyEnabled.TabIndex = 21;
            this.cbUpdateOnlyEnabled.Text = "Only update enabled mods";
            this.cbUpdateOnlyEnabled.UseVisualStyleBackColor = true;
            this.cbUpdateOnlyEnabled.CheckedChanged += new System.EventHandler(this.cbUpdateOnlyEnabled_CheckedChanged);
            // 
            // btnRestoreDefaults
            // 
            this.btnRestoreDefaults.Location = new System.Drawing.Point(639, 30);
            this.btnRestoreDefaults.Name = "btnRestoreDefaults";
            this.btnRestoreDefaults.Size = new System.Drawing.Size(89, 46);
            this.btnRestoreDefaults.TabIndex = 20;
            this.btnRestoreDefaults.Text = "Restore Defaults";
            this.btnRestoreDefaults.UseVisualStyleBackColor = true;
            this.btnRestoreDefaults.Click += new System.EventHandler(this.btnRestoreDefaults_Click);
            // 
            // lblToken
            // 
            this.lblToken.AutoSize = true;
            this.lblToken.Location = new System.Drawing.Point(8, 58);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(41, 13);
            this.lblToken.TabIndex = 19;
            this.lblToken.Text = "Token:";
            // 
            // txtbToken
            // 
            this.txtbToken.Location = new System.Drawing.Point(75, 55);
            this.txtbToken.Name = "txtbToken";
            this.txtbToken.Size = new System.Drawing.Size(558, 20);
            this.txtbToken.TabIndex = 18;
            this.txtbToken.TextChanged += new System.EventHandler(this.txtbToken_TextChanged);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(5, 32);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 17;
            this.lblUsername.Text = "Username:";
            // 
            // txtbUsername
            // 
            this.txtbUsername.Location = new System.Drawing.Point(75, 29);
            this.txtbUsername.Name = "txtbUsername";
            this.txtbUsername.Size = new System.Drawing.Size(558, 20);
            this.txtbUsername.TabIndex = 16;
            this.txtbUsername.TextChanged += new System.EventHandler(this.txtbUsername_TextChanged);
            // 
            // txtbModHost
            // 
            this.txtbModHost.Location = new System.Drawing.Point(75, 3);
            this.txtbModHost.Name = "txtbModHost";
            this.txtbModHost.Size = new System.Drawing.Size(495, 20);
            this.txtbModHost.TabIndex = 15;
            this.txtbModHost.TextChanged += new System.EventHandler(this.txtbModHost_TextChanged);
            // 
            // lblModHost
            // 
            this.lblModHost.AutoSize = true;
            this.lblModHost.Location = new System.Drawing.Point(5, 6);
            this.lblModHost.Name = "lblModHost";
            this.lblModHost.Size = new System.Drawing.Size(61, 13);
            this.lblModHost.TabIndex = 14;
            this.lblModHost.Text = "Mods Host:";
            // 
            // lblModsDirectory
            // 
            this.lblModsDirectory.AutoSize = true;
            this.lblModsDirectory.Location = new System.Drawing.Point(12, 101);
            this.lblModsDirectory.Name = "lblModsDirectory";
            this.lblModsDirectory.Size = new System.Drawing.Size(81, 13);
            this.lblModsDirectory.TabIndex = 17;
            this.lblModsDirectory.Text = "Mods Directory:";
            // 
            // btnModsDirectory
            // 
            this.btnModsDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModsDirectory.Location = new System.Drawing.Point(721, 95);
            this.btnModsDirectory.Name = "btnModsDirectory";
            this.btnModsDirectory.Size = new System.Drawing.Size(24, 24);
            this.btnModsDirectory.TabIndex = 18;
            this.btnModsDirectory.Text = "...";
            this.btnModsDirectory.UseVisualStyleBackColor = true;
            this.btnModsDirectory.Click += new System.EventHandler(this.btnModsDirectory_Click);
            // 
            // txtbActionLog
            // 
            this.txtbActionLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbActionLog.Location = new System.Drawing.Point(321, 124);
            this.txtbActionLog.Multiline = true;
            this.txtbActionLog.Name = "txtbActionLog";
            this.txtbActionLog.ReadOnly = true;
            this.txtbActionLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbActionLog.Size = new System.Drawing.Size(424, 289);
            this.txtbActionLog.TabIndex = 23;
            // 
            // btnUpdateMods
            // 
            this.btnUpdateMods.Location = new System.Drawing.Point(230, 124);
            this.btnUpdateMods.Name = "btnUpdateMods";
            this.btnUpdateMods.Size = new System.Drawing.Size(85, 23);
            this.btnUpdateMods.TabIndex = 24;
            this.btnUpdateMods.Text = "Update Mods";
            this.btnUpdateMods.UseVisualStyleBackColor = true;
            this.btnUpdateMods.Click += new System.EventHandler(this.btnUpdateMods_Click);
            // 
            // btnEnableAll
            // 
            this.btnEnableAll.Location = new System.Drawing.Point(230, 153);
            this.btnEnableAll.Name = "btnEnableAll";
            this.btnEnableAll.Size = new System.Drawing.Size(85, 23);
            this.btnEnableAll.TabIndex = 25;
            this.btnEnableAll.Text = "Enable All";
            this.btnEnableAll.UseVisualStyleBackColor = true;
            this.btnEnableAll.Click += new System.EventHandler(this.btnEnableAll_Click);
            // 
            // btnDisableAll
            // 
            this.btnDisableAll.Location = new System.Drawing.Point(230, 182);
            this.btnDisableAll.Name = "btnDisableAll";
            this.btnDisableAll.Size = new System.Drawing.Size(85, 23);
            this.btnDisableAll.TabIndex = 26;
            this.btnDisableAll.Text = "Disable All";
            this.btnDisableAll.UseVisualStyleBackColor = true;
            this.btnDisableAll.Click += new System.EventHandler(this.btnDisableAll_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 424);
            this.Controls.Add(this.btnDisableAll);
            this.Controls.Add(this.btnEnableAll);
            this.Controls.Add(this.btnUpdateMods);
            this.Controls.Add(this.txtbActionLog);
            this.Controls.Add(this.btnModsDirectory);
            this.Controls.Add(this.lblModsDirectory);
            this.Controls.Add(this.pSettings);
            this.Controls.Add(this.txtbModsDirectory);
            this.Controls.Add(this.clbModList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmMain";
            this.Text = "Factorio Mod Manager";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pSettings.ResumeLayout(false);
            this.pSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbModList;
        private System.Windows.Forms.TextBox txtbModsDirectory;
        private System.Windows.Forms.Panel pSettings;
        private System.Windows.Forms.CheckBox cbUpdateOnlyEnabled;
        private System.Windows.Forms.Button btnRestoreDefaults;
        private System.Windows.Forms.Label lblToken;
        private System.Windows.Forms.TextBox txtbToken;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtbUsername;
        private System.Windows.Forms.TextBox txtbModHost;
        private System.Windows.Forms.Label lblModHost;
        private System.Windows.Forms.Label lblModsDirectory;
        private System.Windows.Forms.Button btnModsDirectory;
        private System.Windows.Forms.TextBox txtbActionLog;
        private System.Windows.Forms.Button btnUpdateMods;
        private System.Windows.Forms.Button btnEnableAll;
        private System.Windows.Forms.Button btnDisableAll;
    }
}

