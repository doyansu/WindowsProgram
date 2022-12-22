namespace TaskExample
{
    partial class TaskExampleForm
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
            this.countButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.demoButton = new System.Windows.Forms.Button();
            this.fileCountLabel = new System.Windows.Forms.Label();
            this.asyncCountButton = new System.Windows.Forms.Button();
            this.parallelCountButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countButtonFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.parallelProgressCountButton = new System.Windows.Forms.Button();
            this.lableFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.executionTimeLabel = new System.Windows.Forms.Label();
            this.chooseDirectoryFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.chooseDirectoryButton = new System.Windows.Forms.Button();
            this.directoryPathLabel = new System.Windows.Forms.Label();
            this.directoryGroupBox = new System.Windows.Forms.GroupBox();
            this.countGroupBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip.SuspendLayout();
            this.countButtonFlowLayoutPanel.SuspendLayout();
            this.lableFlowLayoutPanel.SuspendLayout();
            this.chooseDirectoryFlowLayoutPanel.SuspendLayout();
            this.directoryGroupBox.SuspendLayout();
            this.countGroupBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // countButton
            // 
            this.countButton.AutoSize = true;
            this.countButton.Location = new System.Drawing.Point(3, 3);
            this.countButton.Name = "countButton";
            this.countButton.Size = new System.Drawing.Size(75, 28);
            this.countButton.TabIndex = 0;
            this.countButton.Text = "Count";
            this.countButton.UseVisualStyleBackColor = true;
            this.countButton.Click += new System.EventHandler(this.countButtonClicked);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(3, 352);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(798, 33);
            this.progressBar.TabIndex = 1;
            // 
            // demoButton
            // 
            this.demoButton.AutoSize = true;
            this.demoButton.CausesValidation = false;
            this.demoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.demoButton.Location = new System.Drawing.Point(3, 241);
            this.demoButton.Name = "demoButton";
            this.demoButton.Size = new System.Drawing.Size(798, 111);
            this.demoButton.TabIndex = 2;
            this.demoButton.Text = "Demo (can this button be clicked)?";
            this.demoButton.UseVisualStyleBackColor = true;
            // 
            // fileCountLabel
            // 
            this.fileCountLabel.AutoSize = true;
            this.fileCountLabel.Location = new System.Drawing.Point(3, 0);
            this.fileCountLabel.Name = "fileCountLabel";
            this.fileCountLabel.Size = new System.Drawing.Size(453, 18);
            this.fileCountLabel.TabIndex = 3;
            this.fileCountLabel.Text = "Click one of the above Count buttons to start counting JPG files.";
            // 
            // asyncCountButton
            // 
            this.asyncCountButton.AutoSize = true;
            this.asyncCountButton.Location = new System.Drawing.Point(84, 3);
            this.asyncCountButton.Name = "asyncCountButton";
            this.asyncCountButton.Size = new System.Drawing.Size(114, 28);
            this.asyncCountButton.TabIndex = 4;
            this.asyncCountButton.Text = "Count (async)";
            this.asyncCountButton.UseVisualStyleBackColor = true;
            this.asyncCountButton.Click += new System.EventHandler(this.asyncCountButtonClicked);
            // 
            // parallelCountButton
            // 
            this.parallelCountButton.AutoSize = true;
            this.parallelCountButton.Location = new System.Drawing.Point(204, 3);
            this.parallelCountButton.Name = "parallelCountButton";
            this.parallelCountButton.Size = new System.Drawing.Size(187, 28);
            this.parallelCountButton.TabIndex = 5;
            this.parallelCountButton.Text = "Count (async + parallel)";
            this.parallelCountButton.UseVisualStyleBackColor = true;
            this.parallelCountButton.Click += new System.EventHandler(this.parallelCountButtonClicked);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(3, 3);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(798, 38);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(64, 34);
            this.toolStripMenuItem1.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(126, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItemClicked);
            // 
            // countButtonFlowLayoutPanel
            // 
            this.countButtonFlowLayoutPanel.AutoSize = true;
            this.countButtonFlowLayoutPanel.Controls.Add(this.countButton);
            this.countButtonFlowLayoutPanel.Controls.Add(this.asyncCountButton);
            this.countButtonFlowLayoutPanel.Controls.Add(this.parallelCountButton);
            this.countButtonFlowLayoutPanel.Controls.Add(this.parallelProgressCountButton);
            this.countButtonFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.countButtonFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.countButtonFlowLayoutPanel.Name = "countButtonFlowLayoutPanel";
            this.countButtonFlowLayoutPanel.Size = new System.Drawing.Size(665, 34);
            this.countButtonFlowLayoutPanel.TabIndex = 7;
            // 
            // parallelProgressCountButton
            // 
            this.parallelProgressCountButton.AutoSize = true;
            this.parallelProgressCountButton.Location = new System.Drawing.Point(397, 3);
            this.parallelProgressCountButton.Name = "parallelProgressCountButton";
            this.parallelProgressCountButton.Size = new System.Drawing.Size(265, 28);
            this.parallelProgressCountButton.TabIndex = 6;
            this.parallelProgressCountButton.Text = "Count (async + parallel + progress)";
            this.parallelProgressCountButton.UseVisualStyleBackColor = true;
            this.parallelProgressCountButton.Click += new System.EventHandler(this.parallelProgressCountButtonClicked);
            // 
            // lableFlowLayoutPanel
            // 
            this.lableFlowLayoutPanel.AutoSize = true;
            this.lableFlowLayoutPanel.Controls.Add(this.fileCountLabel);
            this.lableFlowLayoutPanel.Controls.Add(this.executionTimeLabel);
            this.lableFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lableFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.lableFlowLayoutPanel.Location = new System.Drawing.Point(3, 43);
            this.lableFlowLayoutPanel.Name = "lableFlowLayoutPanel";
            this.lableFlowLayoutPanel.Size = new System.Drawing.Size(665, 36);
            this.lableFlowLayoutPanel.TabIndex = 8;
            // 
            // executionTimeLabel
            // 
            this.executionTimeLabel.AutoSize = true;
            this.executionTimeLabel.Location = new System.Drawing.Point(3, 18);
            this.executionTimeLabel.Name = "executionTimeLabel";
            this.executionTimeLabel.Size = new System.Drawing.Size(146, 18);
            this.executionTimeLabel.TabIndex = 4;
            this.executionTimeLabel.Text = "Execution time: NA";
            // 
            // chooseDirectoryFlowLayoutPanel
            // 
            this.chooseDirectoryFlowLayoutPanel.AutoSize = true;
            this.chooseDirectoryFlowLayoutPanel.Controls.Add(this.chooseDirectoryButton);
            this.chooseDirectoryFlowLayoutPanel.Controls.Add(this.directoryPathLabel);
            this.chooseDirectoryFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.chooseDirectoryFlowLayoutPanel.Location = new System.Drawing.Point(10, 32);
            this.chooseDirectoryFlowLayoutPanel.Name = "chooseDirectoryFlowLayoutPanel";
            this.chooseDirectoryFlowLayoutPanel.Size = new System.Drawing.Size(778, 34);
            this.chooseDirectoryFlowLayoutPanel.TabIndex = 9;
            // 
            // chooseDirectoryButton
            // 
            this.chooseDirectoryButton.AutoSize = true;
            this.chooseDirectoryButton.Location = new System.Drawing.Point(3, 3);
            this.chooseDirectoryButton.Name = "chooseDirectoryButton";
            this.chooseDirectoryButton.Size = new System.Drawing.Size(139, 28);
            this.chooseDirectoryButton.TabIndex = 6;
            this.chooseDirectoryButton.Text = "Choose Directory";
            this.chooseDirectoryButton.UseVisualStyleBackColor = true;
            this.chooseDirectoryButton.Click += new System.EventHandler(this.chooseDirectoryButtonClicked);
            // 
            // directoryPathLabel
            // 
            this.directoryPathLabel.AutoSize = true;
            this.directoryPathLabel.Location = new System.Drawing.Point(148, 10);
            this.directoryPathLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.directoryPathLabel.Name = "directoryPathLabel";
            this.directoryPathLabel.Size = new System.Drawing.Size(93, 18);
            this.directoryPathLabel.TabIndex = 3;
            this.directoryPathLabel.Text = "C:\\Windows";
            // 
            // directoryGroupBox
            // 
            this.directoryGroupBox.AutoSize = true;
            this.directoryGroupBox.Controls.Add(this.chooseDirectoryFlowLayoutPanel);
            this.directoryGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.directoryGroupBox.Location = new System.Drawing.Point(3, 41);
            this.directoryGroupBox.Name = "directoryGroupBox";
            this.directoryGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.directoryGroupBox.Size = new System.Drawing.Size(798, 76);
            this.directoryGroupBox.TabIndex = 10;
            this.directoryGroupBox.TabStop = false;
            this.directoryGroupBox.Text = "Directory";
            // 
            // countGroupBox
            // 
            this.countGroupBox.AutoSize = true;
            this.countGroupBox.Controls.Add(this.flowLayoutPanel1);
            this.countGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.countGroupBox.Location = new System.Drawing.Point(3, 117);
            this.countGroupBox.Name = "countGroupBox";
            this.countGroupBox.Padding = new System.Windows.Forms.Padding(10);
            this.countGroupBox.Size = new System.Drawing.Size(798, 124);
            this.countGroupBox.TabIndex = 11;
            this.countGroupBox.TabStop = false;
            this.countGroupBox.Text = "Count JPG Files";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.countButtonFlowLayoutPanel);
            this.flowLayoutPanel1.Controls.Add(this.lableFlowLayoutPanel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 32);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(778, 82);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // TaskExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 388);
            this.Controls.Add(this.demoButton);
            this.Controls.Add(this.countGroupBox);
            this.Controls.Add(this.directoryGroupBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "TaskExampleForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Task Example";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.countButtonFlowLayoutPanel.ResumeLayout(false);
            this.countButtonFlowLayoutPanel.PerformLayout();
            this.lableFlowLayoutPanel.ResumeLayout(false);
            this.lableFlowLayoutPanel.PerformLayout();
            this.chooseDirectoryFlowLayoutPanel.ResumeLayout(false);
            this.chooseDirectoryFlowLayoutPanel.PerformLayout();
            this.directoryGroupBox.ResumeLayout(false);
            this.directoryGroupBox.PerformLayout();
            this.countGroupBox.ResumeLayout(false);
            this.countGroupBox.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button countButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button demoButton;
        private System.Windows.Forms.Label fileCountLabel;
        private System.Windows.Forms.Button asyncCountButton;
        private System.Windows.Forms.Button parallelCountButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel countButtonFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel lableFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel chooseDirectoryFlowLayoutPanel;
        private System.Windows.Forms.Button chooseDirectoryButton;
        private System.Windows.Forms.Label directoryPathLabel;
        private System.Windows.Forms.GroupBox directoryGroupBox;
        private System.Windows.Forms.Label executionTimeLabel;
        private System.Windows.Forms.GroupBox countGroupBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button parallelProgressCountButton;
    }
}

