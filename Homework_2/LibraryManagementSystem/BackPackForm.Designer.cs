
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
            this._backPackDataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this._backPackDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // _backPackDataGridView1
            // 
            this._backPackDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._backPackDataGridView1.Location = new System.Drawing.Point(12, 12);
            this._backPackDataGridView1.Name = "_backPackDataGridView1";
            this._backPackDataGridView1.RowTemplate.Height = 24;
            this._backPackDataGridView1.Size = new System.Drawing.Size(776, 426);
            this._backPackDataGridView1.TabIndex = 0;
            // 
            // BackPackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._backPackDataGridView1);
            this.Name = "BackPackForm";
            this.Text = "我的書包(還書)";
            ((System.ComponentModel.ISupportInitialize)(this._backPackDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _backPackDataGridView1;
    }
}