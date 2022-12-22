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
    public class RectangleTests
    {
        Mock<IGraphics> _mockIGraphics;
        Rectangle _rectangle;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockIGraphics = new Mock<IGraphics>();
        }

        // TestRectangle
        [TestMethod()]
        public void TestRectangleConstructor()
        {
            _rectangle = new Rectangle();
            Assert.AreEqual(0, _rectangle.StartX);
            Assert.AreEqual(0, _rectangle.StartY);
            Assert.AreEqual(0, _rectangle.EndX);
            Assert.AreEqual(0, _rectangle.EndY);
        }

        // Test Constructor Rectangle(double x1, double y1, double x2, double y2)
        [TestMethod()]
        public void TestRectangleConstructorFourDouble()
        {
            IPoint pointTopLeft = new IPoint(3, 4);
            IPoint pointBottomRight = new IPoint(10, 20);
            _rectangle = new Rectangle(pointTopLeft.X, pointTopLeft.Y, pointBottomRight.X, pointBottomRight.Y);
            Assert.AreEqual(3, _rectangle.StartX);
            Assert.AreEqual(4, _rectangle.StartY);
            Assert.AreEqual(10, _rectangle.EndX);
            Assert.AreEqual(20, _rectangle.EndY);
        }

        // TestDraw
        [TestMethod()]
        public void TestDraw()
        {
            IPoint pointTopLeft = new IPoint(3, 4);
            IPoint pointBottomRight = new IPoint(10, 20);
            _rectangle = new Rectangle(pointTopLeft.X, pointTopLeft.Y, pointBottomRight.X, pointBottomRight.Y);
            _rectangle.Draw(_mockIGraphics.Object);
            _mockIGraphics.Verify(obj => obj.DrawRectangle(3, 4, 10, 20));
        }

        // TestShapeInformation 
        [TestMethod()]
        public void TestShapeInformation()
        {
            IPoint pointTopLeft = new IPoint(3, 4);
            IPoint pointBottomRight = new IPoint(10, 20);
            _rectangle = new Rectangle(pointTopLeft.X, pointTopLeft.Y, pointBottomRight.X, pointBottomRight.Y);
            Assert.AreEqual("Rectangle(3, 4, 10, 20)", _rectangle.ShapeInformation());
        }
    }
}