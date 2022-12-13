using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingFormSpace
{
    public partial class DrawingForm : Form
    {
        DrawingModel.Model _model;
        PresentationModel.FormPresentationModel _presentationModel;

        public DrawingForm()
        {
            InitializeComponent();
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.FormPresentationModel(_model);
            _model._modelChanged += HandleModelChanged;

            this.BindData();
        }

        // DataBinding
        private void BindData()
        {
            const string BIND_ATTRIBUTE_ENABLED = "Enabled";
            this._rectangleButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._presentationModel, "IsRectangleButtonEnabled");
            this._triangleButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._presentationModel, "IsTriangleButtonEnabled");
            this._toolStripRedoButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._model.CommandBindingObject, "IsRedoEnabled");
            this._toolStripUndoButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._model.CommandBindingObject, "IsUndoEnabled");
        }

        // 畫布滑鼠點下
        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _model.PressPointer(e.X, e.Y);
        }

        // 畫布滑鼠放開
        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleCanvasReleased(e.X, e.Y);
        }

        // 畫布滑鼠移動
        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _model.MovePointer(e.X, e.Y);
        }

        // 畫布繪製
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _model.Draw(new PresentationModel.FormGraphicsAdaptor(e.Graphics));
        }

        // HandleModelChanged
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

        // 點擊矩形按鈕
        private void HandleRectangleButtonClick(object sender, EventArgs e)
        {
            this._presentationModel.HandleRectangleButtonClick();
        }

        // 點擊三角形按鈕
        private void HandleTriangleButtonClick(object sender, EventArgs e)
        {
            this._presentationModel.HandleTriangleButtonClick();
        }

        // 點擊清除畫布按鈕
        private void HandleClearButtonClick(object sender, EventArgs e)
        {
            this._presentationModel.HandleClearButtonClick();
        }

        // Undo 按鈕點擊
        private void HandleToolStripUndoButtonClick(object sender, EventArgs e)
        {
            this._model.Undo();
        }

        // Redo 按鈕點擊
        private void HandleToolStripRedoButtonClick(object sender, EventArgs e)
        {
            this._model.Redo();
        }
    }
}
