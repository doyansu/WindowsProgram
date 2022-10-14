
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
            this.components = new System.ComponentModel.Container();
            this._backPackDataGridView = new System.Windows.Forms.DataGridView();
            this._backPackBookRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._returnButtonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._returnCountDataGridViewTextBoxColumn = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this._bookNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._borrowedCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._borrowingDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._returnDueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._bookNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._bookAuthorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._bookPublicationItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._backPackDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._backPackBookRowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _backPackDataGridView
            // 
            this._backPackDataGridView.AllowUserToAddRows = false;
            this._backPackDataGridView.AutoGenerateColumns = false;
            this._backPackDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._backPackDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._backPackDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._returnButtonDataGridViewTextBoxColumn,
            this._returnCountDataGridViewTextBoxColumn,
            this._bookNameDataGridViewTextBoxColumn,
            this._borrowedCountDataGridViewTextBoxColumn,
            this._borrowingDateDataGridViewTextBoxColumn,
            this._returnDueDataGridViewTextBoxColumn,
            this._bookNumberDataGridViewTextBoxColumn,
            this._bookAuthorDataGridViewTextBoxColumn,
            this._bookPublicationItemDataGridViewTextBoxColumn});
            this._backPackDataGridView.DataSource = this._backPackBookRowBindingSource;
            this._backPackDataGridView.Location = new System.Drawing.Point(12, 12);
            this._backPackDataGridView.Name = "_backPackDataGridView";
            this._backPackDataGridView.ReadOnly = true;
            this._backPackDataGridView.RowHeadersVisible = false;
            this._backPackDataGridView.RowTemplate.Height = 24;
            this._backPackDataGridView.Size = new System.Drawing.Size(776, 426);
            this._backPackDataGridView.TabIndex = 0;
            // 
            // _backPackBookRowBindingSource
            // 
            this._backPackBookRowBindingSource.DataSource = typeof(LibraryManagementSystem.PresentationModel.BindingListObject.BackPackRow);
            // 
            // _returnButtonDataGridViewTextBoxColumn
            // 
            this._returnButtonDataGridViewTextBoxColumn.FillWeight = 40F;
            this._returnButtonDataGridViewTextBoxColumn.HeaderText = "還書";
            this._returnButtonDataGridViewTextBoxColumn.Name = "_returnButtonDataGridViewTextBoxColumn";
            this._returnButtonDataGridViewTextBoxColumn.ReadOnly = true;
            this._returnButtonDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._returnButtonDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._returnButtonDataGridViewTextBoxColumn.Text = "歸還";
            this._returnButtonDataGridViewTextBoxColumn.UseColumnTextForButtonValue = true;
            // 
            // _returnCountDataGridViewTextBoxColumn
            // 
            this._returnCountDataGridViewTextBoxColumn.DataPropertyName = "ReturnCount";
            this._returnCountDataGridViewTextBoxColumn.FillWeight = 80F;
            this._returnCountDataGridViewTextBoxColumn.HeaderText = "歸還數量";
            this._returnCountDataGridViewTextBoxColumn.Name = "_returnCountDataGridViewTextBoxColumn";
            this._returnCountDataGridViewTextBoxColumn.ReadOnly = true;
            this._returnCountDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._returnCountDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _bookNameDataGridViewTextBoxColumn
            // 
            this._bookNameDataGridViewTextBoxColumn.DataPropertyName = "BookName";
            this._bookNameDataGridViewTextBoxColumn.FillWeight = 150F;
            this._bookNameDataGridViewTextBoxColumn.HeaderText = "書籍名稱";
            this._bookNameDataGridViewTextBoxColumn.Name = "_bookNameDataGridViewTextBoxColumn";
            this._bookNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _borrowedCountDataGridViewTextBoxColumn
            // 
            this._borrowedCountDataGridViewTextBoxColumn.DataPropertyName = "BorrowedCount";
            this._borrowedCountDataGridViewTextBoxColumn.FillWeight = 60F;
            this._borrowedCountDataGridViewTextBoxColumn.HeaderText = "數量";
            this._borrowedCountDataGridViewTextBoxColumn.Name = "_borrowedCountDataGridViewTextBoxColumn";
            this._borrowedCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _borrowingDateDataGridViewTextBoxColumn
            // 
            this._borrowingDateDataGridViewTextBoxColumn.DataPropertyName = "BorrowingDate";
            this._borrowingDateDataGridViewTextBoxColumn.FillWeight = 80F;
            this._borrowingDateDataGridViewTextBoxColumn.HeaderText = "借書日期";
            this._borrowingDateDataGridViewTextBoxColumn.Name = "_borrowingDateDataGridViewTextBoxColumn";
            this._borrowingDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _returnDueDataGridViewTextBoxColumn
            // 
            this._returnDueDataGridViewTextBoxColumn.DataPropertyName = "ReturnDue";
            this._returnDueDataGridViewTextBoxColumn.FillWeight = 80F;
            this._returnDueDataGridViewTextBoxColumn.HeaderText = "還書期限";
            this._returnDueDataGridViewTextBoxColumn.Name = "_returnDueDataGridViewTextBoxColumn";
            this._returnDueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _bookNumberDataGridViewTextBoxColumn
            // 
            this._bookNumberDataGridViewTextBoxColumn.DataPropertyName = "BookNumber";
            this._bookNumberDataGridViewTextBoxColumn.HeaderText = "書籍編號";
            this._bookNumberDataGridViewTextBoxColumn.Name = "_bookNumberDataGridViewTextBoxColumn";
            this._bookNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _bookAuthorDataGridViewTextBoxColumn
            // 
            this._bookAuthorDataGridViewTextBoxColumn.DataPropertyName = "BookAuthor";
            this._bookAuthorDataGridViewTextBoxColumn.HeaderText = "作者";
            this._bookAuthorDataGridViewTextBoxColumn.Name = "_bookAuthorDataGridViewTextBoxColumn";
            this._bookAuthorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _bookPublicationItemDataGridViewTextBoxColumn
            // 
            this._bookPublicationItemDataGridViewTextBoxColumn.DataPropertyName = "BookPublicationItem";
            this._bookPublicationItemDataGridViewTextBoxColumn.HeaderText = "出版項";
            this._bookPublicationItemDataGridViewTextBoxColumn.Name = "_bookPublicationItemDataGridViewTextBoxColumn";
            this._bookPublicationItemDataGridViewTextBoxColumn.ReadOnly = true;
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
            ((System.ComponentModel.ISupportInitialize)(this._backPackBookRowBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _backPackDataGridView;
        private System.Windows.Forms.BindingSource _backPackBookRowBindingSource;
        private System.Windows.Forms.DataGridViewButtonColumn _returnButtonDataGridViewTextBoxColumn;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn _returnCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bookNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _borrowedCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _borrowingDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _returnDueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bookNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bookAuthorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _bookPublicationItemDataGridViewTextBoxColumn;
    }
}