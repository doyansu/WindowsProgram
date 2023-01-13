using DrawingModel.GoogleDrive;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DrawingModel
{
    public class Shapes : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Shape> _shapes = new List<Shape>();

        private IFileBaseService _saveFileService = null;

        private const string PROPERTY_NAME_SELECTED_SHAPE_INFORMATION = "SelectedShapeInformation";
        private const string TEMP_FILE_NAME = "DrawingShapes.txt";
        private const string SHAPE_TYPE = "ShapeType";
        private const string SOFT_NEW_LINE = "\r";
        private const string NEW_LINE_STRING = "\n";
        private const string STRING_EMPTY = "";
        private const string SPACE = " ";
        private const string START_SHAPE = "StartShape";
        private const string END_SHAPE = "EndShape";
        private const char NEW_LINE = '\n';
        private const char SPLIT_ELEMENT = '*';

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

        // SaveShapes
        public void SaveShapes()
        {
            const string CONTENT_TYPE = "text/xml";
            string content = "";
            foreach (Shape shape in this._shapes)
                content += shape.GetObjectString() + NEW_LINE;
            if (content != "")
                content = content.Substring(0, content.Length - 1);
            this.SaveFileService.UploadFile(TEMP_FILE_NAME, content, CONTENT_TYPE);
        }

        // LoadShapes
        public void LoadShapes()
        {
            string fileDate = this.SaveFileService.ReadFile(TEMP_FILE_NAME);
            List<string> objects = fileDate.Split(NEW_LINE).ToList();
            if (objects.Contains(STRING_EMPTY))
                return;
            foreach (string shapeObject in objects)
                this.Add(GetObject((ShapeType)(int.Parse(JsonConvert.DeserializeObject<Dictionary<string, object>>(shapeObject)[SHAPE_TYPE].ToString())), shapeObject));
            for (int i = 0; i < this._shapes.Count; i++)
                if (this._shapes[i].ShapeType == ShapeType.Line)
                {
                    var shapeDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(objects[i]);
                    Line line = (Line)this._shapes[i];
                    line.StartShape = this._shapes[objects.IndexOf(ClearString(shapeDict[START_SHAPE].ToString()))];
                    line.EndShape = this._shapes[objects.IndexOf(ClearString(shapeDict[END_SHAPE].ToString()))];
                }
        }

        // TestReadFile
        public bool IsFileExist()
        {
            return this.SaveFileService.IsContain(TEMP_FILE_NAME);
        }

        // GetDeserializeObject
        private Shape GetObject(ShapeType shapeType, string objectString)
        {
            Shape shape = null;
            if (shapeType == ShapeType.Line)
                shape = new Line();
            else if (shapeType == ShapeType.Rectangle)
                shape = JsonConvert.DeserializeObject<Rectangle>(objectString);
            else if (shapeType == ShapeType.Triangle)
                shape = JsonConvert.DeserializeObject<Triangle>(objectString);
            return shape;
        }

        // ClearString
        private string ClearString(string data)
        {
            return data.Replace(SOFT_NEW_LINE, STRING_EMPTY).Replace(NEW_LINE_STRING, STRING_EMPTY).Replace(SPACE, STRING_EMPTY);
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

        public IFileBaseService SaveFileService 
        {
            get
            {
                const string EXCEPTION_MESSAGE = "Service 未建立";
                if (SaveFileService == null)
                    throw new Exception(EXCEPTION_MESSAGE);
                return _saveFileService;
            }
            set
            {
                _saveFileService = value;
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
