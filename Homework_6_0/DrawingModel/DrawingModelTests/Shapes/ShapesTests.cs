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
    public class ShapesTests
    {
        Shapes _shapes;
        Mock<IGraphics> _mockIGraphics;
        Mock<IShapeFactory> _mockShapeFactory;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockIGraphics = new Mock<IGraphics>();
            _mockShapeFactory = new Mock<IShapeFactory>();
            _shapes = new Shapes(_mockShapeFactory.Object);
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

        // TestCreateShape
        [TestMethod()]
        public void TestCreateShape()
        {
            _mockShapeFactory.Setup(obj => obj.CreateShape(ShapeType.Null))
                .Returns(new Line()
                {
                    X1 = 1,
                    Y1 = 2,
                    X2 = 3,
                    Y2 = 4
                });

            Shape shape;
            shape = _shapes.CreateShape(ShapeType.Null);
            _mockShapeFactory.Verify(obj => obj.CreateShape(ShapeType.Null));
            Assert.AreEqual(1, shape.X1);
            Assert.AreEqual(2, shape.Y1);
            Assert.AreEqual(3, shape.X2);
            Assert.AreEqual(4, shape.Y2);
        }

        // TestDraw
        [TestMethod()]
        public void TestDraw()
        {
            _shapes.Add(new Line());
            _shapes.Add(new Rectangle());
            _shapes.Add(new Rectangle());
            _shapes.Add(new Triangle());
            _shapes.Add(new Triangle());
            _shapes.Add(new Triangle());
            _shapes.Add(new Line(1, 2, 3, 4));
            _shapes.Add(new Rectangle(5, 6, 7, 8));
            _shapes.Add(new Triangle(9, 10, 11, 12));

            _shapes.Draw(_mockIGraphics.Object);
            _mockIGraphics.Verify(obj => obj.DrawLine(0, 0, 0, 0), Times.Exactly(1));
            _mockIGraphics.Verify(obj => obj.DrawRectangle(0, 0, 0, 0), Times.Exactly(2));
            _mockIGraphics.Verify(obj => obj.DrawTriangle(0, 0, 0, 0), Times.Exactly(3));
            _mockIGraphics.Verify(obj => obj.DrawLine(1, 2, 3, 4));
            _mockIGraphics.Verify(obj => obj.DrawRectangle(5, 6, 7, 8));
            _mockIGraphics.Verify(obj => obj.DrawTriangle(9, 10, 11, 12));
        }

        // TestGetBy
        [TestMethod()]
        public void TestGetByIndexOutOfRange()
        {
            Shape shape;
            shape = _shapes.GetBy(-1);
            Assert.IsNull(shape);
            shape = _shapes.GetBy(0);
            Assert.IsNull(shape);
            shape = _shapes.GetBy(9999);
            Assert.IsNull(shape);
        }
    }
}