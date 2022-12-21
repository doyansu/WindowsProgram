using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        Mock<IGraphics> _mockIGraphics;
        Triangle _triangle;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockIGraphics = new Mock<IGraphics>();
        }

        // Test Constructor Triangle()
        [TestMethod()]
        public void TestTriangleConstructor()
        {
            _triangle = new Triangle();
            Assert.AreEqual(0, _triangle.StartX);
            Assert.AreEqual(0, _triangle.StartY);
            Assert.AreEqual(0, _triangle.EndX);
            Assert.AreEqual(0, _triangle.EndY);
        }

        // Test Constructor Triangle(double x1, double y1, double x2, double y2)
        [TestMethod()]
        public void TestTriangleConstructorFourDouble()
        {
            IPoint pointTopLeft = new IPoint(3, 4);
            IPoint pointBottomRight = new IPoint(10, 20);
            _triangle = new Triangle(pointTopLeft.X, pointTopLeft.Y, pointBottomRight.X, pointBottomRight.Y);
            Assert.AreEqual(3, _triangle.StartX);
            Assert.AreEqual(4, _triangle.StartY);
            Assert.AreEqual(10, _triangle.EndX);
            Assert.AreEqual(20, _triangle.EndY);
        }

        // TestDraw 
        [TestMethod()]
        public void TestDraw()
        {
            IPoint pointTopLeft = new IPoint(3, 4);
            IPoint pointBottomRight = new IPoint(10, 20);
            _triangle = new Triangle(pointTopLeft.X, pointTopLeft.Y, pointBottomRight.X, pointBottomRight.Y);
            _triangle.Draw(_mockIGraphics.Object);
            _mockIGraphics.Verify(obj => obj.DrawTriangle(3, 4, 10, 20));
        }

        // TestIsContains 
        [TestMethod()]
        public void TestIsContains()
        {
            IPoint pointTopLeft = new IPoint(3, 4);
            IPoint pointBottomRight = new IPoint(10, 20);
            _triangle = new Triangle(pointTopLeft.X, pointTopLeft.Y, pointBottomRight.X, pointBottomRight.Y);
            Assert.IsFalse(_triangle.IsContains(1, 2));
            Assert.IsFalse(_triangle.IsContains(-1, 2));
            Assert.IsFalse(_triangle.IsContains(1, -2));
            Assert.IsFalse(_triangle.IsContains(-1, -2));
            Assert.IsFalse(_triangle.IsContains(100, 2));
            Assert.IsFalse(_triangle.IsContains(1, 200));
            Assert.IsFalse(_triangle.IsContains(3, 4));
            Assert.IsFalse(_triangle.IsContains(10, 4));
            Assert.IsTrue(_triangle.IsContains(3, 20));
            Assert.IsTrue(_triangle.IsContains(10, 20));
            Assert.IsTrue(_triangle.IsContains(6, 19));
        }

        // TestShapeInformation 
        [TestMethod()]
        public void TestShapeInformation()
        {
            IPoint pointTopLeft = new IPoint(3, 4);
            IPoint pointBottomRight = new IPoint(10, 20);
            _triangle = new Triangle(pointTopLeft.X, pointTopLeft.Y, pointBottomRight.X, pointBottomRight.Y);
            Assert.AreEqual("Triangle(3, 4, 10, 20)", _triangle.ShapeInformation());
        }
    }
}