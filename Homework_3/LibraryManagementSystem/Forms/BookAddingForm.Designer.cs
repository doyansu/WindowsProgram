
namespace LibraryManagementSystem
{
    partial class BookAddingForm
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
            this._addingBookListLabel = new System.Windows.Forms.Label();
            this._addingQuantityLabel = new System.Windows.Forms.Label();
            this._addingBookInformationRichTextBox = new System.Windows.Forms.RichTextBox();
            this._confirmButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._addingQuantityTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _addingBookListLabel
            // 
            this._addingBookListLabel.AutoSize = true;
            this._addingBookListLabel.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addingBookListLabel.Location = new System.Drawing.Point(264, 9);
            this._addingBookListLabel.Name = "_addingBookListLabel";
            this._addingBookListLabel.Size = new System.Drawing.Size(96, 35);
            this._addingBookListLabel.TabIndex = 0;
            this._addingBookListLabel.Text = "補貨單";
            // 
            // _addingQuantityLabel
            // 
            this._addingQuantityLabel.AutoSize = true;
            this._addingQuantityLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addingQuantityLabel.Location = new System.Drawing.Point(8, 350);
            this._addingQuantityLabel.Name = "_addingQuantityLabel";
            this._addingQuantityLabel.Size = new System.Drawing.Size(86, 21);
            this._addingQuantityLabel.TabIndex = 1;
            this._addingQuantityLabel.Text = "補貨數量 : ";
            // 
            // _addingBookInformationRichTextBox
            // 
            this._addingBookInformationRichTextBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addingBookInformationRichTextBox.Location = new System.Drawing.Point(12, 47);
            this._addingBookInformationRichTextBox.Name = "_addingBookInformationRichTextBox";
            this._addingBookInformationRichTextBox.Size = new System.Drawing.Size(600, 290);
            this._addingBookInformationRichTextBox.TabIndex = 2;
            this._addingBookInformationRichTextBox.Text = "";
            // 
            // _confirmButton
            // 
            this._confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(205)))), ((int)(((byte)(170)))));
            this._confirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._confirmButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._confirmButton.Location = new System.Drawing.Point(12, 385);
            this._confirmButton.Name = "_confirmButton";
            this._confirmButton.Size = new System.Drawing.Size(290, 45);
            this._confirmButton.TabIndex = 3;
            this._confirmButton.Text = "確認";
            this._confirmButton.UseVisualStyleBackColor = false;
            this._confirmButton.Click += new System.EventHandler(this.ClickConfirmButton);
            // 
            // _cancelButton
            // 
            this._cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(19)))), ((int)(((byte)(61)))));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._cancelButton.Location = new System.Drawing.Point(322, 385);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(290, 45);
            this._cancelButton.TabIndex = 4;
            this._cancelButton.Text = "取消";
            this._cancelButton.UseVisualStyleBackColor = false;
            this._cancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // _addingQuantityTextBox
            // 
            this._addingQuantityTextBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addingQuantityTextBox.Location = new System.Drawing.Point(100, 347);
            this._addingQuantityTextBox.Name = "_addingQuantityTextBox";
            this._addingQuantityTextBox.Size = new System.Drawing.Size(100, 29);
            this._addingQuantityTextBox.TabIndex = 5;
            this._addingQuantityTextBox.TextChanged += new System.EventHandler(this.ChangeAddingQuantityTextBoxText);
            // 
            // BookAddingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this._addingQuantityTextBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._confirmButton);
            this.Controls.Add(this._addingBookInformationRichTextBox);
            this.Controls.Add(this._addingQuantityLabel);
            this.Controls.Add(this._addingBookListLabel);
            this.Name = "BookAddingForm";
            this.Text = "ReplenishmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _addingBookListLabel;
        private System.Windows.Forms.Label _addingQuantityLabel;
        private System.Windows.Forms.RichTextBox _addingBookInformationRichTextBox;
        private System.Windows.Forms.Button _confirmButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.TextBox _addingQuantityTextBox;
    }
}