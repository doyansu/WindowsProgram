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
            Assert.AreEqual(0, _line.StartX);
            Assert.AreEqual(0, _line.StartY);
            Assert.AreEqual(0, _line.EndX);
            Assert.AreEqual(0, _line.EndY);
            Assert.IsNull(_line.StartShape);
            Assert.IsNull(_line.EndShape);
            Assert.IsFalse(_line.CanDraw);
        }

        // TestDraw 
        [TestMethod()]
        public void TestDraw()
        {
            Shape start = new Rectangle(1, 1, 5, 5), end = new Rectangle(7, 8, 20, 6);
            _line = new Line();
            _line.Draw(_mockIGraphics.Object);
            Assert.IsFalse(_line.CanDraw);
            _line.StartShape = start;
            _line.EndShape = end;
            Assert.IsTrue(_line.CanDraw);
            _line.Draw(_mockIGraphics.Object);
            _mockIGraphics.Verify(obj => obj.DrawLine(3, 3, 13.5, 7));
        }

        // TestIsContains 
        [TestMethod()]
        public void TestIsContains()
        {
            _line = new Line();
            Assert.IsFalse(_line.IsContains(1, 2));
            Assert.IsFalse(_line.IsContains(-1, 2));
            Assert.IsFalse(_line.IsContains(1, -2));
            Assert.IsFalse(_line.IsContains(-1, -2));
            Assert.IsFalse(_line.IsContains(100, 2));
            Assert.IsFalse(_line.IsContains(1, 200));
        }

        // TestGetObjectString
        [TestMethod()]
        public void TestGetObjectString()
        {
            _line = new Line();
            Assert.AreEqual("{\"CanDraw\":false,\"StartShape\":null,\"EndShape\":null,\"StartX\":0,\"StartY\":0,\"EndX\":0,\"EndY\":0,\"Left\":0,\"Top\":0,\"Right\":0,\"Bottom\":0,\"IsSelected\":false,\"ShapeType\":1}", _line.GetObjectString());
        }
    }
}