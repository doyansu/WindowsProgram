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
    public class LineTests
    {
        Mock<IGraphics> _mockIGraphics;
        Line _line;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockIGraphics = new Mock<IGraphics>();
        }

        // Test Constructor Line()
        [TestMethod()]
        public void TestLineConstructor()
        {
            _line = new Line();
            Assert.AreEqual(0, _line.X1);
            Assert.AreEqual(0, _line.Y1);
            Assert.AreEqual(0, _line.X2);
            Assert.AreEqual(0, _line.Y2);
        }

        // Test Constructor Line(IPoint, IPoint)
        [TestMethod()]
        public void TestLineConstructorTwoPoint()
        {
            IPoint pointTopLeft = new IPoint(3, 4);
            IPoint pointBottomRight = new IPoint(10, 20);
            _line = new Line(pointTopLeft, pointBottomRight);
            Assert.AreEqual(3, _line.X1);
            Assert.AreEqual(4, _line.Y1);
            Assert.AreEqual(10, _line.X2);
            Assert.AreEqual(20, _line.Y2);
        }

        // Test Constructor Line(double x1, double y1, double x2, double y2)
        [TestMethod()]
        public void TestLineConstructorFourDouble()
        {
            IPoint pointTopLeft = new IPoint(3, 4);
            IPoint pointBottomRight = new IPoint(10, 20);
            _line = new Line(pointTopLeft.X, pointTopLeft.Y, pointBottomRight.X, pointBottomRight.Y);
            Assert.AreEqual(3, _line.X1);
            Assert.AreEqual(4, _line.Y1);
            Assert.AreEqual(10, _line.X2);
            Assert.AreEqual(20, _line.Y2);
        }

        // TestDraw 
        [TestMethod()]
        public void TestDraw()
        {
            IPoint pointTopLeft = new IPoint(3, 4);
            IPoint pointBottomRight = new IPoint(10, 20);
            _line = new Line(pointTopLeft, pointBottomRight);
            _line.Draw(_mockIGraphics.Object);
            _mockIGraphics.Verify(obj => obj.DrawLine(3, 4, 10, 20));
        }
    }
}