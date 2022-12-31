using DrawingModel.Commands;
using DrawingModel.States;
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
        private ShapeType _drawingShapeMode = ShapeType.Null;
        private CommandManager _commandManager = new CommandManager();

        private IState _currentState;

        public Model()
        {
            _shapes = new Shapes(new ShapeFactory());
            _currentState = new SelectionState();
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
                    this._shapes.Hint = _shapes.CreateShape(DrawingShapeMode);
                    this._shapes.Hint.StartX = _firstPointX;
                    this._shapes.Hint.StartY = _firstPointY;
                    this._shapes.Hint.EndX = pointX;
                    this._shapes.Hint.EndY = pointY;
                    if (this.DrawingShapeMode == ShapeType.Line)
                    {
                        ((Line)this._shapes.Hint).StartShape = _shapes.CheckPointContains(_firstPointX, _firstPointY);
                        ((Line)this._shapes.Hint).EndShape = new Rectangle(pointX, pointY, pointX, pointY);
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
                if (this._shapes.Hint != null && this.DrawingShapeMode == ShapeType.Line)
                    this._shapes.Hint = (((Line)this._shapes.Hint).EndShape = _shapes.CheckPointContains(pointX, pointY)) != null && (((Line)this._shapes.Hint).StartShape != ((Line)this._shapes.Hint).EndShape) ? this._shapes.Hint : null;
                if (this._shapes.Hint != null)
                {
                    this._shapes.Hint.EndX = pointX;
                    this._shapes.Hint.EndY = pointY;
                    _commandManager.Execute(new DrawCommand(this, this._shapes.Hint));
                    this._shapes.Hint = null;
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
            if (this._shapes.Count > 0)
                _commandManager.Execute(new ClearCommand(this));
            NotifyModelChanged();
        }

        // 繪製所有圖形
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.Draw(graphics);
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

        // 新增圖形
        public void AddShape(Shape shape)
        {
            this._shapes.Add(shape);
        }

        // 移除圖形
        public void RemoveShape(Shape shape)
        {
            this._shapes.Remove(shape);
        }

        // 移除所有圖形並回傳
        public Shape[] RemoveAllShape()
        {
            Shape[] result = this._shapes.Clear();
            return result;
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
