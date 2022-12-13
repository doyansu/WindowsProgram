
namespace DrawingFormSpace
{
    partial class DrawingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawingForm));
            this._clearButton = new System.Windows.Forms.Button();
            this._rectangleButton = new System.Windows.Forms.Button();
            this._triangleButton = new System.Windows.Forms.Button();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._toolStripUndoButton = new DrawingFormSpace.View.Components.ToolStripBindingButton();
            this._toolStripRedoButton = new DrawingFormSpace.View.Components.ToolStripBindingButton();
            this._canvas = new DrawingFormSpace.DoubleBufferedPanel();
            this._tableLayoutPanel.SuspendLayout();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _clearButton
            // 
            this._clearButton.AutoSize = true;
            this._clearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._clearButton.Location = new System.Drawing.Point(542, 3);
            this._clearButton.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(248, 44);
            this._clearButton.TabIndex = 1;
            this._clearButton.Text = "Clear";
            this._clearButton.UseVisualStyleBackColor = true;
            this._clearButton.Click += new System.EventHandler(this.HandleClearButtonClick);
            // 
            // _rectangleButton
            // 
            this._rectangleButton.AutoSize = true;
            this._rectangleButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._rectangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rectangleButton.Location = new System.Drawing.Point(10, 3);
            this._rectangleButton.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this._rectangleButton.Name = "_rectangleButton";
            this._rectangleButton.Size = new System.Drawing.Size(246, 44);
            this._rectangleButton.TabIndex = 2;
            this._rectangleButton.Text = "Rectangle";
            this._rectangleButton.UseVisualStyleBackColor = true;
            this._rectangleButton.Click += new System.EventHandler(this.HandleRectangleButtonClick);
            // 
            // _triangleButton
            // 
            this._triangleButton.AutoSize = true;
            this._triangleButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._triangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._triangleButton.Location = new System.Drawing.Point(276, 3);
            this._triangleButton.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this._triangleButton.Name = "_triangleButton";
            this._triangleButton.Size = new System.Drawing.Size(246, 44);
            this._triangleButton.TabIndex = 3;
            this._triangleButton.Text = "Triangle";
            this._triangleButton.UseVisualStyleBackColor = true;
            this._triangleButton.Click += new System.EventHandler(this.HandleTriangleButtonClick);
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 3;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this._tableLayoutPanel.Controls.Add(this._rectangleButton, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._clearButton, 2, 0);
            this._tableLayoutPanel.Controls.Add(this._triangleButton, 1, 0);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 1;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(800, 50);
            this._tableLayoutPanel.TabIndex = 4;
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripUndoButton,
            this._toolStripRedoButton});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(800, 25);
            this._toolStrip.TabIndex = 5;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _toolStripUndoButton
            // 
            this._toolStripUndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripUndoButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripUndoButton.Image")));
            this._toolStripUndoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripUndoButton.Name = "_toolStripUndoButton";
            this._toolStripUndoButton.Size = new System.Drawing.Size(43, 22);
            this._toolStripUndoButton.Text = "Undo";
            this._toolStripUndoButton.Click += new System.EventHandler(this.HandleToolStripUndoButtonClick);
            // 
            // _toolStripRedoButton
            // 
            this._toolStripRedoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripRedoButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripRedoButton.Image")));
            this._toolStripRedoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripRedoButton.Name = "_toolStripRedoButton";
            this._toolStripRedoButton.Size = new System.Drawing.Size(42, 22);
            this._toolStripRedoButton.Text = "Redo";
            this._toolStripRedoButton.Click += new System.EventHandler(this.HandleToolStripRedoButtonClick);
            // 
            // _canvas
            // 
            this._canvas.BackColor = System.Drawing.Color.LightYellow;
            this._canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._canvas.Location = new System.Drawing.Point(0, 75);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(800, 375);
            this._canvas.TabIndex = 6;
            // 
            // DrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._canvas);
            this.Controls.Add(this._tableLayoutPanel);
            this.Controls.Add(this._toolStrip);
            this.Name = "DrawingForm";
            this.Text = "DrawingForm";
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanel.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Button _rectangleButton;
        private System.Windows.Forms.Button _triangleButton;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private View.Components.ToolStripBindingButton _toolStripUndoButton;
        private View.Components.ToolStripBindingButton _toolStripRedoButton;
        private DoubleBufferedPanel _canvas;
    }
}

