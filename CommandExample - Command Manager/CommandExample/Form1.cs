using System;
using System.Drawing;
using System.Windows.Forms;

namespace CommandExample
{
    public class Form1 : Form
    {
        Model model;
        ToolStripButton undo;
        ToolStripButton redo;
        public Form1(Model model)
        {
            this.model = model;
            BackColor = Color.White;
            //
            // Event Handlers
            //
            MouseDown += MouseDownHandler;
            MouseMove += MouseMoveHandler;
            MouseUp += MouseUpHandler;
            //
            // ToolStrip for Redo and Undo buttons
            //
            ToolStrip ts = new ToolStrip();
            //Controls.Add(ts);
            ts.Parent = this;
            undo = new ToolStripButton("Undo", null, UndoHandler);
            undo.Enabled = false;
            ts.Items.Add(undo);
            redo = new ToolStripButton("Redo", null, RedoHandler);
            redo.Enabled = false;
            ts.Items.Add(redo);
            //
            // Use Double buffer
            //
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            model.OnPaint(e.Graphics);
        }
        void MouseDownHandler(object sender, MouseEventArgs e)
        {
            model.MouseDown(e.Location);
            RefreshUI();
        }
        void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            model.MouseMove(e.Location);
            RefreshUI();
        }
        void MouseUpHandler(object sender, MouseEventArgs e)
        {
            model.MouseUp(e.Location);
            RefreshUI();
        }
        void UndoHandler(Object sender, EventArgs e)
        {
            model.Undo();
            RefreshUI();
        }
        void RedoHandler(Object sender, EventArgs e)
        {
            model.Redo();
            RefreshUI();
        }
        void RefreshUI()    // 更新redo與undo是否為enabled
        {
            redo.Enabled = model.IsRedoEnabled;
            undo.Enabled = model.IsUndoEnabled;
            Invalidate();
        }
    }
}
