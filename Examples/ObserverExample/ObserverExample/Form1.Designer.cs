namespace ObserverExample
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.PointerMode = new System.Windows.Forms.ToolStripButton();
            this.DrawingMode = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PointerMode,
            this.DrawingMode});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(292, 26);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // PointerMode
            // 
            this.PointerMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PointerMode.Image = ((System.Drawing.Image)(resources.GetObject("PointerMode.Image")));
            this.PointerMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PointerMode.Name = "PointerMode";
            this.PointerMode.Size = new System.Drawing.Size(112, 23);
            this.PointerMode.Text = "Pointer Mode";
            this.PointerMode.Click += new System.EventHandler(this.PointerMode_Click);
            // 
            // DrawingMode
            // 
            this.DrawingMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DrawingMode.Image = ((System.Drawing.Image)(resources.GetObject("DrawingMode.Image")));
            this.DrawingMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawingMode.Name = "DrawingMode";
            this.DrawingMode.Size = new System.Drawing.Size(123, 23);
            this.DrawingMode.Text = "Drawing Mode";
            this.DrawingMode.Click += new System.EventHandler(this.DrawingMode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 256);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton PointerMode;
        private System.Windows.Forms.ToolStripButton DrawingMode;
    }
}

