using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using DrawingModel.Commands;
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
        public void TestPressPointerSelect()
        {
            IPoint point = new IPoint(3, 4);
            _model.PressPointer(point.X, point.Y);
            Assert.AreEqual(point.X, _privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(point.Y, _privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));
        }

        // TestPressPointer
        [TestMethod()]
        public void TestPressPointerDrawShape()
        {
            IPoint point = new IPoint(3, 4);
            _model.DrawingShapeMode = ShapeType.Rectangle;
            _model.PressPointer(point.X, point.Y);
            Assert.AreEqual(point.X, _privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(point.Y, _privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.IsTrue((bool)_privateObject.GetFieldOrProperty("_isPressed"));

            _model.DrawingShapeMode = ShapeType.Triangle;
            _model.PressPointer(point.X, point.Y);
            Assert.AreEqual(point.X, _privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(point.Y, _privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.IsTrue((bool)_privateObject.GetFieldOrProperty("_isPressed"));

            _privateObject.SetFieldOrProperty("_isPressed", false);
            _model.DrawingShapeMode = ShapeType.Line;
            _model.PressPointer(point.X, point.Y);
            Assert.AreEqual(point.X, _privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(point.Y, _privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));
            _model.ShapeBindingObject.Add(new Rectangle(0, 0, 4, 4));
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

            // isPressed true, ShapeType not null
            _model.DrawingShapeMode = ShapeType.Rectangle;
            _model.MovePointer(MoveTo.X, MoveTo.Y);
            Shape shape = (Shape)_privateObject.GetFieldOrProperty("_hint");
            Assert.IsNotNull(shape);
            Assert.AreEqual(0, shape.StartX);
            Assert.AreEqual(0, shape.StartY);
            Assert.AreEqual(5, shape.EndX);
            Assert.AreEqual(6, shape.EndY);

            _model.DrawingShapeMode = ShapeType.Line;
            _model.MovePointer(MoveTo.X, MoveTo.Y);
            Line line = (Line)_privateObject.GetFieldOrProperty("_hint");
            Assert.IsNotNull(line);
            Assert.AreEqual(0, line.StartX);
            Assert.AreEqual(0, line.StartY);
            Assert.AreEqual(5, line.EndX);
            Assert.AreEqual(6, line.EndY);
            Assert.IsNull(line.StartShape);
            Assert.AreEqual(5, line.EndShape.StartX);
            Assert.AreEqual(6, line.EndShape.StartY);
            Assert.AreEqual(5, line.EndShape.EndX);
            Assert.AreEqual(6, line.EndShape.EndY);
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
            Shape shape = new Rectangle(3, 4, 0, 0);
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

            // draw line
            _model.DrawingShapeMode = ShapeType.Line;
            Line line = new Line();
            Shape start = new Rectangle(0, 0, 3, 3);
            Shape end = new Rectangle(3, 3, 10, 10);
            line.StartShape = start;
            _model.ShapeBindingObject.Add(start);
            _model.ShapeBindingObject.Add(end);
            _privateObject.SetFieldOrProperty("_hint", line);
            _privateObject.SetFieldOrProperty("_isPressed", true);
            Assert.IsFalse(_model.ReleasePointer(100, 100));
            _privateObject.SetFieldOrProperty("_hint", line);
            _privateObject.SetFieldOrProperty("_isPressed", true);
            Assert.IsFalse(_model.ReleasePointer(start.GetCenterX(), start.GetCenterY()));
            _privateObject.SetFieldOrProperty("_hint", line);
            _privateObject.SetFieldOrProperty("_isPressed", true);
            Assert.IsTrue(_model.ReleasePointer(end.GetCenterX(), end.GetCenterY()));
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));
            Assert.IsNull((Shape)_privateObject.GetFieldOrProperty("_hint"));
            Assert.AreEqual(ShapeType.Line, _model.DrawingShapeMode);
        }

        // TestClear
        [TestMethod()]
        public void TestClear()
        {
            _model.Clear();
            Assert.IsFalse(_model.CommandBindingObject.IsUndoEnabled);

            Shape shape = new Rectangle(3, 4, 0, 0);
            Shapes shapes = (Shapes)_privateObject.GetFieldOrProperty("_shapes");
            shapes.Add(shape);
            _privateObject.SetFieldOrProperty("_hint", shape);
            _privateObject.SetFieldOrProperty("_isPressed", true);
            _model.Clear();
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));
            Assert.IsNull((Shape)_privateObject.GetFieldOrProperty("_hint"));
            Assert.AreEqual(0, shapes.Count);
        }

        // TestDraw
        [TestMethod()]
        public void TestDraw()
        {
            _model.DrawingShapeMode = ShapeType.Rectangle;
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
            _privateObject.SetFieldOrProperty("_hint", new Triangle(3, 4, 0, 0));
            _mockIGraphics = new Mock<IGraphics>();
            _model.Draw(_mockIGraphics.Object);
            _mockIGraphics.Verify(obj => obj.ClearAll(), Times.Exactly(1));
            _mockIGraphics.Verify(obj => obj.DrawTriangle(0, 0, 3, 4), Times.Exactly(1));

            // isPressed true, hint not null, shapes have obj
            Shapes shapes = (Shapes)_privateObject.GetFieldOrProperty("_shapes");
            shapes.Add(new Rectangle(5, 8, 10 ,11));
            shapes.Add(new Triangle(9, 9, 7, 7));
            _mockIGraphics = new Mock<IGraphics>();
            _model.Draw(_mockIGraphics.Object);
            _mockIGraphics.Verify(obj => obj.ClearAll(), Times.Exactly(1));
            _mockIGraphics.Verify(obj => obj.DrawTriangle(0, 0, 3, 4), Times.Exactly(1));
            _mockIGraphics.Verify(obj => obj.DrawRectangle(5, 8, 10, 11), Times.Exactly(1));
            _mockIGraphics.Verify(obj => obj.DrawTriangle(7, 7, 9, 9), Times.Exactly(1));
        }

        // TestUndo
        [TestMethod()]
        public void TestUndoRedo()
        {
            _model.CommandBindingObject.Execute(new ClearCommand(_model));
            _model.Undo();
            Assert.IsTrue(_model.CommandBindingObject.IsRedoEnabled);
            Assert.IsFalse(_model.CommandBindingObject.IsUndoEnabled);
            _model.Redo();
            Assert.IsFalse(_model.CommandBindingObject.IsRedoEnabled);
            Assert.IsTrue(_model.CommandBindingObject.IsUndoEnabled);
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