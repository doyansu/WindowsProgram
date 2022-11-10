
namespace LibraryManagementSystem
{
    partial class MenuForm
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
            this._bookBorrowingSystemButton = new System.Windows.Forms.Button();
            this._bookInventorySystemButton = new System.Windows.Forms.Button();
            this._exitButton = new System.Windows.Forms.Button();
            this._bookManagementSystemButton = new System.Windows.Forms.Button();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _bookBorrowingSystemButton
            // 
            this._bookBorrowingSystemButton.AutoSize = true;
            this._bookBorrowingSystemButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._bookBorrowingSystemButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._bookBorrowingSystemButton.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookBorrowingSystemButton.Location = new System.Drawing.Point(10, 10);
            this._bookBorrowingSystemButton.Margin = new System.Windows.Forms.Padding(10);
            this._bookBorrowingSystemButton.Name = "_bookBorrowingSystemButton";
            this._bookBorrowingSystemButton.Size = new System.Drawing.Size(780, 105);
            this._bookBorrowingSystemButton.TabIndex = 0;
            this._bookBorrowingSystemButton.Text = "Book Borrowing System";
            this._bookBorrowingSystemButton.UseVisualStyleBackColor = true;
            this._bookBorrowingSystemButton.Click += new System.EventHandler(this.BookBorrowingSystemButtonClick);
            // 
            // _bookInventorySystemButton
            // 
            this._bookInventorySystemButton.AutoSize = true;
            this._bookInventorySystemButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._bookInventorySystemButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._bookInventorySystemButton.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookInventorySystemButton.Location = new System.Drawing.Point(10, 135);
            this._bookInventorySystemButton.Margin = new System.Windows.Forms.Padding(10);
            this._bookInventorySystemButton.Name = "_bookInventorySystemButton";
            this._bookInventorySystemButton.Size = new System.Drawing.Size(780, 105);
            this._bookInventorySystemButton.TabIndex = 1;
            this._bookInventorySystemButton.Text = "Book Inventory System";
            this._bookInventorySystemButton.UseVisualStyleBackColor = true;
            this._bookInventorySystemButton.Click += new System.EventHandler(this.BookInventorySystemButtonClick);
            // 
            // _exitButton
            // 
            this._exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._exitButton.AutoSize = true;
            this._exitButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._exitButton.Location = new System.Drawing.Point(690, 386);
            this._exitButton.Margin = new System.Windows.Forms.Padding(10);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(100, 54);
            this._exitButton.TabIndex = 2;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // _bookManagementSystemButton
            // 
            this._bookManagementSystemButton.AutoSize = true;
            this._bookManagementSystemButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._bookManagementSystemButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._bookManagementSystemButton.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookManagementSystemButton.Location = new System.Drawing.Point(10, 260);
            this._bookManagementSystemButton.Margin = new System.Windows.Forms.Padding(10);
            this._bookManagementSystemButton.Name = "_bookManagementSystemButton";
            this._bookManagementSystemButton.Size = new System.Drawing.Size(780, 105);
            this._bookManagementSystemButton.TabIndex = 3;
            this._bookManagementSystemButton.Text = "Book Management System";
            this._bookManagementSystemButton.UseVisualStyleBackColor = true;
            this._bookManagementSystemButton.Click += new System.EventHandler(this.BookManagementSystemButtonClick);
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 1;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.Controls.Add(this._bookBorrowingSystemButton, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._exitButton, 0, 3);
            this._tableLayoutPanel.Controls.Add(this._bookManagementSystemButton, 0, 2);
            this._tableLayoutPanel.Controls.Add(this._bookInventorySystemButton, 0, 1);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 4;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this._tableLayoutPanel.TabIndex = 4;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._tableLayoutPanel);
            this.Name = "MenuForm";
            this.Text = "Menu";
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _bookBorrowingSystemButton;
        private System.Windows.Forms.Button _bookInventorySystemButton;
        private System.Windows.Forms.Button _exitButton;
        private System.Windows.Forms.Button _bookManagementSystemButton;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
    }
}