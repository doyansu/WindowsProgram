using DrawingModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Model : INotifyPropertyChanged
    {
        public event ModelChangedEventHandler _modelChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void ModelChangedEventHandler();

        private double _firstPointX = 0;
        private double _firstPointY = 0;
        private bool _isPressed = false;
        private Shapes _shapes;
        private Shape _hint = null;
        private Shape _selectedShape = null;
        private ShapeType _drawingShapeMode = ShapeType.Null;
        private CommandManager _commandManager = new CommandManager();

        private const string PROPERTY_NAME_SELECTED_SHAPE_INFORMATION = "SelectedShapeInformation";

        public Model()
        {
            _shapes = new Shapes(new ShapeFactory());
        }

        // 開始繪製
        public void PressPointer(double pointX, double pointY)
        {
            if (pointX > 0 && pointY > 0)
            {
                _firstPointX = pointX;
                _firstPointY = pointY;
                
                if (this.DrawingShapeMode == ShapeType.Null)
                {
                    SelectedShape = _shapes.CheckPointContains(_firstPointX, _firstPointY);
                    _isPressed = false;
                }
                else
                {
                    SelectedShape = null;
                    _isPressed = true;
                }
                NotifyModelChanged();
            }
        }

        // 繪製移動
        public void MovePointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                if ((_hint = _shapes.CreateShape(DrawingShapeMode)) != null)
                {
                    _hint.StartX = _firstPointX;
                    _hint.StartY = _firstPointY;
                    _hint.EndX = pointX;
                    _hint.EndY = pointY;
                }
                NotifyModelChanged();
            }
        }

        // 完成圖形繪製
        public void ReleasePointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _isPressed = false;
                if (_hint != null)
                {
                    _commandManager.Execute(new DrawCommand(this, _hint));
                    _hint = null;
                }
            }
        }

        // 清除所有圖形
        public void Clear()
        {
            _isPressed = false;
            _hint = null;
            SelectedShape = null;
            if (this._shapes.Count > 0)
                _commandManager.Execute(new ClearCommand(this._shapes));
            NotifyModelChanged();
        }

        // 繪製所有圖形
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.Draw(graphics);
            if (_isPressed && _hint != null) 
                _hint.Draw(graphics);
            if (SelectedShape != null && _shapes.Contains(SelectedShape))
                SelectedShape.DrawSelected(graphics);
            else
                SelectedShape = null;
        }

        // 回上一個命令
        public void Undo()
        {
            _commandManager.Undo();
            NotifyModelChanged();
        }

        // 回下一個命令
        public void Redo()
        {
            _commandManager.Redo();
            NotifyModelChanged();
        }

        // 加入繪製圖形
        public void DrawShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        // 移除最後一個圖形
        public void DeleteShape()
        {
            _shapes.RemoveBy(-1);
        }

        public object CommandBindingObject
        {
            get
            {
                return this._commandManager;
            }
        }

        public ShapeType DrawingShapeMode 
        {
            get
            {
                return _drawingShapeMode;
            }
            set
            {
                _drawingShapeMode = value;
            }
        }

        private Shape SelectedShape 
        {
            get
            {
                return _selectedShape;
            }
            set
            {
                if (_selectedShape != value)
                {
                    _selectedShape = value;
                    NotifyPropertyChanged(PROPERTY_NAME_SELECTED_SHAPE_INFORMATION);
                }
            }
        }

        public string SelectedShapeInformation
        {
            get
            {
                const string NULL_VALUE = "";
                const string SELECTED = "Selected：";
                return _selectedShape != null ? SELECTED + _selectedShape.ShapeInformation() : NULL_VALUE;
            }
        }

        // 通知 model 改變
        private void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        // 通知 databing 改變
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
