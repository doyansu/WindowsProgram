using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Shapes : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Shape> _shapes = new List<Shape>();

        private const string PROPERTY_NAME_SELECTED_SHAPE_INFORMATION = "SelectedShapeInformation";

        public Shapes()
        {
            
        }

        // Add
        public void Add(Shape shape)
        {
            if (shape != null)
                _shapes.Add(shape);
        }

        // RemoveAt
        public void Remove(Shape shape)
        {
            _shapes.Remove(shape);
        }

        // Contains
        public bool Contains(Shape shape)
        {
            return _shapes.Contains(shape);
        }

        // Clear
        public Shape[] Clear()
        {
            Shape[] shapes = _shapes.ToArray();
            this.CancelSelectAll();
            _shapes.Clear();
            return shapes;
        }

        // 繪製所有圖形
        public void Draw(IGraphics graphics)
        {
            List<Shape> drawList = new List<Shape>();
            drawList = _shapes.FindAll(shape => shape.ShapeType == ShapeType.Line);
            drawList.AddRange(_shapes.FindAll(shape => shape.ShapeType != ShapeType.Line));
            foreach (Shape shape in drawList)
                shape.Draw(graphics);
            foreach (Shape shape in _shapes)
                shape.DrawSelected(graphics);
        }

        // 選取一個圖形
        public void SelectShape(double pointX, double pointY)
        {
            Shape shape;
            this.CancelSelectAll();
            if ((shape = this.CheckPointContains(pointX, pointY)) != null)
                shape.IsSelected = true;
            NotifyPropertyChanged(PROPERTY_NAME_SELECTED_SHAPE_INFORMATION);
        }

        // 清除選取
        public void CancelSelectAll()
        {
            foreach (Shape shape in _shapes)
                shape.IsSelected = false;
            NotifyPropertyChanged(PROPERTY_NAME_SELECTED_SHAPE_INFORMATION);
        }

        // 檢查是否包含在圖形內，回傳最上面的一個
        public Shape CheckPointContains(double pointX, double pointY)
        {
            Shape shape = null;
            for (int i = this.Count - 1; i >= 0; i--)
                if (_shapes[i].IsContains(pointX, pointY))
                {
                    shape = _shapes[i];
                    break;
                }
            return shape;
        }

        // Get Shape
        public Shape GetBy(int index)
        {
            const string EXCEPTION_MESSAGE = "index out of range";
            if (index < 0 || index >= this.Count)
                throw new Exception(EXCEPTION_MESSAGE);
            return _shapes[index];
        }

        public int Count
        {
            get
            {
                return this._shapes.Count;
            }
        }

        public string SelectedShapeInformation
        {
            get
            {
                const string NULL_VALUE = "";
                const string SELECTED = "Selected：";
                Shape selectedShape = _shapes.Find(shape => shape.IsSelected == true);
                return selectedShape != null ? SELECTED + selectedShape.ShapeInformation() : NULL_VALUE;
            }
        }

        // 通知 databing 改變
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
