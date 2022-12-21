using DrawingModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();

        private double _firstPointX = 0;
        private double _firstPointY = 0;
        private bool _isPressed = false;
        private Shapes _shapes;
        private Shape _hint = null;
        private ShapeType _drawingShapeMode = ShapeType.Null;
        private CommandManager _commandManager = new CommandManager();

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
                    _shapes.SelectShape(pointX, pointY);
                    _isPressed = false;
                }
                else
                {
                    _shapes.CancelSelectAll();
                    if (this.DrawingShapeMode != ShapeType.Line || _shapes.CheckPointContains(_firstPointX, _firstPointY) != null)
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
                if (this.DrawingShapeMode != ShapeType.Null)
                {
                    _hint = _shapes.CreateShape(DrawingShapeMode);
                    _hint.StartX = _firstPointX;
                    _hint.StartY = _firstPointY;
                    _hint.EndX = pointX;
                    _hint.EndY = pointY;
                    if (this.DrawingShapeMode == ShapeType.Line)
                    {
                        ((Line)_hint).StartShape = _shapes.CheckPointContains(_firstPointX, _firstPointY);
                        ((Line)_hint).EndShape = new Rectangle(pointX, pointY, pointX, pointY);
                    }
                }
                NotifyModelChanged();
            }
        }

        // 完成圖形繪製
        public bool ReleasePointer(double pointX, double pointY)
        {
            bool release = false;
            if (_isPressed)
            {
                _isPressed = false;
                if (_hint != null && this.DrawingShapeMode == ShapeType.Line)
                    _hint = (((Line)_hint).EndShape = _shapes.CheckPointContains(pointX, pointY)) != null && (((Line)_hint).StartShape != ((Line)_hint).EndShape) ? _hint : null;
                if (_hint != null)
                {
                    _commandManager.Execute(new DrawCommand(this._shapes, _hint));
                    _hint = null;
                    release = true;
                }
                NotifyModelChanged();
            }
            return release;
        }

        // 清除所有圖形
        public void Clear()
        {
            _isPressed = false;
            _hint = null;
            _shapes.CancelSelectAll();
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
        }

        // 回上一個命令
        public void Undo()
        {
            _shapes.CancelSelectAll();
            _commandManager.Undo();
            NotifyModelChanged();
        }

        // 回下一個命令
        public void Redo()
        {
            _shapes.CancelSelectAll();
            _commandManager.Redo();
            NotifyModelChanged();
        }

        public CommandManager CommandBindingObject
        {
            get
            {
                return this._commandManager;
            }
        }

        public Shapes ShapeBindingObject
        {
            get
            {
                return this._shapes;
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

        // 通知 model 改變
        private void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
