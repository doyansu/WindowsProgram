using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Text.Json;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class ShapeTests
    {
        TestShape _testShape;
        Mock<IGraphics> _mockIGraphics;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _testShape = new TestShape();
            _mockIGraphics = new Mock<IGraphics>();
        }

        // TestDraw
        [TestMethod()]
        public void TestDraw()
        {
            _testShape.Draw(_mockIGraphics.Object);
            _testShape.Draw(_mockIGraphics.Object);
            Assert.AreEqual(2, _testShape._invoke["Draw"]);
        }

        // TestDrawSelected
        [TestMethod()]
        public void TestDrawSelected()
        {
            _testShape.DrawSelected(_mockIGraphics.Object);
            _mockIGraphics.Verify(obj => obj.DrawSelectedRectangle(0, 0, 0, 0), Times.Exactly(0));
            _testShape.IsSelected = true;
            _testShape.DrawSelected(_mockIGraphics.Object);
            _testShape.DrawSelected(_mockIGraphics.Object);
            _mockIGraphics.Verify(obj => obj.DrawSelectedRectangle(0, 0, 0, 0), Times.Exactly(2));
        }

        // TestIsContains
        [TestMethod()]
        public void TestIsContains()
        {
            _testShape.StartX = 3;
            _testShape.StartY = 3;
            _testShape.EndX = 10;
            _testShape.EndY = 10;
            Assert.IsFalse(_testShape.IsContains(1, 2));
            Assert.IsFalse(_testShape.IsContains(-1, 2));
            Assert.IsFalse(_testShape.IsContains(1, -2));
            Assert.IsFalse(_testShape.IsContains(-1, -2));
            Assert.IsFalse(_testShape.IsContains(100, 2));
            Assert.IsFalse(_testShape.IsContains(1, 200));
            Assert.IsFalse(_testShape.IsContains(100, 200));
            Assert.IsTrue(_testShape.IsContains(3, 3));
            Assert.IsTrue(_testShape.IsContains(3, 10));
            Assert.IsTrue(_testShape.IsContains(10, 3));
            Assert.IsTrue(_testShape.IsContains(10, 10));
            Assert.IsTrue(_testShape.IsContains(4, 4));
            Assert.IsTrue(_testShape.IsContains(5, 5));
            Assert.IsTrue(_testShape.IsContains(6, 6));
            Assert.IsTrue(_testShape.IsContains(7, 7));
        }

        // TestGetCenter
        [TestMethod()]
        public void TestGetCenter()
        {
            IPoint start = new IPoint(3, 3);
            IPoint end = new IPoint(10, 10);
            _testShape.StartX = start.X;
            _testShape.StartY = start.Y;
            _testShape.EndX = end.X;
            _testShape.EndY = end.Y;
            IPoint center = _testShape.GetCenter();
            Assert.AreEqual(6.5, center.X);
            Assert.AreEqual(6.5, center.Y);
        }

        // TestGetCenterX
        [TestMethod()]
        public void TestGetCenterX()
        {
            IPoint start = new IPoint(3, 6);
            IPoint end = new IPoint(10, 10);
            _testShape.StartX = start.X;
            _testShape.StartY = start.Y;
            _testShape.EndX = end.X;
            _testShape.EndY = end.Y;
            Assert.AreEqual(6.5, _testShape.GetCenterX());
        }

        // TestGetCenterY
        [TestMethod()]
        public void TestGetCenterY()
        {
            IPoint start = new IPoint(3, 6);
            IPoint end = new IPoint(10, 10);
            _testShape.StartX = start.X;
            _testShape.StartY = start.Y;
            _testShape.EndX = end.X;
            _testShape.EndY = end.Y;
            Assert.AreEqual(8, _testShape.GetCenterY());
        }

        // TestShapeInformation
        [TestMethod()]
        public void TestShapeInformation()
        {
            IPoint start = new IPoint(3, 6);
            IPoint end = new IPoint(10, 10);
            _testShape.StartX = start.X;
            _testShape.StartY = start.Y;
            _testShape.EndX = end.X;
            _testShape.EndY = end.Y;
            Assert.AreEqual("Shape(3, 6, 10, 10)", _testShape.ShapeInformation());
        }

        // TestGetObjectString
        [TestMethod()]
        public void TestGetObjectString()
        {
            Assert.AreEqual("{\"StartX\":0,\"StartY\":0,\"EndX\":0,\"EndY\":0,\"Left\":0,\"Top\":0,\"Right\":0,\"Bottom\":0,\"IsSelected\":false,\"ShapeType\":0}", _testShape.GetObjectString());
            IPoint start = new IPoint(3, 6);
            IPoint end = new IPoint(10, 10);
            _testShape.StartX = start.X;
            _testShape.StartY = start.Y;
            _testShape.EndX = end.X;
            _testShape.EndY = end.Y;
            Assert.AreEqual("{\"StartX\":3,\"StartY\":6,\"EndX\":10,\"EndY\":10,\"Left\":3,\"Top\":6,\"Right\":10,\"Bottom\":10,\"IsSelected\":false,\"ShapeType\":0}", _testShape.GetObjectString());
        }
    }
}