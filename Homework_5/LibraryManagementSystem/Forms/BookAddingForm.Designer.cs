
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
            this._fullTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._buttonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._addingQuantityTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._fullTableLayoutPanel.SuspendLayout();
            this._buttonTableLayoutPanel.SuspendLayout();
            this._addingQuantityTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _addingBookListLabel
            // 
            this._addingBookListLabel.AutoSize = true;
            this._addingBookListLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addingBookListLabel.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addingBookListLabel.Location = new System.Drawing.Point(3, 0);
            this._addingBookListLabel.Name = "_addingBookListLabel";
            this._addingBookListLabel.Size = new System.Drawing.Size(618, 35);
            this._addingBookListLabel.TabIndex = 0;
            this._addingBookListLabel.Text = "補貨單";
            this._addingBookListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _addingQuantityLabel
            // 
            this._addingQuantityLabel.AutoSize = true;
            this._addingQuantityLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addingQuantityLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addingQuantityLabel.Location = new System.Drawing.Point(3, 0);
            this._addingQuantityLabel.Name = "_addingQuantityLabel";
            this._addingQuantityLabel.Size = new System.Drawing.Size(94, 46);
            this._addingQuantityLabel.TabIndex = 1;
            this._addingQuantityLabel.Text = "補貨數量 ：";
            this._addingQuantityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _addingBookInformationRichTextBox
            // 
            this._addingBookInformationRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addingBookInformationRichTextBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addingBookInformationRichTextBox.Location = new System.Drawing.Point(3, 38);
            this._addingBookInformationRichTextBox.Name = "_addingBookInformationRichTextBox";
            this._addingBookInformationRichTextBox.Size = new System.Drawing.Size(618, 267);
            this._addingBookInformationRichTextBox.TabIndex = 2;
            this._addingBookInformationRichTextBox.Text = "";
            // 
            // _confirmButton
            // 
            this._confirmButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(205)))), ((int)(((byte)(170)))));
            this._confirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._confirmButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._confirmButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._confirmButton.Location = new System.Drawing.Point(10, 10);
            this._confirmButton.Margin = new System.Windows.Forms.Padding(10);
            this._confirmButton.Name = "_confirmButton";
            this._confirmButton.Size = new System.Drawing.Size(289, 55);
            this._confirmButton.TabIndex = 3;
            this._confirmButton.Text = "確認";
            this._confirmButton.UseVisualStyleBackColor = false;
            this._confirmButton.Click += new System.EventHandler(this.ClickConfirmButton);
            // 
            // _cancelButton
            // 
            this._cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(19)))), ((int)(((byte)(61)))));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._cancelButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._cancelButton.Location = new System.Drawing.Point(319, 10);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(10);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(289, 55);
            this._cancelButton.TabIndex = 4;
            this._cancelButton.Text = "取消";
            this._cancelButton.UseVisualStyleBackColor = false;
            this._cancelButton.Click += new System.EventHandler(this.ClickCancelButton);
            // 
            // _addingQuantityTextBox
            // 
            this._addingQuantityTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._addingQuantityTextBox.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._addingQuantityTextBox.Location = new System.Drawing.Point(103, 8);
            this._addingQuantityTextBox.MaxLength = 9;
            this._addingQuantityTextBox.Name = "_addingQuantityTextBox";
            this._addingQuantityTextBox.Size = new System.Drawing.Size(100, 29);
            this._addingQuantityTextBox.TabIndex = 5;
            this._addingQuantityTextBox.TextChanged += new System.EventHandler(this.ChangeAddingQuantityTextBoxText);
            // 
            // _fullTableLayoutPanel
            // 
            this._fullTableLayoutPanel.AutoSize = true;
            this._fullTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._fullTableLayoutPanel.ColumnCount = 1;
            this._fullTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._fullTableLayoutPanel.Controls.Add(this._buttonTableLayoutPanel, 0, 3);
            this._fullTableLayoutPanel.Controls.Add(this._addingQuantityTableLayoutPanel, 0, 2);
            this._fullTableLayoutPanel.Controls.Add(this._addingBookListLabel, 0, 0);
            this._fullTableLayoutPanel.Controls.Add(this._addingBookInformationRichTextBox, 0, 1);
            this._fullTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._fullTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._fullTableLayoutPanel.Name = "_fullTableLayoutPanel";
            this._fullTableLayoutPanel.RowCount = 4;
            this._fullTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fullTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._fullTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fullTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._fullTableLayoutPanel.Size = new System.Drawing.Size(624, 441);
            this._fullTableLayoutPanel.TabIndex = 6;
            // 
            // _buttonTableLayoutPanel
            // 
            this._buttonTableLayoutPanel.ColumnCount = 2;
            this._buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._buttonTableLayoutPanel.Controls.Add(this._cancelButton, 1, 0);
            this._buttonTableLayoutPanel.Controls.Add(this._confirmButton, 0, 0);
            this._buttonTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttonTableLayoutPanel.Location = new System.Drawing.Point(3, 363);
            this._buttonTableLayoutPanel.Name = "_buttonTableLayoutPanel";
            this._buttonTableLayoutPanel.RowCount = 1;
            this._buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._buttonTableLayoutPanel.Size = new System.Drawing.Size(618, 75);
            this._buttonTableLayoutPanel.TabIndex = 7;
            // 
            // _addingQuantityTableLayoutPanel
            // 
            this._addingQuantityTableLayoutPanel.ColumnCount = 2;
            this._addingQuantityTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._addingQuantityTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._addingQuantityTableLayoutPanel.Controls.Add(this._addingQuantityLabel, 0, 0);
            this._addingQuantityTableLayoutPanel.Controls.Add(this._addingQuantityTextBox, 1, 0);
            this._addingQuantityTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._addingQuantityTableLayoutPanel.Location = new System.Drawing.Point(3, 311);
            this._addingQuantityTableLayoutPanel.Name = "_addingQuantityTableLayoutPanel";
            this._addingQuantityTableLayoutPanel.RowCount = 1;
            this._addingQuantityTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._addingQuantityTableLayoutPanel.Size = new System.Drawing.Size(618, 46);
            this._addingQuantityTableLayoutPanel.TabIndex = 7;
            // 
            // BookAddingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this._fullTableLayoutPanel);
            this.Name = "BookAddingForm";
            this.Text = "ReplenishmentForm";
            this._fullTableLayoutPanel.ResumeLayout(false);
            this._fullTableLayoutPanel.PerformLayout();
            this._buttonTableLayoutPanel.ResumeLayout(false);
            this._addingQuantityTableLayoutPanel.ResumeLayout(false);
            this._addingQuantityTableLayoutPanel.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel _fullTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel _buttonTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel _addingQuantityTableLayoutPanel;
    }
}