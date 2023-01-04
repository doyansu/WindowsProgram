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

        public event CommandReleasedEventHandler _commandReleased;
        public delegate void CommandReleasedEventHandler();

        private bool _isPressed = false;
        private Shape _hint = null;
        private Shapes _shapes = new Shapes();
        private CommandManager _commandManager = new CommandManager();
        private IDrawingState _currentState;

        public Model()
        {
            _currentState = new SelectionState(this);
        }

        // 開始繪製
        public void PressPointer(double pointX, double pointY)
        {
            if (pointX > 0 && pointY > 0)
            {
                _isPressed = true;
                _currentState.PressPointer(pointX, pointY);
                NotifyModelChanged();
            }
        }

        // 繪製移動
        public void MovePointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _currentState.MovePointer(pointX, pointY);
                NotifyModelChanged();
            }
        }

        // 完成圖形繪製
        public void ReleasePointer(double pointX, double pointY)
        {
            if (_isPressed)
            {
                _isPressed = false;
                _currentState.ReleasePointer(pointX, pointY);
                NotifyModelChanged();
            }
        }

        // 清除所有圖形
        public void Clear()
        {
            _isPressed = false;
            Hint = null;
            ExecuteCommand(new ClearCommand(this));
            NotifyModelChanged();
        }

        // 繪製所有圖形
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.Draw(graphics);
            if (Hint != null)
                Hint.Draw(graphics);
        }

        // 執行命令
        public void ExecuteCommand(ICommand command)
        {
            _commandManager.Execute(command);
            NotifyCommandReleased();
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

        // 檢查是否包含在圖形內，回傳最上面的一個
        public Shape CheckShapeContains(double pointX, double pointY)
        {
            Shape result = _shapes.CheckPointContains(pointX, pointY);
            return result;
        }

        // SelectShape
        public void SelectShape(double pointX, double pointY)
        {
            _shapes.SelectShape(pointX, pointY);
        }

        // DrawHint
        public void DrawHint()
        {
            if (Hint != null)
            {
                this.ExecuteCommand(new DrawCommand(this, this.Hint));
                Hint = null;
            }
        }
        
        // 變更為選取模式
        public void SetSelectionMode()
        {
            this.CurrentState = new SelectionState(this);
        }

        // 變更為畫圖模式
        public void SetDrawShapeMode(ShapeType shapeType)
        {
            DrawShapeState drawShapeState = new DrawShapeState(this);
            drawShapeState.DrawShapeType = shapeType;
            this.CurrentState = drawShapeState;
        }

        // 變更為畫線模式
        public void SetDrawLineMode()
        {
            this.CurrentState = new DrawLineState(this);
        }

        public void HandleSaveButtonClick()
        {
            throw new NotImplementedException();
        }

        public void HandleLoadButtonClick()
        {
            throw new NotImplementedException();
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

        public IDrawingState CurrentState 
        {
            get
            {
                return _currentState;
            }
            set
            {
                _currentState = value;
            }
        }

        public Shape Hint
        {
            get
            {
                return _hint;
            }
            set
            {
                _hint = value;
            }
        }

        // 通知 model 改變
        private void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        // 通知 CommandReleased
        private void NotifyCommandReleased()
        {
            if (_commandReleased != null)
                _commandReleased();
        }
        
    }
}
