namespace oBTC_ABC_Plus_Miner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gInfo = new System.Windows.Forms.GroupBox();
            this.tabDevices = new System.Windows.Forms.TabControl();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClearAdv = new System.Windows.Forms.Button();
            this.dataGridDevices = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelectAllAdv = new System.Windows.Forms.Button();
            this.btnStartAdv = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtParamsAMD = new System.Windows.Forms.TextBox();
            this.txtWalletAdv = new System.Windows.Forms.TextBox();
            this.txtParamsNvidia = new System.Windows.Forms.TextBox();
            this.txtPool = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nPort = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPort)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gInfo
            // 
            this.gInfo.Controls.Add(this.tabDevices);
            this.gInfo.Location = new System.Drawing.Point(12, 351);
            this.gInfo.Name = "gInfo";
            this.gInfo.Size = new System.Drawing.Size(1110, 298);
            this.gInfo.TabIndex = 7;
            this.gInfo.TabStop = false;
            this.gInfo.Text = "Info";
            // 
            // tabDevices
            // 
            this.tabDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDevices.Location = new System.Drawing.Point(3, 19);
            this.tabDevices.Name = "tabDevices";
            this.tabDevices.SelectedIndex = 0;
            this.tabDevices.Size = new System.Drawing.Size(1104, 276);
            this.tabDevices.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mining Pool:";
            // 
            // btnClearAdv
            // 
            this.btnClearAdv.Location = new System.Drawing.Point(947, 16);
            this.btnClearAdv.Name = "btnClearAdv";
            this.btnClearAdv.Size = new System.Drawing.Size(156, 24);
            this.btnClearAdv.TabIndex = 19;
            this.btnClearAdv.Text = "Clear Selection";
            this.btnClearAdv.UseVisualStyleBackColor = true;
            this.btnClearAdv.Click += new System.EventHandler(this.btnClearAdv_Click);
            // 
            // dataGridDevices
            // 
            this.dataGridDevices.AllowUserToAddRows = false;
            this.dataGridDevices.AllowUserToDeleteRows = false;
            this.dataGridDevices.AllowUserToResizeColumns = false;
            this.dataGridDevices.AllowUserToResizeRows = false;
            this.dataGridDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column7,
            this.Column8});
            this.dataGridDevices.Location = new System.Drawing.Point(447, 43);
            this.dataGridDevices.Name = "dataGridDevices";
            this.dataGridDevices.RowHeadersVisible = false;
            this.dataGridDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridDevices.Size = new System.Drawing.Size(656, 196);
            this.dataGridDevices.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Use";
            this.Column1.Name = "Column1";
            this.Column1.Width = 34;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "GPU Type";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 88;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "GPU Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 88;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "GPU ID";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 74;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "Worker";
            this.Column7.Name = "Column7";
            this.Column7.Width = 74;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.HeaderText = "Password";
            this.Column8.Name = "Column8";
            this.Column8.Width = 88;
            // 
            // btnSelectAllAdv
            // 
            this.btnSelectAllAdv.Location = new System.Drawing.Point(785, 16);
            this.btnSelectAllAdv.Name = "btnSelectAllAdv";
            this.btnSelectAllAdv.Size = new System.Drawing.Size(156, 24);
            this.btnSelectAllAdv.TabIndex = 18;
            this.btnSelectAllAdv.Text = "Select all";
            this.btnSelectAllAdv.UseVisualStyleBackColor = true;
            this.btnSelectAllAdv.Click += new System.EventHandler(this.btnSelectAllAdv_Click);
            // 
            // btnStartAdv
            // 
            this.btnStartAdv.Location = new System.Drawing.Point(11, 296);
            this.btnStartAdv.Name = "btnStartAdv";
            this.btnStartAdv.Size = new System.Drawing.Size(197, 31);
            this.btnStartAdv.TabIndex = 5;
            this.btnStartAdv.Text = "Start";
            this.btnStartAdv.UseVisualStyleBackColor = true;
            this.btnStartAdv.Click += new System.EventHandler(this.btnStartAdv_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(444, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "GPU List";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Wallet Address:";
            // 
            // txtParamsAMD
            // 
            this.txtParamsAMD.Location = new System.Drawing.Point(712, 284);
            this.txtParamsAMD.MaxLength = 42;
            this.txtParamsAMD.Name = "txtParamsAMD";
            this.txtParamsAMD.Size = new System.Drawing.Size(388, 23);
            this.txtParamsAMD.TabIndex = 16;
            // 
            // txtWalletAdv
            // 
            this.txtWalletAdv.Location = new System.Drawing.Point(126, 121);
            this.txtWalletAdv.MaxLength = 42;
            this.txtWalletAdv.Name = "txtWalletAdv";
            this.txtWalletAdv.Size = new System.Drawing.Size(315, 23);
            this.txtWalletAdv.TabIndex = 9;
            // 
            // txtParamsNvidia
            // 
            this.txtParamsNvidia.Location = new System.Drawing.Point(712, 245);
            this.txtParamsNvidia.MaxLength = 42;
            this.txtParamsNvidia.Name = "txtParamsNvidia";
            this.txtParamsNvidia.Size = new System.Drawing.Size(388, 23);
            this.txtParamsNvidia.TabIndex = 15;
            // 
            // txtPool
            // 
            this.txtPool.Location = new System.Drawing.Point(126, 43);
            this.txtPool.Name = "txtPool";
            this.txtPool.Size = new System.Drawing.Size(315, 23);
            this.txtPool.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(496, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(210, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "AMD Extra Params (SRBMiner) :";
            // 
            // nPort
            // 
            this.nPort.Location = new System.Drawing.Point(126, 82);
            this.nPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nPort.Name = "nPort";
            this.nPort.Size = new System.Drawing.Size(120, 23);
            this.nPort.TabIndex = 11;
            this.nPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(468, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(238, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Nvidia Extra Params (Suprminer) :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Pool Port:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPool);
            this.groupBox1.Controls.Add(this.btnClearAdv);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dataGridDevices);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnSelectAllAdv);
            this.groupBox1.Controls.Add(this.nPort);
            this.groupBox1.Controls.Add(this.btnStartAdv);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtParamsNvidia);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtWalletAdv);
            this.groupBox1.Controls.Add(this.txtParamsAMD);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1110, 333);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1134, 661);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gInfo);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "oBTC ABC+ Miner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.gInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPort)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gInfo;
        private System.Windows.Forms.TabControl tabDevices;
        private System.Windows.Forms.DataGridView dataGridDevices;
        private System.Windows.Forms.Button btnStartAdv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.TextBox txtParamsAMD;
        private System.Windows.Forms.TextBox txtParamsNvidia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nPort;
        private System.Windows.Forms.TextBox txtPool;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWalletAdv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClearAdv;
        private System.Windows.Forms.Button btnSelectAllAdv;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

