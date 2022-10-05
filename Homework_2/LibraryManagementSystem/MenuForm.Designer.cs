
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
            this.SuspendLayout();
            // 
            // _bookBorrowingSystemButton
            // 
            this._bookBorrowingSystemButton.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookBorrowingSystemButton.Location = new System.Drawing.Point(12, 12);
            this._bookBorrowingSystemButton.Name = "_bookBorrowingSystemButton";
            this._bookBorrowingSystemButton.Size = new System.Drawing.Size(776, 180);
            this._bookBorrowingSystemButton.TabIndex = 0;
            this._bookBorrowingSystemButton.Text = "Book Borrowing System";
            this._bookBorrowingSystemButton.UseVisualStyleBackColor = true;
            this._bookBorrowingSystemButton.Click += new System.EventHandler(this.BookBorrowingSystemButtonClick);
            // 
            // _bookInventorySystemButton
            // 
            this._bookInventorySystemButton.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._bookInventorySystemButton.Location = new System.Drawing.Point(12, 198);
            this._bookInventorySystemButton.Name = "_bookInventorySystemButton";
            this._bookInventorySystemButton.Size = new System.Drawing.Size(776, 180);
            this._bookInventorySystemButton.TabIndex = 1;
            this._bookInventorySystemButton.Text = "Book Inventory System";
            this._bookInventorySystemButton.UseVisualStyleBackColor = true;
            this._bookInventorySystemButton.Click += new System.EventHandler(this.BookInventorySystemButtonClick);
            // 
            // _exitButton
            // 
            this._exitButton.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._exitButton.Location = new System.Drawing.Point(688, 384);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(100, 54);
            this._exitButton.TabIndex = 2;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._exitButton);
            this.Controls.Add(this._bookInventorySystemButton);
            this.Controls.Add(this._bookBorrowingSystemButton);
            this.Name = "MenuForm";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _bookBorrowingSystemButton;
        private System.Windows.Forms.Button _bookInventorySystemButton;
        private System.Windows.Forms.Button _exitButton;
    }
}