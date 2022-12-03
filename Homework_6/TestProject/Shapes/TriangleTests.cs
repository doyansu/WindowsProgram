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
            Assert.AreEqual(0, _triangle.X1);
            Assert.AreEqual(0, _triangle.Y1);
            Assert.AreEqual(0, _triangle.X2);
            Assert.AreEqual(0, _triangle.Y2);
        }

        // Test Constructor Triangle(IPoint, IPoint)
        [TestMethod()]
        public void TestTriangleConstructorTwoPoint()
        {
            IPoint pointTopLeft = new IPoint(3, 4);
            IPoint pointBottomRight = new IPoint(10, 20);
            _triangle = new Triangle(pointTopLeft, pointBottomRight);
            Assert.AreEqual(3, _triangle.X1);
            Assert.AreEqual(4, _triangle.Y1);
            Assert.AreEqual(10, _triangle.X2);
            Assert.AreEqual(20, _triangle.Y2);
        }

        // Test Constructor Triangle(double x1, double y1, double x2, double y2)
        [TestMethod()]
        public void TestTriangleConstructorFourDouble()
        {
            IPoint pointTopLeft = new IPoint(3, 4);
            IPoint pointBottomRight = new IPoint(10, 20);
            _triangle = new Triangle(pointTopLeft.X, pointTopLeft.Y, pointBottomRight.X, pointBottomRight.Y);
            Assert.AreEqual(3, _triangle.X1);
            Assert.AreEqual(4, _triangle.Y1);
            Assert.AreEqual(10, _triangle.X2);
            Assert.AreEqual(20, _triangle.Y2);
        }

        // TestDraw 
        [TestMethod()]
        public void TestDraw()
        {
            IPoint pointTopLeft = new IPoint(3, 4);
            IPoint pointBottomRight = new IPoint(10, 20);
            _triangle = new Triangle(pointTopLeft, pointBottomRight);
            _triangle.Draw(_mockIGraphics.Object);
            _mockIGraphics.Verify(obj => obj.DrawTriangle(3, 4, 10, 20));
        }
    }
}