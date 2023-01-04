
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
            this._triangleButton = new System.Windows.Forms.Button();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._lineButton = new System.Windows.Forms.Button();
            this._rectangleButton = new System.Windows.Forms.Button();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._canvas = new DrawingFormSpace.DoubleBufferedPanel();
            this._selectedShapeLabel = new System.Windows.Forms.Label();
            this._toolStripUndoButton = new DrawingFormSpace.View.Components.ToolStripBindingButton();
            this._toolStripRedoButton = new DrawingFormSpace.View.Components.ToolStripBindingButton();
            this._saveButton = new System.Windows.Forms.Button();
            this._loadButton = new System.Windows.Forms.Button();
            this._tableLayoutPanel.SuspendLayout();
            this._toolStrip.SuspendLayout();
            this._canvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // _clearButton
            // 
            this._clearButton.AutoSize = true;
            this._clearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._clearButton.Location = new System.Drawing.Point(640, 4);
            this._clearButton.Margin = new System.Windows.Forms.Padding(13, 4, 13, 4);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(183, 54);
            this._clearButton.TabIndex = 1;
            this._clearButton.Text = "Clear";
            this._clearButton.UseVisualStyleBackColor = true;
            this._clearButton.Click += new System.EventHandler(this.HandleClearButtonClick);
            // 
            // _triangleButton
            // 
            this._triangleButton.AutoSize = true;
            this._triangleButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._triangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._triangleButton.Location = new System.Drawing.Point(431, 4);
            this._triangleButton.Margin = new System.Windows.Forms.Padding(13, 4, 13, 4);
            this._triangleButton.Name = "_triangleButton";
            this._triangleButton.Size = new System.Drawing.Size(183, 54);
            this._triangleButton.TabIndex = 3;
            this._triangleButton.Text = "Triangle";
            this._triangleButton.UseVisualStyleBackColor = true;
            this._triangleButton.Click += new System.EventHandler(this.HandleTriangleButtonClick);
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 6;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._tableLayoutPanel.Controls.Add(this._lineButton, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._rectangleButton, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._triangleButton, 2, 0);
            this._tableLayoutPanel.Controls.Add(this._clearButton, 3, 0);
            this._tableLayoutPanel.Controls.Add(this._saveButton, 4, 0);
            this._tableLayoutPanel.Controls.Add(this._loadButton, 5, 0);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 31);
            this._tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 1;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(1259, 62);
            this._tableLayoutPanel.TabIndex = 4;
            // 
            // _lineButton
            // 
            this._lineButton.AutoSize = true;
            this._lineButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._lineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lineButton.Location = new System.Drawing.Point(222, 4);
            this._lineButton.Margin = new System.Windows.Forms.Padding(13, 4, 13, 4);
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(183, 54);
            this._lineButton.TabIndex = 4;
            this._lineButton.Text = "Line";
            this._lineButton.UseVisualStyleBackColor = true;
            this._lineButton.Click += new System.EventHandler(this.HandleLineButtonClick);
            // 
            // _rectangleButton
            // 
            this._rectangleButton.AutoSize = true;
            this._rectangleButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._rectangleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._rectangleButton.Location = new System.Drawing.Point(13, 4);
            this._rectangleButton.Margin = new System.Windows.Forms.Padding(13, 4, 13, 4);
            this._rectangleButton.Name = "_rectangleButton";
            this._rectangleButton.Size = new System.Drawing.Size(183, 54);
            this._rectangleButton.TabIndex = 5;
            this._rectangleButton.Text = "Rectangle";
            this._rectangleButton.UseVisualStyleBackColor = true;
            this._rectangleButton.Click += new System.EventHandler(this.HandleRectangleButtonClick);
            // 
            // _toolStrip
            // 
            this._toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripUndoButton,
            this._toolStripRedoButton});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(1259, 31);
            this._toolStrip.TabIndex = 5;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _canvas
            // 
            this._canvas.BackColor = System.Drawing.Color.LightYellow;
            this._canvas.Controls.Add(this._selectedShapeLabel);
            this._canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._canvas.Location = new System.Drawing.Point(0, 93);
            this._canvas.Margin = new System.Windows.Forms.Padding(4);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(1259, 758);
            this._canvas.TabIndex = 6;
            // 
            // _selectedShapeLabel
            // 
            this._selectedShapeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._selectedShapeLabel.AutoSize = true;
            this._selectedShapeLabel.Location = new System.Drawing.Point(952, 731);
            this._selectedShapeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._selectedShapeLabel.Name = "_selectedShapeLabel";
            this._selectedShapeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._selectedShapeLabel.Size = new System.Drawing.Size(0, 15);
            this._selectedShapeLabel.TabIndex = 0;
            // 
            // _toolStripUndoButton
            // 
            this._toolStripUndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripUndoButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripUndoButton.Image")));
            this._toolStripUndoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripUndoButton.Name = "_toolStripUndoButton";
            this._toolStripUndoButton.Size = new System.Drawing.Size(52, 28);
            this._toolStripUndoButton.Text = "Undo";
            this._toolStripUndoButton.Click += new System.EventHandler(this.HandleToolStripUndoButtonClick);
            // 
            // _toolStripRedoButton
            // 
            this._toolStripRedoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripRedoButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripRedoButton.Image")));
            this._toolStripRedoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripRedoButton.Name = "_toolStripRedoButton";
            this._toolStripRedoButton.Size = new System.Drawing.Size(50, 28);
            this._toolStripRedoButton.Text = "Redo";
            this._toolStripRedoButton.Click += new System.EventHandler(this.HandleToolStripRedoButtonClick);
            // 
            // _saveButton
            // 
            this._saveButton.AutoSize = true;
            this._saveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._saveButton.Location = new System.Drawing.Point(849, 4);
            this._saveButton.Margin = new System.Windows.Forms.Padding(13, 4, 13, 4);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(183, 54);
            this._saveButton.TabIndex = 6;
            this._saveButton.Text = "Save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this.HandleSaveButtonClick);
            // 
            // _loadButton
            // 
            this._loadButton.AutoSize = true;
            this._loadButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._loadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._loadButton.Location = new System.Drawing.Point(1058, 4);
            this._loadButton.Margin = new System.Windows.Forms.Padding(13, 4, 13, 4);
            this._loadButton.Name = "_loadButton";
            this._loadButton.Size = new System.Drawing.Size(188, 54);
            this._loadButton.TabIndex = 7;
            this._loadButton.Text = "Load";
            this._loadButton.UseVisualStyleBackColor = true;
            this._loadButton.Click += new System.EventHandler(this.HandleLoadButtonClick);
            // 
            // DrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 851);
            this.Controls.Add(this._canvas);
            this.Controls.Add(this._tableLayoutPanel);
            this.Controls.Add(this._toolStrip);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DrawingForm";
            this.Text = "DrawingForm";
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanel.PerformLayout();
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this._canvas.ResumeLayout(false);
            this._canvas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Button _triangleButton;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private View.Components.ToolStripBindingButton _toolStripUndoButton;
        private View.Components.ToolStripBindingButton _toolStripRedoButton;
        private DoubleBufferedPanel _canvas;
        private System.Windows.Forms.Button _lineButton;
        private System.Windows.Forms.Button _rectangleButton;
        private System.Windows.Forms.Label _selectedShapeLabel;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button _loadButton;
    }
}

