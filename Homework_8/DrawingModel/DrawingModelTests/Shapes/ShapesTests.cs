using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.ComponentModel;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class ShapesTests
    {
        Shapes _shapes;
        Mock<IGraphics> _mockIGraphics;
        Mock<IShapeFactory> _mockShapeFactory;
        PrivateObject _privateObject;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockIGraphics = new Mock<IGraphics>();
            _mockShapeFactory = new Mock<IShapeFactory>();
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
    }
}