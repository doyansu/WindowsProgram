
namespace LibraryManagementSystem
{
    partial class BackPackForm
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
            this._backPackDataGridView = new System.Windows.Forms.DataGridView();
            this._returnBookButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._bookNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._bookQuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._borrowDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._returnDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._bookNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._bookAuthorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._bookPublicationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._backPackDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _backPackDataGridView
            // 
            this._backPackDataGridView.AllowUserToAddRows = false;
            this._backPackDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._backPackDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._backPackDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._returnBookButtonColumn,
            this._bookNameColumn,
            this._bookQuantityColumn,
            this._borrowDateColumn,
            this._returnDateColumn,
            this._bookNumberColumn,
            this._bookAuthorColumn,
            this._bookPublicationColumn});
            this._backPackDataGridView.Location = new System.Drawing.Point(12, 12);
            this._backPackDataGridView.Name = "_backPackDataGridView";
            this._backPackDataGridView.ReadOnly = true;
            this._backPackDataGridView.RowHeadersVisible = false;
            this._backPackDataGridView.RowTemplate.Height = 24;
            this._backPackDataGridView.Size = new System.Drawing.Size(776, 426);
            this._backPackDataGridView.TabIndex = 0;
            // 
            // _returnBookButtonColumn
            // 
            this._returnBookButtonColumn.FillWeight = 50F;
            this._returnBookButtonColumn.HeaderText = "還書";
            this._returnBookButtonColumn.Name = "_returnBookButtonColumn";
            this._returnBookButtonColumn.ReadOnly = true;
            this._returnBookButtonColumn.Text = "歸還";
            this._returnBookButtonColumn.UseColumnTextForButtonValue = true;
            // 
            // _bookNameColumn
            // 
            this._bookNameColumn.FillWeight = 180F;
            this._bookNameColumn.HeaderText = "書籍名稱";
            this._bookNameColumn.Name = "_bookNameColumn";
            this._bookNameColumn.ReadOnly = true;
            // 
            // _bookQuantityColumn
            // 
            this._bookQuantityColumn.FillWeight = 50F;
            this._bookQuantityColumn.HeaderText = "數量";
            this._bookQuantityColumn.Name = "_bookQuantityColumn";
            this._bookQuantityColumn.ReadOnly = true;
            this._bookQuantityColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // _borrowDateColumn
            // 
            this._borrowDateColumn.FillWeight = 75F;
            this._borrowDateColumn.HeaderText = "借書日期";
            this._borrowDateColumn.Name = "_borrowDateColumn";
            this._borrowDateColumn.ReadOnly = true;
            // 
            // _returnDateColumn
            // 
            this._returnDateColumn.FillWeight = 75F;
            this._returnDateColumn.HeaderText = "還書期限";
            this._returnDateColumn.Name = "_returnDateColumn";
            this._returnDateColumn.ReadOnly = true;
            // 
            // _bookNumberColumn
            // 
            this._bookNumberColumn.HeaderText = "書籍編號";
            this._bookNumberColumn.Name = "_bookNumberColumn";
            this._bookNumberColumn.ReadOnly = true;
            // 
            // _bookAuthorColumn
            // 
            this._bookAuthorColumn.HeaderText = "作者";
            this._bookAuthorColumn.Name = "_bookAuthorColumn";
            this._bookAuthorColumn.ReadOnly = true;
            // 
            // _bookPublicationColumn
            // 
            this._bookPublicationColumn.HeaderText = "出版項";
            this._bookPublicationColumn.Name = "_bookPublicationColumn";
            this._bookPublicationColumn.ReadOnly = true;
            // 
            // BackPackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._backPackDataGridView);
            this.Name = "BackPackForm";
            this.Text = "我的書包(還書)";
            ((System.ComponentModel.ISupportInitialize)(this._backPackDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _backPackDataGridView;
        private System.Windows.Forms.DataGridViewButtonColumn _returnBookButtonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bookNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bookQuantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _borrowDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _returnDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bookNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bookAuthorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bookPublicationColumn;
    }
}