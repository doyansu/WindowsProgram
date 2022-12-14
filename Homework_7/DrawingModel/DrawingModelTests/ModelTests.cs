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
    public class ModelTests
    {
        Model _model;
        Mock<IGraphics> _mockIGraphics;
        PrivateObject _privateObject;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _privateObject = new PrivateObject(_model);
        }

        // Test Constructor Model()
        [TestMethod()]
        public void TestModel()
        {
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));
            Assert.IsNull((Shape)_privateObject.GetFieldOrProperty("_hint"));
            Assert.AreEqual(ShapeType.Null, _model.DrawingShapeMode);
        }

        // TestPressPointer
        [TestMethod()]
        public void TestPressPointer()
        {
            IPoint point = new IPoint(3, 4);
            _model.PressPointer(point.X, point.Y);
            Assert.AreEqual(point.X, _privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(point.Y, _privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.IsTrue((bool)_privateObject.GetFieldOrProperty("_isPressed"));
        }

        // TestPressPointer OutOfRange
        [TestMethod()]
        public void TestPressPointerOutOfRange()
        {
            _model.PressPointer(0, 3);
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));

            _model.PressPointer(3, 0);
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));

            _model.PressPointer(0, 0);
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));

            _model.PressPointer(-1, 3);
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));

            _model.PressPointer(3, -1);
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));

            _model.PressPointer(-1, -1);
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));
        }

        // TestMovePointer
        [TestMethod()]
        public void TestMovePointer()
        {
            IPoint MoveTo = new IPoint(5, 6);

            // isPressed false, ShapeType null
            _model.MovePointer(MoveTo.X, MoveTo.Y);
            Assert.IsNull((Shape)_privateObject.GetFieldOrProperty("_hint"));

            _privateObject.SetFieldOrProperty("_isPressed", true);
            // isPressed true, ShapeType null
            _model.MovePointer(MoveTo.X, MoveTo.Y);
            Assert.IsNull((Shape)_privateObject.GetFieldOrProperty("_hint"));

            _model.DrawingShapeMode = ShapeType.Line;
            // isPressed true, ShapeType not null
            _model.MovePointer(MoveTo.X, MoveTo.Y);
            Shape shape = (Shape)_privateObject.GetFieldOrProperty("_hint");
            Assert.IsNotNull(shape);
            Assert.AreEqual(0, shape.X1);
            Assert.AreEqual(0, shape.Y1);
            Assert.AreEqual(5, shape.X2);
            Assert.AreEqual(6, shape.Y2);
        }

        // TestReleasePointer
        [TestMethod()]
        public void TestReleasePointer()
        {
            IPoint endPoint = new IPoint(5, 6);

            // isPressed false, hint null (do nothing)
            _model.ReleasePointer(endPoint.X, endPoint.Y);
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));
            Assert.IsNull((Shape)_privateObject.GetFieldOrProperty("_hint"));
            Assert.AreEqual(ShapeType.Null, _model.DrawingShapeMode);

            // isPressed true, hint null 
            _privateObject.SetFieldOrProperty("_isPressed", true);
            _model.ReleasePointer(endPoint.X, endPoint.Y);
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));
            Assert.IsNull((Shape)_privateObject.GetFieldOrProperty("_hint"));
            Assert.AreEqual(ShapeType.Null, _model.DrawingShapeMode);

            // isPressed true, hint not null 
            Shape shape = new Line(3, 4, 0, 0);
            _privateObject.SetFieldOrProperty("_hint", shape);
            _privateObject.SetFieldOrProperty("_isPressed", true);
            _model.ReleasePointer(endPoint.X, endPoint.Y);
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(0.0, _privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));
            Assert.IsNull((Shape)_privateObject.GetFieldOrProperty("_hint"));
            Assert.AreEqual(ShapeType.Null, _model.DrawingShapeMode);

            Shapes shapes = (Shapes)_privateObject.GetFieldOrProperty("_shapes");
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual(shape, shapes.GetBy(0));
        }

        // TestClear
        [TestMethod()]
        public void TestClear()
        {
            Shape shape = new Line(3, 4, 0, 0);
            Shapes shapes = (Shapes)_privateObject.GetFieldOrProperty("_shapes");
            shapes.Add(shape);
            _privateObject.SetFieldOrProperty("_hint", shape);
            _privateObject.SetFieldOrProperty("_isPressed", true);

            _model.Clear();
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));
            Assert.IsNull((Shape)_privateObject.GetFieldOrProperty("_hint"));
            Assert.AreEqual(0, shapes.Count);
        }

        // Test
        [TestMethod()]
        public void TestDraw()
        {
            // isPressed false, hint null
            _mockIGraphics = new Mock<IGraphics>();
            _model.Draw(_mockIGraphics.Object);
            _mockIGraphics.Verify(obj => obj.ClearAll(), Times.Exactly(1));

            // isPressed true, hint null
            _privateObject.SetFieldOrProperty("_isPressed", true);
            _mockIGraphics = new Mock<IGraphics>();
            _model.Draw(_mockIGraphics.Object);
            _mockIGraphics.Verify(obj => obj.ClearAll(), Times.Exactly(1));

            // isPressed true, hint not null
            _privateObject.SetFieldOrProperty("_hint", new Line(3, 4, 0, 0));
            _mockIGraphics = new Mock<IGraphics>();
            _model.Draw(_mockIGraphics.Object);
            _mockIGraphics.Verify(obj => obj.ClearAll(), Times.Exactly(1));
            _mockIGraphics.Verify(obj => obj.DrawLine(3, 4, 0, 0), Times.Exactly(1));

            // isPressed true, hint not null, shapes have obj
            Shapes shapes = (Shapes)_privateObject.GetFieldOrProperty("_shapes");
            shapes.Add(new Rectangle(5, 8, 10 ,11));
            shapes.Add(new Triangle(9, 9, 7, 7));
            _mockIGraphics = new Mock<IGraphics>();
            _model.Draw(_mockIGraphics.Object);
            _mockIGraphics.Verify(obj => obj.ClearAll(), Times.Exactly(1));
            _mockIGraphics.Verify(obj => obj.DrawLine(3, 4, 0, 0), Times.Exactly(1));
            _mockIGraphics.Verify(obj => obj.DrawRectangle(5, 8, 10, 11), Times.Exactly(1));
            _mockIGraphics.Verify(obj => obj.DrawTriangle(9, 9, 7, 7), Times.Exactly(1));
        }

        // Test
        [TestMethod()]
        public void TestNotifyModelChanged()
        {
            int excuteTimes = 0;
            _privateObject.Invoke("NotifyModelChanged");
            Assert.AreEqual(0, excuteTimes);

            _model._modelChanged += () =>
                { 
                    excuteTimes++; 
                };
            _privateObject.Invoke("NotifyModelChanged");
            Assert.AreEqual(1, excuteTimes);
        }
    }
}