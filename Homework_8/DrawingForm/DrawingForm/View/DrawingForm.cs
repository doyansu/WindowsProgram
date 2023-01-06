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
            const string APPLICATION_NAME = "DrawingForm";
            const string CLIENT_SECRET_FILE_NAME = @"./Model/GoogleDrive/clientSecret.json";

            InitializeComponent();
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            
            _model = new DrawingModel.Model();
            _model.FileService = new DrawingModel.GoogleDrive.GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
            _model._modelChanged += HandleModelChanged;

            _presentationModel = new PresentationModel.FormPresentationModel(_model);

            this.BindData();
        }

        // DataBinding
        private void BindData()
        {
            const string BIND_ATTRIBUTE_ENABLED = "Enabled";
            const string BIND_ATTRIBUTE_TEXT = "Text";
            this._rectangleButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._presentationModel, "IsRectangleButtonEnabled");
            this._triangleButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._presentationModel, "IsTriangleButtonEnabled");
            this._lineButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._presentationModel, "IsLineButtonEnabled");
            this._toolStripRedoButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._model.CommandBindingObject, "IsRedoEnabled");
            this._toolStripUndoButton.DataBindings.Add(BIND_ATTRIBUTE_ENABLED, this._model.CommandBindingObject, "IsUndoEnabled");
            this._selectedShapeLabel.DataBindings.Add(BIND_ATTRIBUTE_TEXT, this._model.ShapeBindingObject, "SelectedShapeInformation");
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

        // 點擊畫線按鈕
        private void HandleLineButtonClick(object sender, EventArgs e)
        {
            this._presentationModel.HandleLineButtonClick();
        }

        // 點擊儲存按鈕
        private void HandleSaveButtonClick(object sender, EventArgs e)
        {
            const string MESSAGE_BOX_TITLE = "Save Shapes";
            const string MESSAGE_BOX_CONTENT = "是否要儲存?";
            DialogResult result = MessageBox.Show(MESSAGE_BOX_CONTENT, MESSAGE_BOX_TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
                Task.Run(this._model.SaveShapes);
        }

        // 點擊下載按鈕
        private void HandleLoadButtonClick(object sender, EventArgs e)
        {
            const string MESSAGE_BOX_TITLE = "Load Shapes";
            const string MESSAGE_BOX_CONTENT = "是否要重新載入?";
            DialogResult result = MessageBox.Show(MESSAGE_BOX_CONTENT, MESSAGE_BOX_TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
                this._model.LoadShapes();
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
