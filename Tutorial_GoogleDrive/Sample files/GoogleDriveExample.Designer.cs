namespace GoogleDriveUploader.View
{
    partial class GoogleDriveExample
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoogleDriveExample));
            this.mainViewTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._uploadGroupBox = new System.Windows.Forms.GroupBox();
            this._uploadPanel = new System.Windows.Forms.Panel();
            this._uploadTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._uploadLabel = new System.Windows.Forms.Label();
            this._uploadFilePathTextBox = new System.Windows.Forms.TextBox();
            this._uploadBrowseButton = new System.Windows.Forms.Button();
            this._uploadButton = new System.Windows.Forms.Button();
            this._downloadGroupBox = new System.Windows.Forms.GroupBox();
            this._downloadPanel = new System.Windows.Forms.Panel();
            this._downloadTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._downloadBrowseButton = new System.Windows.Forms.Button();
            this._downloadToTextBox = new System.Windows.Forms.TextBox();
            this._downloadToLabel = new System.Windows.Forms.Label();
            this._downloadButton = new System.Windows.Forms.Button();
            this._fileListBox = new System.Windows.Forms.ListBox();
            this._listFileOnRootButton = new System.Windows.Forms.Button();
            this._updateGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._updateButton = new System.Windows.Forms.Button();
            this._deleteGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this._deleteButton = new System.Windows.Forms.Button();
            this._uploadFileOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._downloadFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mainViewTableLayoutPanel.SuspendLayout();
            this._uploadGroupBox.SuspendLayout();
            this._uploadPanel.SuspendLayout();
            this._uploadTableLayoutPanel.SuspendLayout();
            this._downloadGroupBox.SuspendLayout();
            this._downloadPanel.SuspendLayout();
            this._downloadTableLayoutPanel.SuspendLayout();
            this._updateGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this._deleteGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainViewTableLayoutPanel
            // 
            this.mainViewTableLayoutPanel.ColumnCount = 1;
            this.mainViewTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainViewTableLayoutPanel.Controls.Add(this._uploadGroupBox, 0, 0);
            this.mainViewTableLayoutPanel.Controls.Add(this._downloadGroupBox, 0, 1);
            this.mainViewTableLayoutPanel.Controls.Add(this._updateGroupBox, 0, 2);
            this.mainViewTableLayoutPanel.Controls.Add(this._deleteGroupBox, 0, 3);
            this.mainViewTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainViewTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainViewTableLayoutPanel.Name = "mainViewTableLayoutPanel";
            this.mainViewTableLayoutPanel.RowCount = 4;
            this.mainViewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainViewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainViewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainViewTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainViewTableLayoutPanel.Size = new System.Drawing.Size(846, 503);
            this.mainViewTableLayoutPanel.TabIndex = 0;
            // 
            // _uploadGroupBox
            // 
            this._uploadGroupBox.Controls.Add(this._uploadPanel);
            this._uploadGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._uploadGroupBox.Location = new System.Drawing.Point(3, 3);
            this._uploadGroupBox.Name = "_uploadGroupBox";
            this._uploadGroupBox.Size = new System.Drawing.Size(840, 119);
            this._uploadGroupBox.TabIndex = 0;
            this._uploadGroupBox.TabStop = false;
            this._uploadGroupBox.Text = "Upload";
            // 
            // _uploadPanel
            // 
            this._uploadPanel.Controls.Add(this._uploadTableLayoutPanel);
            this._uploadPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._uploadPanel.Location = new System.Drawing.Point(3, 18);
            this._uploadPanel.Name = "_uploadPanel";
            this._uploadPanel.Size = new System.Drawing.Size(834, 98);
            this._uploadPanel.TabIndex = 0;
            // 
            // _uploadTableLayoutPanel
            // 
            this._uploadTableLayoutPanel.ColumnCount = 3;
            this._uploadTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._uploadTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._uploadTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this._uploadTableLayoutPanel.Controls.Add(this._uploadLabel, 0, 0);
            this._uploadTableLayoutPanel.Controls.Add(this._uploadFilePathTextBox, 1, 0);
            this._uploadTableLayoutPanel.Controls.Add(this._uploadBrowseButton, 2, 0);
            this._uploadTableLayoutPanel.Controls.Add(this._uploadButton, 2, 1);
            this._uploadTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._uploadTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._uploadTableLayoutPanel.Name = "_uploadTableLayoutPanel";
            this._uploadTableLayoutPanel.RowCount = 2;
            this._uploadTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this._uploadTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this._uploadTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._uploadTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._uploadTableLayoutPanel.Size = new System.Drawing.Size(834, 98);
            this._uploadTableLayoutPanel.TabIndex = 0;
            // 
            // _uploadLabel
            // 
            this._uploadLabel.AutoSize = true;
            this._uploadLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this._uploadLabel.Location = new System.Drawing.Point(128, 0);
            this._uploadLabel.Name = "_uploadLabel";
            this._uploadLabel.Size = new System.Drawing.Size(77, 30);
            this._uploadLabel.TabIndex = 0;
            this._uploadLabel.Text = "File to Upload :";
            this._uploadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _uploadFilePathTextBox
            // 
            this._uploadFilePathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._uploadFilePathTextBox.Location = new System.Drawing.Point(211, 3);
            this._uploadFilePathTextBox.Name = "_uploadFilePathTextBox";
            this._uploadFilePathTextBox.ReadOnly = true;
            this._uploadFilePathTextBox.Size = new System.Drawing.Size(411, 22);
            this._uploadFilePathTextBox.TabIndex = 1;
            // 
            // _uploadBrowseButton
            // 
            this._uploadBrowseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._uploadBrowseButton.Location = new System.Drawing.Point(628, 3);
            this._uploadBrowseButton.Name = "_uploadBrowseButton";
            this._uploadBrowseButton.Size = new System.Drawing.Size(203, 24);
            this._uploadBrowseButton.TabIndex = 2;
            this._uploadBrowseButton.Text = "Browse...";
            this._uploadBrowseButton.UseVisualStyleBackColor = true;
            this._uploadBrowseButton.Click += new System.EventHandler(this.ClickBrowseUploadFileButton);
            // 
            // _uploadButton
            // 
            this._uploadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._uploadButton.Location = new System.Drawing.Point(628, 33);
            this._uploadButton.Name = "_uploadButton";
            this._uploadButton.Size = new System.Drawing.Size(203, 62);
            this._uploadButton.TabIndex = 3;
            this._uploadButton.Text = "Upload";
            this._uploadButton.UseVisualStyleBackColor = true;
            this._uploadButton.Click += new System.EventHandler(this.ClickUploadButton);
            // 
            // _downloadGroupBox
            // 
            this._downloadGroupBox.Controls.Add(this._downloadPanel);
            this._downloadGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._downloadGroupBox.Location = new System.Drawing.Point(3, 128);
            this._downloadGroupBox.Name = "_downloadGroupBox";
            this._downloadGroupBox.Size = new System.Drawing.Size(840, 119);
            this._downloadGroupBox.TabIndex = 1;
            this._downloadGroupBox.TabStop = false;
            this._downloadGroupBox.Text = "Download";
            // 
            // _downloadPanel
            // 
            this._downloadPanel.Controls.Add(this._downloadTableLayoutPanel);
            this._downloadPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._downloadPanel.Location = new System.Drawing.Point(3, 18);
            this._downloadPanel.Name = "_downloadPanel";
            this._downloadPanel.Size = new System.Drawing.Size(834, 98);
            this._downloadPanel.TabIndex = 0;
            // 
            // _downloadTableLayoutPanel
            // 
            this._downloadTableLayoutPanel.ColumnCount = 4;
            this._downloadTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this._downloadTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this._downloadTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this._downloadTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this._downloadTableLayoutPanel.Controls.Add(this._downloadBrowseButton, 3, 1);
            this._downloadTableLayoutPanel.Controls.Add(this._downloadToTextBox, 2, 1);
            this._downloadTableLayoutPanel.Controls.Add(this._downloadToLabel, 1, 1);
            this._downloadTableLayoutPanel.Controls.Add(this._downloadButton, 3, 2);
            this._downloadTableLayoutPanel.Controls.Add(this._fileListBox, 0, 0);
            this._downloadTableLayoutPanel.Controls.Add(this._listFileOnRootButton, 3, 0);
            this._downloadTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._downloadTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._downloadTableLayoutPanel.Name = "_downloadTableLayoutPanel";
            this._downloadTableLayoutPanel.RowCount = 3;
            this._downloadTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._downloadTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this._downloadTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._downloadTableLayoutPanel.Size = new System.Drawing.Size(834, 98);
            this._downloadTableLayoutPanel.TabIndex = 0;
            // 
            // _downloadBrowseButton
            // 
            this._downloadBrowseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._downloadBrowseButton.Location = new System.Drawing.Point(723, 37);
            this._downloadBrowseButton.Name = "_downloadBrowseButton";
            this._downloadBrowseButton.Size = new System.Drawing.Size(108, 24);
            this._downloadBrowseButton.TabIndex = 6;
            this._downloadBrowseButton.Text = "Browse...";
            this._downloadBrowseButton.UseVisualStyleBackColor = true;
            this._downloadBrowseButton.Click += new System.EventHandler(this.ClickDownloadBrowseButton);
            // 
            // _downloadToTextBox
            // 
            this._downloadToTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._downloadToTextBox.Location = new System.Drawing.Point(339, 37);
            this._downloadToTextBox.Name = "_downloadToTextBox";
            this._downloadToTextBox.ReadOnly = true;
            this._downloadToTextBox.Size = new System.Drawing.Size(378, 22);
            this._downloadToTextBox.TabIndex = 4;
            // 
            // _downloadToLabel
            // 
            this._downloadToLabel.AutoSize = true;
            this._downloadToLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._downloadToLabel.Location = new System.Drawing.Point(259, 34);
            this._downloadToLabel.Name = "_downloadToLabel";
            this._downloadToLabel.Size = new System.Drawing.Size(74, 30);
            this._downloadToLabel.TabIndex = 1;
            this._downloadToLabel.Text = "Download to:";
            this._downloadToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _downloadButton
            // 
            this._downloadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._downloadButton.Location = new System.Drawing.Point(723, 67);
            this._downloadButton.Name = "_downloadButton";
            this._downloadButton.Size = new System.Drawing.Size(108, 28);
            this._downloadButton.TabIndex = 3;
            this._downloadButton.Text = "Download";
            this._downloadButton.UseVisualStyleBackColor = true;
            this._downloadButton.Click += new System.EventHandler(this.ClickDownloadButton);
            // 
            // _fileListBox
            // 
            this._fileListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._fileListBox.FormattingEnabled = true;
            this._fileListBox.ItemHeight = 12;
            this._fileListBox.Location = new System.Drawing.Point(3, 3);
            this._fileListBox.Name = "_fileListBox";
            this._downloadTableLayoutPanel.SetRowSpan(this._fileListBox, 3);
            this._fileListBox.Size = new System.Drawing.Size(250, 92);
            this._fileListBox.TabIndex = 5;
            // 
            // _listFileOnRootButton
            // 
            this._listFileOnRootButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listFileOnRootButton.Location = new System.Drawing.Point(723, 3);
            this._listFileOnRootButton.Name = "_listFileOnRootButton";
            this._listFileOnRootButton.Size = new System.Drawing.Size(108, 28);
            this._listFileOnRootButton.TabIndex = 7;
            this._listFileOnRootButton.Text = "List Files On Root ";
            this._listFileOnRootButton.UseVisualStyleBackColor = true;
            this._listFileOnRootButton.Click += new System.EventHandler(this.ClickListFileOnRootButton);
            // 
            // _updateGroupBox
            // 
            this._updateGroupBox.Controls.Add(this.tableLayoutPanel1);
            this._updateGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._updateGroupBox.Location = new System.Drawing.Point(3, 253);
            this._updateGroupBox.Name = "_updateGroupBox";
            this._updateGroupBox.Size = new System.Drawing.Size(840, 119);
            this._updateGroupBox.TabIndex = 2;
            this._updateGroupBox.TabStop = false;
            this._updateGroupBox.Text = "Update";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this._updateButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 98);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _updateButton
            // 
            this._updateButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._updateButton.Location = new System.Drawing.Point(281, 3);
            this._updateButton.Name = "_updateButton";
            this._updateButton.Size = new System.Drawing.Size(272, 92);
            this._updateButton.TabIndex = 0;
            this._updateButton.Text = "Update";
            this._updateButton.UseVisualStyleBackColor = true;
            this._updateButton.Click += new System.EventHandler(this.ClickUpdateButton);
            // 
            // _deleteGroupBox
            // 
            this._deleteGroupBox.Controls.Add(this.tableLayoutPanel2);
            this._deleteGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._deleteGroupBox.Location = new System.Drawing.Point(3, 378);
            this._deleteGroupBox.Name = "_deleteGroupBox";
            this._deleteGroupBox.Size = new System.Drawing.Size(840, 122);
            this._deleteGroupBox.TabIndex = 3;
            this._deleteGroupBox.TabStop = false;
            this._deleteGroupBox.Text = "Delete";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this._deleteButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(834, 101);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // _deleteButton
            // 
            this._deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._deleteButton.Location = new System.Drawing.Point(281, 3);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(272, 95);
            this._deleteButton.TabIndex = 0;
            this._deleteButton.Text = "Delete";
            this._deleteButton.UseVisualStyleBackColor = true;
            this._deleteButton.Click += new System.EventHandler(this.ClickDeleteButton);
            // 
            // _uploadFileOpenFileDialog
            // 
            this._uploadFileOpenFileDialog.FileName = "openFileDialog1";
            // 
            // GoogleDriveExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 503);
            this.Controls.Add(this.mainViewTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GoogleDriveExample";
            this.Text = "Google Drive Example";
            this.mainViewTableLayoutPanel.ResumeLayout(false);
            this._uploadGroupBox.ResumeLayout(false);
            this._uploadPanel.ResumeLayout(false);
            this._uploadTableLayoutPanel.ResumeLayout(false);
            this._uploadTableLayoutPanel.PerformLayout();
            this._downloadGroupBox.ResumeLayout(false);
            this._downloadPanel.ResumeLayout(false);
            this._downloadTableLayoutPanel.ResumeLayout(false);
            this._downloadTableLayoutPanel.PerformLayout();
            this._updateGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this._deleteGroupBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainViewTableLayoutPanel;
        private System.Windows.Forms.GroupBox _uploadGroupBox;
        private System.Windows.Forms.Panel _uploadPanel;
        private System.Windows.Forms.GroupBox _downloadGroupBox;
        private System.Windows.Forms.Panel _downloadPanel;
        private System.Windows.Forms.TableLayoutPanel _uploadTableLayoutPanel;
        private System.Windows.Forms.Button _uploadButton;
        private System.Windows.Forms.TableLayoutPanel _downloadTableLayoutPanel;
        private System.Windows.Forms.TextBox _downloadToTextBox;
        private System.Windows.Forms.Label _downloadToLabel;
        private System.Windows.Forms.Button _downloadButton;
        private System.Windows.Forms.ListBox _fileListBox;
        private System.Windows.Forms.GroupBox _updateGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox _deleteGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label _uploadLabel;
        private System.Windows.Forms.TextBox _uploadFilePathTextBox;
        private System.Windows.Forms.Button _uploadBrowseButton;
        private System.Windows.Forms.Button _updateButton;
        private System.Windows.Forms.Button _deleteButton;
        private System.Windows.Forms.Button _downloadBrowseButton;
        private System.Windows.Forms.OpenFileDialog _uploadFileOpenFileDialog;
        private System.Windows.Forms.FolderBrowserDialog _downloadFolderBrowserDialog;
        private System.Windows.Forms.Button _listFileOnRootButton;
    }
}

