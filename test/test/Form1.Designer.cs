
namespace test
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._testLabel = new System.Windows.Forms.Label();
            this._testButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _testLabel
            // 
            this._testLabel.AutoSize = true;
            this._testLabel.Location = new System.Drawing.Point(223, 98);
            this._testLabel.Name = "_testLabel";
            this._testLabel.Size = new System.Drawing.Size(33, 12);
            this._testLabel.TabIndex = 0;
            this._testLabel.Text = "label1";
            // 
            // _testButton
            // 
            this._testButton.Location = new System.Drawing.Point(382, 98);
            this._testButton.Name = "_testButton";
            this._testButton.Size = new System.Drawing.Size(75, 23);
            this._testButton.TabIndex = 1;
            this._testButton.Text = "button1";
            this._testButton.UseVisualStyleBackColor = true;
            this._testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._testButton);
            this.Controls.Add(this._testLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _testLabel;
        private System.Windows.Forms.Button _testButton;
    }
}

