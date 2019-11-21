namespace GetAddition
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnAddition = new System.Windows.Forms.Button();
            this.timerAddition = new System.Windows.Forms.Timer(this.components);
            this.timerAddition2 = new System.Windows.Forms.Timer(this.components);
            this.timerAddition3 = new System.Windows.Forms.Timer(this.components);
            this.lFolders = new System.Windows.Forms.ListBox();
            this.btnFolders = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lCount = new System.Windows.Forms.Label();
            this.ckFullBookName = new System.Windows.Forms.CheckBox();
            this.btnOptions = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lFailed = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.nChangeInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lPossibleFail = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbProxyList = new System.Windows.Forms.RadioButton();
            this.rbProxy = new System.Windows.Forms.RadioButton();
            this.rbNoProxy = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nChangeInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nInterval)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddition
            // 
            this.btnAddition.Location = new System.Drawing.Point(425, 391);
            this.btnAddition.Name = "btnAddition";
            this.btnAddition.Size = new System.Drawing.Size(75, 23);
            this.btnAddition.TabIndex = 0;
            this.btnAddition.Text = "Go";
            this.btnAddition.UseVisualStyleBackColor = true;
            this.btnAddition.Click += new System.EventHandler(this.btnAddition_Click);
            // 
            // timerAddition
            // 
            this.timerAddition.Interval = 2000;
            this.timerAddition.Tick += new System.EventHandler(this.timerAddition_Tick);
            // 
            // timerAddition2
            // 
            this.timerAddition2.Interval = 2000;
            this.timerAddition2.Tick += new System.EventHandler(this.timerAddition2_Tick);
            // 
            // timerAddition3
            // 
            this.timerAddition3.Interval = 2000;
            this.timerAddition3.Tick += new System.EventHandler(this.timerAddition3_Tick);
            // 
            // lFolders
            // 
            this.lFolders.FormattingEnabled = true;
            this.lFolders.Location = new System.Drawing.Point(16, 41);
            this.lFolders.Name = "lFolders";
            this.lFolders.ScrollAlwaysVisible = true;
            this.lFolders.Size = new System.Drawing.Size(485, 95);
            this.lFolders.TabIndex = 2;
            // 
            // btnFolders
            // 
            this.btnFolders.Location = new System.Drawing.Point(508, 41);
            this.btnFolders.Name = "btnFolders";
            this.btnFolders.Size = new System.Drawing.Size(75, 23);
            this.btnFolders.TabIndex = 3;
            this.btnFolders.Text = "Choose folders";
            this.btnFolders.UseVisualStyleBackColor = true;
            this.btnFolders.Click += new System.EventHandler(this.btnFolders_Click);
            // 
            // lCount
            // 
            this.lCount.AutoSize = true;
            this.lCount.Location = new System.Drawing.Point(19, 401);
            this.lCount.Name = "lCount";
            this.lCount.Size = new System.Drawing.Size(35, 13);
            this.lCount.TabIndex = 4;
            this.lCount.Text = "label1";
            // 
            // ckFullBookName
            // 
            this.ckFullBookName.AutoSize = true;
            this.ckFullBookName.Location = new System.Drawing.Point(225, 166);
            this.ckFullBookName.Name = "ckFullBookName";
            this.ckFullBookName.Size = new System.Drawing.Size(115, 17);
            this.ckFullBookName.TabIndex = 6;
            this.ckFullBookName.Text = "use full book name";
            this.ckFullBookName.UseVisualStyleBackColor = true;
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(508, 79);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(75, 23);
            this.btnOptions.TabIndex = 7;
            this.btnOptions.Text = "options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(504, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lFailed
            // 
            this.lFailed.FormattingEnabled = true;
            this.lFailed.Location = new System.Drawing.Point(16, 214);
            this.lFailed.Name = "lFailed";
            this.lFailed.ScrollAlwaysVisible = true;
            this.lFailed.Size = new System.Drawing.Size(485, 69);
            this.lFailed.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(591, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accSetup});
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.setupToolStripMenuItem.Text = "Setup";
            // 
            // accSetup
            // 
            this.accSetup.Name = "accSetup";
            this.accSetup.Size = new System.Drawing.Size(118, 22);
            this.accSetup.Text = "Accounts";
            // 
            // nChangeInterval
            // 
            this.nChangeInterval.Enabled = false;
            this.nChangeInterval.Location = new System.Drawing.Point(451, 146);
            this.nChangeInterval.Name = "nChangeInterval";
            this.nChangeInterval.Size = new System.Drawing.Size(49, 20);
            this.nChangeInterval.TabIndex = 13;
            this.nChangeInterval.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "change proxy every";
            // 
            // nInterval
            // 
            this.nInterval.Location = new System.Drawing.Point(451, 173);
            this.nInterval.Name = "nInterval";
            this.nInterval.Size = new System.Drawing.Size(49, 20);
            this.nInterval.TabIndex = 15;
            this.nInterval.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "pause (seconds)";
            // 
            // lPossibleFail
            // 
            this.lPossibleFail.FormattingEnabled = true;
            this.lPossibleFail.Location = new System.Drawing.Point(16, 306);
            this.lPossibleFail.Name = "lPossibleFail";
            this.lPossibleFail.ScrollAlwaysVisible = true;
            this.lPossibleFail.Size = new System.Drawing.Size(485, 69);
            this.lPossibleFail.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbProxyList);
            this.groupBox1.Controls.Add(this.rbProxy);
            this.groupBox1.Controls.Add(this.rbNoProxy);
            this.groupBox1.Location = new System.Drawing.Point(16, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 49);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "mode";
            // 
            // rbProxyList
            // 
            this.rbProxyList.AutoSize = true;
            this.rbProxyList.Location = new System.Drawing.Point(133, 19);
            this.rbProxyList.Name = "rbProxyList";
            this.rbProxyList.Size = new System.Drawing.Size(65, 17);
            this.rbProxyList.TabIndex = 0;
            this.rbProxyList.Text = "proxy list";
            this.rbProxyList.UseVisualStyleBackColor = true;
            // 
            // rbProxy
            // 
            this.rbProxy.AutoSize = true;
            this.rbProxy.Location = new System.Drawing.Point(77, 19);
            this.rbProxy.Name = "rbProxy";
            this.rbProxy.Size = new System.Drawing.Size(50, 17);
            this.rbProxy.TabIndex = 0;
            this.rbProxy.Text = "proxy";
            this.rbProxy.UseVisualStyleBackColor = true;
            // 
            // rbNoProxy
            // 
            this.rbNoProxy.AutoSize = true;
            this.rbNoProxy.Checked = true;
            this.rbNoProxy.Location = new System.Drawing.Point(6, 19);
            this.rbNoProxy.Name = "rbNoProxy";
            this.rbNoProxy.Size = new System.Drawing.Size(65, 17);
            this.rbNoProxy.TabIndex = 0;
            this.rbNoProxy.TabStop = true;
            this.rbNoProxy.Text = "no proxy";
            this.rbNoProxy.UseVisualStyleBackColor = true;
            this.rbNoProxy.CheckedChanged += new System.EventHandler(this.rbNoProxy_CheckedChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(508, 391);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 432);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nInterval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nChangeInterval);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.ckFullBookName);
            this.Controls.Add(this.lCount);
            this.Controls.Add(this.btnFolders);
            this.Controls.Add(this.lPossibleFail);
            this.Controls.Add(this.lFailed);
            this.Controls.Add(this.lFolders);
            this.Controls.Add(this.btnAddition);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nChangeInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nInterval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddition;
        private System.Windows.Forms.Timer timerAddition;
        private System.Windows.Forms.Timer timerAddition2;
        private System.Windows.Forms.Timer timerAddition3;
        private System.Windows.Forms.ListBox lFolders;
        private System.Windows.Forms.Button btnFolders;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lCount;
        private System.Windows.Forms.CheckBox ckFullBookName;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox lFailed;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accSetup;
        private System.Windows.Forms.NumericUpDown nChangeInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lPossibleFail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbProxy;
        private System.Windows.Forms.RadioButton rbNoProxy;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton rbProxyList;
        private System.Windows.Forms.Button btnCancel;
    }
}

