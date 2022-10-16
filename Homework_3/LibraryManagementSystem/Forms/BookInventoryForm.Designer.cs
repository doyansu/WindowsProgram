
namespace LibraryManagementSystem
{
    partial class BookInventoryForm
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
            this._bookInformationDataGridView = new System.Windows.Forms.DataGridView();
            this._bookInventoryLabel = new System.Windows.Forms.Label();
            this._bookImageTextLabel = new System.Windows.Forms.Label();
            this._bookInformationTextLabel = new System.Windows.Forms.Label();
            this._bookInformationRichTextBox = new System.Windows.Forms.RichTextBox();
            this._bookImageLabel = new System.Windows.Forms.Label();
            this._bookImageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._bookInformationDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _bookInformationDataGridView
            // 
            this._bookInformationDataGridView.AllowUserToAddRows = false;
            this._bookInformationDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._bookInformationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._bookInformationDataGridView.Location = new System.Drawing.Point(12, 57);
            this._bookInformationDataGridView.MultiSelect = false;
            this._bookInformationDataGridView.Name = "_bookInformationDataGridView";
            this._bookInformationDataGridView.RowHeadersVisible = false;
            this._bookInformationDataGridView.RowTemplate.Height = 24;
            this._bookInformationDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._bookInformationDataGridView.Size = new System.Drawing.Size(526, 612);
            this._bookInformationDataGridView.TabIndex = 4;
            this._bookInformationDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDataGridViewCellContent);
            // 
            // _bookInventoryLabel
            // 
            this._bookInventoryLabel.AutoSize = true;
            this._bookInventoryLabel.Font = new System.Drawing.Font("微軟正黑體", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookInventoryLabel.Location = new System.Drawing.Point(391, 9);
            this._bookInventoryLabel.Name = "_bookInventoryLabel";
            this._bookInventoryLabel.Size = new System.Drawing.Size(300, 45);
            this._bookInventoryLabel.TabIndex = 5;
            this._bookInventoryLabel.Text = "書籍庫存管理系統";
            // 
            // _bookImageTextLabel
            // 
            this._bookImageTextLabel.AutoSize = true;
            this._bookImageTextLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookImageTextLabel.Location = new System.Drawing.Point(564, 57);
            this._bookImageTextLabel.Name = "_bookImageTextLabel";
            this._bookImageTextLabel.Size = new System.Drawing.Size(73, 20);
            this._bookImageTextLabel.TabIndex = 6;
            this._bookImageTextLabel.Text = "書籍圖片";
            // 
            // _bookInformationTextLabel
            // 
            this._bookInformationTextLabel.AutoSize = true;
            this._bookInformationTextLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookInformationTextLabel.Location = new System.Drawing.Point(564, 257);
            this._bookInformationTextLabel.Name = "_bookInformationTextLabel";
            this._bookInformationTextLabel.Size = new System.Drawing.Size(73, 20);
            this._bookInformationTextLabel.TabIndex = 7;
            this._bookInformationTextLabel.Text = "書籍資訊";
            // 
            // _bookInformationRichTextBox
            // 
            this._bookInformationRichTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this._bookInformationRichTextBox.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookInformationRichTextBox.Location = new System.Drawing.Point(544, 280);
            this._bookInformationRichTextBox.Name = "_bookInformationRichTextBox";
            this._bookInformationRichTextBox.Size = new System.Drawing.Size(508, 389);
            this._bookInformationRichTextBox.TabIndex = 8;
            this._bookInformationRichTextBox.Text = "";
            // 
            // _bookImageLabel
            // 
            this._bookImageLabel.Location = new System.Drawing.Point(566, 90);
            this._bookImageLabel.Name = "_bookImageLabel";
            this._bookImageLabel.Size = new System.Drawing.Size(120, 156);
            this._bookImageLabel.TabIndex = 9;
            // 
            // _bookImageList
            // 
            this._bookImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this._bookImageList.ImageSize = new System.Drawing.Size(120, 156);
            this._bookImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // BookInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this._bookImageLabel);
            this.Controls.Add(this._bookInformationRichTextBox);
            this.Controls.Add(this._bookInformationTextLabel);
            this.Controls.Add(this._bookImageTextLabel);
            this.Controls.Add(this._bookInventoryLabel);
            this.Controls.Add(this._bookInformationDataGridView);
            this.Name = "BookInventoryForm";
            this.Text = "書本庫存";
            ((System.ComponentModel.ISupportInitialize)(this._bookInformationDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _bookInformationDataGridView;
        private System.Windows.Forms.Label _bookInventoryLabel;
        private System.Windows.Forms.Label _bookImageTextLabel;
        private System.Windows.Forms.Label _bookInformationTextLabel;
        private System.Windows.Forms.RichTextBox _bookInformationRichTextBox;
        private System.Windows.Forms.Label _bookImageLabel;
        private System.Windows.Forms.ImageList _bookImageList;
    }
}