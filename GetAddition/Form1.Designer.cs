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
            this.btnOptions = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lFailed = new System.Windows.Forms.ListBox();
            this.nChangeInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lPossibleFail = new System.Windows.Forms.ListBox();
            this.gbProxyMode = new System.Windows.Forms.GroupBox();
            this.rbProxyList = new System.Windows.Forms.RadioButton();
            this.rbProxy = new System.Windows.Forms.RadioButton();
            this.rbNoProxy = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nChangeInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nInterval)).BeginInit();
            this.gbProxyMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddition
            // 
            this.btnAddition.Location = new System.Drawing.Point(559, 453);
            this.btnAddition.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddition.Name = "btnAddition";
            this.btnAddition.Size = new System.Drawing.Size(100, 28);
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
            this.lFolders.ItemHeight = 16;
            this.lFolders.Location = new System.Drawing.Point(13, 22);
            this.lFolders.Margin = new System.Windows.Forms.Padding(4);
            this.lFolders.Name = "lFolders";
            this.lFolders.ScrollAlwaysVisible = true;
            this.lFolders.Size = new System.Drawing.Size(645, 116);
            this.lFolders.TabIndex = 2;
            // 
            // btnFolders
            // 
            this.btnFolders.Location = new System.Drawing.Point(669, 22);
            this.btnFolders.Margin = new System.Windows.Forms.Padding(4);
            this.btnFolders.Name = "btnFolders";
            this.btnFolders.Size = new System.Drawing.Size(100, 28);
            this.btnFolders.TabIndex = 3;
            this.btnFolders.Text = "Choose folders";
            this.btnFolders.UseVisualStyleBackColor = true;
            this.btnFolders.Click += new System.EventHandler(this.btnFolders_Click);
            // 
            // lCount
            // 
            this.lCount.AutoSize = true;
            this.lCount.Location = new System.Drawing.Point(17, 466);
            this.lCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lCount.Name = "lCount";
            this.lCount.Size = new System.Drawing.Size(46, 17);
            this.lCount.TabIndex = 4;
            this.lCount.Text = "label1";
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(669, 69);
            this.btnOptions.Margin = new System.Windows.Forms.Padding(4);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(100, 28);
            this.btnOptions.TabIndex = 7;
            this.btnOptions.Text = "options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(664, 205);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
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
            this.lFailed.ItemHeight = 16;
            this.lFailed.Location = new System.Drawing.Point(13, 235);
            this.lFailed.Margin = new System.Windows.Forms.Padding(4);
            this.lFailed.Name = "lFailed";
            this.lFailed.ScrollAlwaysVisible = true;
            this.lFailed.Size = new System.Drawing.Size(645, 84);
            this.lFailed.TabIndex = 2;
            // 
            // nChangeInterval
            // 
            this.nChangeInterval.Enabled = false;
            this.nChangeInterval.Location = new System.Drawing.Point(593, 152);
            this.nChangeInterval.Margin = new System.Windows.Forms.Padding(4);
            this.nChangeInterval.Name = "nChangeInterval";
            this.nChangeInterval.Size = new System.Drawing.Size(64, 22);
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
            this.label1.Location = new System.Drawing.Point(452, 154);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "change proxy every";
            // 
            // nInterval
            // 
            this.nInterval.Location = new System.Drawing.Point(593, 185);
            this.nInterval.Margin = new System.Windows.Forms.Padding(4);
            this.nInterval.Name = "nInterval";
            this.nInterval.Size = new System.Drawing.Size(64, 22);
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
            this.label2.Location = new System.Drawing.Point(452, 187);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "pause (seconds)";
            // 
            // lPossibleFail
            // 
            this.lPossibleFail.FormattingEnabled = true;
            this.lPossibleFail.ItemHeight = 16;
            this.lPossibleFail.Location = new System.Drawing.Point(13, 349);
            this.lPossibleFail.Margin = new System.Windows.Forms.Padding(4);
            this.lPossibleFail.Name = "lPossibleFail";
            this.lPossibleFail.ScrollAlwaysVisible = true;
            this.lPossibleFail.Size = new System.Drawing.Size(645, 84);
            this.lPossibleFail.TabIndex = 2;
            // 
            // gbProxyMode
            // 
            this.gbProxyMode.Controls.Add(this.rbProxyList);
            this.gbProxyMode.Controls.Add(this.rbProxy);
            this.gbProxyMode.Controls.Add(this.rbNoProxy);
            this.gbProxyMode.Location = new System.Drawing.Point(13, 152);
            this.gbProxyMode.Margin = new System.Windows.Forms.Padding(4);
            this.gbProxyMode.Name = "gbProxyMode";
            this.gbProxyMode.Padding = new System.Windows.Forms.Padding(4);
            this.gbProxyMode.Size = new System.Drawing.Size(271, 60);
            this.gbProxyMode.TabIndex = 17;
            this.gbProxyMode.TabStop = false;
            this.gbProxyMode.Text = "mode";
            // 
            // rbProxyList
            // 
            this.rbProxyList.AutoSize = true;
            this.rbProxyList.Location = new System.Drawing.Point(177, 23);
            this.rbProxyList.Margin = new System.Windows.Forms.Padding(4);
            this.rbProxyList.Name = "rbProxyList";
            this.rbProxyList.Size = new System.Drawing.Size(84, 21);
            this.rbProxyList.TabIndex = 0;
            this.rbProxyList.Text = "proxy list";
            this.rbProxyList.UseVisualStyleBackColor = true;
            // 
            // rbProxy
            // 
            this.rbProxy.AutoSize = true;
            this.rbProxy.Location = new System.Drawing.Point(103, 23);
            this.rbProxy.Margin = new System.Windows.Forms.Padding(4);
            this.rbProxy.Name = "rbProxy";
            this.rbProxy.Size = new System.Drawing.Size(63, 21);
            this.rbProxy.TabIndex = 0;
            this.rbProxy.Text = "proxy";
            this.rbProxy.UseVisualStyleBackColor = true;
            // 
            // rbNoProxy
            // 
            this.rbNoProxy.AutoSize = true;
            this.rbNoProxy.Checked = true;
            this.rbNoProxy.Location = new System.Drawing.Point(8, 23);
            this.rbNoProxy.Margin = new System.Windows.Forms.Padding(4);
            this.rbNoProxy.Name = "rbNoProxy";
            this.rbNoProxy.Size = new System.Drawing.Size(83, 21);
            this.rbNoProxy.TabIndex = 0;
            this.rbNoProxy.TabStop = true;
            this.rbNoProxy.Text = "no proxy";
            this.rbNoProxy.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(669, 453);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 498);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbProxyMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nInterval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nChangeInterval);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.lCount);
            this.Controls.Add(this.btnFolders);
            this.Controls.Add(this.lPossibleFail);
            this.Controls.Add(this.lFailed);
            this.Controls.Add(this.lFolders);
            this.Controls.Add(this.btnAddition);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nChangeInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nInterval)).EndInit();
            this.gbProxyMode.ResumeLayout(false);
            this.gbProxyMode.PerformLayout();
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
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox lFailed;
        private System.Windows.Forms.NumericUpDown nChangeInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lPossibleFail;
        private System.Windows.Forms.GroupBox gbProxyMode;
        private System.Windows.Forms.RadioButton rbProxy;
        private System.Windows.Forms.RadioButton rbNoProxy;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton rbProxyList;
        private System.Windows.Forms.Button btnCancel;
    }
}

