using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ObserverExample
{
    public partial class Form1 : Form
    {
        Model model;
        public Form1(Model model)
        {
            InitializeComponent();
            this.model = model;
            MouseMove += MouseMoveHandler;
            model.ModelChanged += UpdateView;
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            model.OnPaint(e.Graphics);
        }

        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            model.MouseMoveHandler(e.X, e.Y);
        }

        private void PointerMode_Click(object sender, EventArgs e)
        {
            model.SetPointerMode();
        }

        private void DrawingMode_Click(object sender, EventArgs e)
        {
            model.SetDrawingMode();
        }

        private void UpdateView()
        {
            Invalidate();
        }
    }
}
