using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.ComponentModel;
using DrawingModel.GoogleDrive;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class ShapesTests
    {
        Shapes _shapes;
        Mock<IGraphics> _mockIGraphics;
        Mock<IShapeFactory> _mockShapeFactory;
        Mock<IFileBaseService> _mockIFileBaseService;
        PrivateObject _privateObject;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockIGraphics = new Mock<IGraphics>();
            _mockShapeFactory = new Mock<IShapeFactory>();
            _mockIFileBaseService = new Mock<IFileBaseService>();
            _shapes = new Shapes();
            _privateObject = new PrivateObject(_shapes);
        }

        // Test Constructor Shapes(ShapeFactory)
        [TestMethod()]
        public void TestShapes()
        {
            Assert.AreEqual(0, _shapes.Count);
        }

        // TestAdd
        [TestMethod()]
        public void TestAdd()
        {
            _shapes.Add(null);
            Assert.AreEqual(0, _shapes.Count);

            Shape shape = new Line();
            _shapes.Add(shape);
            Assert.AreEqual(shape, _shapes.GetBy(0));
            Assert.AreEqual(1, _shapes.Count);

            Shape shape1 = new Line();
            _shapes.Add(shape1);
            Assert.AreEqual(shape, _shapes.GetBy(0));
            Assert.AreEqual(shape1, _shapes.GetBy(1));
            Assert.AreEqual(2, _shapes.Count);
        }

        // TestClear
        [TestMethod()]
        public void TestClear()
        {
            Shape shape = new Line();
            _shapes.Add(shape);
            _shapes.Clear();
            Assert.AreEqual(0, _shapes.Count);
        }

        // TestDraw
        [TestMethod()]
        public void TestDraw()
        {
            _shapes.Add(new Rectangle());
            _shapes.Add(new Rectangle());
            _shapes.Add(new Rectangle());
            _shapes.Add(new Triangle());
            _shapes.Add(new Triangle());
            _shapes.Add(new Triangle());
            _shapes.Add(new Rectangle());
            _shapes.Add(new Rectangle(5, 6, 7, 8));
            _shapes.Add(new Triangle(9, 10, 11, 12));

            _shapes.Draw(_mockIGraphics.Object);
            _mockIGraphics.Verify(obj => obj.DrawRectangle(0, 0, 0, 0), Times.Exactly(4));
            _mockIGraphics.Verify(obj => obj.DrawTriangle(0, 0, 0, 0), Times.Exactly(3));
            _mockIGraphics.Verify(obj => obj.DrawRectangle(5, 6, 7, 8));
            _mockIGraphics.Verify(obj => obj.DrawTriangle(9, 10, 11, 12));
        }

        // TestGetBy
        [TestMethod()]
        public void TestGetByIndexOutOfRange()
        {
            Func<Shape> funcZero = () =>
            {
                return _shapes.GetBy(0);
            };
            Assert.ThrowsException<Exception>(funcZero, "index out of range");
            Func<Shape> funcNegative = () =>
            {
                return _shapes.GetBy(-1);
            };
            Assert.ThrowsException<Exception>(funcNegative, "index out of range");
            Func<Shape> funcLargeNumber = () =>
            {
                return _shapes.GetBy(999);
            };
            Assert.ThrowsException<Exception>(funcLargeNumber, "index out of range");
        }

        // TestCheckPointContains
        [TestMethod()]
        public void TestCheckPointContains()
        {
            Shape shape = new Rectangle(5, 6, 7, 8);
            Shape shape1 = new Rectangle(3, 3, 20, 20);
            _shapes.Add(shape1);
            _shapes.Add(shape);
            _shapes.Add(new Triangle(0, 0, 3, 3));

            Assert.AreEqual(shape, _shapes.CheckPointContains(shape.StartX, shape.StartY));
            Assert.AreEqual(shape1, _shapes.CheckPointContains(shape1.GetCenterX(), shape1.GetCenterY()));
            Assert.IsNull(_shapes.CheckPointContains(0, 0));
        }

        // TestSelectShape
        [TestMethod()]
        public void TestSelectShape()
        {
            Shape shape = new Rectangle(5, 6, 7, 8);
            Shape shape1 = new Rectangle(3, 3, 20, 20);
            Shape triangle = new Triangle(0, 0, 3, 3);
            _shapes.Add(shape1);
            _shapes.Add(shape);
            _shapes.Add(triangle);

            Assert.AreEqual("", _shapes.SelectedShapeInformation);

            _shapes.SelectShape(shape.StartX, shape.StartY);
            Assert.IsTrue(shape.IsSelected);
            Assert.IsFalse(shape1.IsSelected);
            Assert.IsFalse(triangle.IsSelected);
            Assert.AreEqual("Selected：Rectangle(5, 6, 7, 8)", _shapes.SelectedShapeInformation);

            _shapes.SelectShape(shape1.GetCenterX(), shape1.GetCenterY());
            Assert.IsFalse(shape.IsSelected);
            Assert.IsTrue(shape1.IsSelected);
            Assert.IsFalse(triangle.IsSelected);
            Assert.AreEqual("Selected：Rectangle(3, 3, 20, 20)", _shapes.SelectedShapeInformation);

            _shapes.SelectShape(triangle.GetCenterX(), triangle.GetCenterY());
            Assert.IsFalse(shape.IsSelected);
            Assert.IsFalse(shape1.IsSelected);
            Assert.IsTrue(triangle.IsSelected);
            Assert.AreEqual("Selected：Triangle(0, 0, 3, 3)", _shapes.SelectedShapeInformation);
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            string propertyName = "test";
            _privateObject.Invoke("NotifyPropertyChanged", propertyName);
            Assert.AreEqual(0, receivedEvents.Count);
            _shapes.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            _privateObject.Invoke("NotifyPropertyChanged", propertyName);
            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual(propertyName, receivedEvents[0]);
        }

        const string TEMP_FILE_NAME = "DrawingShapes.txt";
        const string CONTENT_TYPE = "text/xml";

        // TestSaveFileService
        [TestMethod()]
        public void TestSaveFileService()
        {
            Assert.ThrowsException<Exception>(() => _privateObject.GetFieldOrProperty("SaveFileService"), "Service 未建立");
            _shapes.SetFileBaseService(_mockIFileBaseService.Object);
            Assert.ReferenceEquals(_mockIFileBaseService.Object, _privateObject.GetFieldOrProperty("SaveFileService"));
        }

        // TestSaveShapes
        [TestMethod()]
        public void TestSaveShapes()
        {
            _shapes.SetFileBaseService(_mockIFileBaseService.Object);
            Shape rectangle = new Rectangle();
            Shape triangle = new Triangle();
            Line line = new Line();
            line.StartShape = rectangle;
            line.EndShape = triangle;
            _shapes.SaveShapes();
            _mockIFileBaseService.Verify(obj => obj.UploadFile(TEMP_FILE_NAME, "", CONTENT_TYPE), Times.Exactly(1));
            _shapes.Add(rectangle);
            _shapes.Add(triangle);
            _shapes.Add(line);
            _shapes.SaveShapes();
            _mockIFileBaseService.Verify(obj => obj.UploadFile(TEMP_FILE_NAME, "{\"StartX\":0,\"StartY\":0,\"EndX\":0,\"EndY\":0,\"Left\":0,\"Top\":0,\"Right\":0,\"Bottom\":0,\"IsSelected\":false,\"ShapeType\":2}\n{\"StartX\":0,\"StartY\":0,\"EndX\":0,\"EndY\":0,\"Left\":0,\"Top\":0,\"Right\":0,\"Bottom\":0,\"IsSelected\":false,\"ShapeType\":3}\n{\"CanDraw\":true,\"StartShape\":{\"StartX\":0,\"StartY\":0,\"EndX\":0,\"EndY\":0,\"Left\":0,\"Top\":0,\"Right\":0,\"Bottom\":0,\"IsSelected\":false,\"ShapeType\":2},\"EndShape\":{\"StartX\":0,\"StartY\":0,\"EndX\":0,\"EndY\":0,\"Left\":0,\"Top\":0,\"Right\":0,\"Bottom\":0,\"IsSelected\":false,\"ShapeType\":3},\"StartX\":0,\"StartY\":0,\"EndX\":0,\"EndY\":0,\"Left\":0,\"Top\":0,\"Right\":0,\"Bottom\":0,\"IsSelected\":false,\"ShapeType\":1}", CONTENT_TYPE), Times.Exactly(1));
        }

        // TestLoadShapes
        [TestMethod()]
        public void TestLoadShapes()
        {
            _shapes.SetFileBaseService(_mockIFileBaseService.Object);
            _mockIFileBaseService.Setup(obj => obj.ReadFile(TEMP_FILE_NAME)).Returns("");
            _shapes.LoadShapes();
            Assert.AreEqual(0, _shapes.Count);

            Shape rectangle = new Rectangle();
            Shape triangle = new Triangle();
            Line line = new Line();
            line.StartShape = rectangle;
            line.EndShape = triangle;
            _shapes.Add(rectangle);
            _shapes.Add(triangle);
            _shapes.Add(line);
            _shapes.SaveShapes();
            _shapes.Clear();
            _mockIFileBaseService.Setup(obj => obj.ReadFile(TEMP_FILE_NAME)).Returns("{\"StartX\":0,\"StartY\":0,\"EndX\":0,\"EndY\":0,\"Left\":0,\"Top\":0,\"Right\":0,\"Bottom\":0,\"IsSelected\":false,\"ShapeType\":2}\n{\"StartX\":0,\"StartY\":0,\"EndX\":0,\"EndY\":0,\"Left\":0,\"Top\":0,\"Right\":0,\"Bottom\":0,\"IsSelected\":false,\"ShapeType\":3}\n{\"CanDraw\":true,\"StartShape\":{\"StartX\":0,\"StartY\":0,\"EndX\":0,\"EndY\":0,\"Left\":0,\"Top\":0,\"Right\":0,\"Bottom\":0,\"IsSelected\":false,\"ShapeType\":2},\"EndShape\":{\"StartX\":0,\"StartY\":0,\"EndX\":0,\"EndY\":0,\"Left\":0,\"Top\":0,\"Right\":0,\"Bottom\":0,\"IsSelected\":false,\"ShapeType\":3},\"StartX\":0,\"StartY\":0,\"EndX\":0,\"EndY\":0,\"Left\":0,\"Top\":0,\"Right\":0,\"Bottom\":0,\"IsSelected\":false,\"ShapeType\":1}");
            _shapes.LoadShapes();
            Assert.AreEqual(3, _shapes.Count);
        }

        // TestIsFileExist
        [TestMethod()]
        public void TestIsFileExist()
        {
            _shapes.SetFileBaseService(_mockIFileBaseService.Object);
            _mockIFileBaseService.Setup(obj => obj.IsContain(TEMP_FILE_NAME)).Returns(false);
            Assert.AreEqual(false, _shapes.IsFileExist());
            _mockIFileBaseService.Verify(obj => obj.IsContain(TEMP_FILE_NAME), Times.Exactly(1));
        }

        // TestGetObject
        [TestMethod()]
        public void TestGetObject()
        {
            Assert.IsNull(_privateObject.Invoke("GetObject", new object[] { ShapeType.Null, "" }));
        }
    }
}