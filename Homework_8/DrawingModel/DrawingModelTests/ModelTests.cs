using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using DrawingModel.Commands;
using DrawingModel.States;
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
        Mock<IDrawingState> _mockIDrawingState;
        PrivateObject _privateObject;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _mockIGraphics = new Mock<IGraphics>();
            _mockIDrawingState = new Mock<IDrawingState>();
            _privateObject = new PrivateObject(_model);
        }

        // Test Constructor Model()
        [TestMethod()]
        public void TestModel()
        {
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));
            Assert.IsNull((Shape)_privateObject.GetFieldOrProperty("_hint"));
        }

        // TestPressPointer
        [TestMethod()]
        public void TestPressPointer()
        {
            IPoint point = new IPoint(3, 4);
            _model.CurrentState = _mockIDrawingState.Object;
            _model.PressPointer(point.X, point.Y);
            Assert.IsTrue((bool)_privateObject.GetFieldOrProperty("_isPressed"));
            _mockIDrawingState.Verify(obj => obj.PressPointer(3, 4), Times.Exactly(1));
        }

        // TestPressPointer OutOfRange
        [TestMethod()]
        public void TestPressPointerOutOfRange()
        {
            _model.PressPointer(0, 3);
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));

            _model.PressPointer(3, 0);
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));

            _model.PressPointer(0, 0);
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));

            _model.PressPointer(-1, 3);
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));

            _model.PressPointer(3, -1);
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));

            _model.PressPointer(-1, -1);
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));
        }

        // TestMovePointer
        [TestMethod()]
        public void TestMovePointer()
        {
            IPoint MoveTo = new IPoint(5, 6);
            _model.CurrentState = _mockIDrawingState.Object;

            // isPressed false
            _model.MovePointer(MoveTo.X, MoveTo.Y);
            _mockIDrawingState.Verify(obj => obj.MovePointer(MoveTo.X, MoveTo.Y), Times.Exactly(0));

            // isPressed true
            _privateObject.SetFieldOrProperty("_isPressed", true);
            _model.MovePointer(MoveTo.X, MoveTo.Y);
            _mockIDrawingState.Verify(obj => obj.MovePointer(MoveTo.X, MoveTo.Y), Times.Exactly(1));
        }

        // TestReleasePointer
        [TestMethod()]
        public void TestReleasePointer()
        {
            IPoint endPoint = new IPoint(5, 6);
            _model.CurrentState = _mockIDrawingState.Object;

            // isPressed false
            _model.ReleasePointer(endPoint.X, endPoint.Y);
            _mockIDrawingState.Verify(obj => obj.ReleasePointer(endPoint.X, endPoint.Y), Times.Exactly(0));

            // isPressed true
            _privateObject.SetFieldOrProperty("_isPressed", true);
            _model.ReleasePointer(endPoint.X, endPoint.Y);
            Assert.IsFalse((bool)_privateObject.GetFieldOrProperty("_isPressed"));
            _mockIDrawingState.Verify(obj => obj.ReleasePointer(endPoint.X, endPoint.Y), Times.Exactly(1));
        }

        // TestClear
        [TestMethod()]
        public void TestClear()
        {
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
            // isPressed false, hint null
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
            shapes.Add(new Rectangle(5, 8, 10, 11));
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

        // TestNotifyModelChanged
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

        // Test
        [TestMethod()]
        public void TestNotifyCommandReleased()
        {
            int excuteTimes = 0;
            _privateObject.Invoke("NotifyCommandReleased");
            Assert.AreEqual(0, excuteTimes);

            _model._commandReleased += () =>
            {
                excuteTimes++;
            };
            _privateObject.Invoke("NotifyCommandReleased");
            Assert.AreEqual(1, excuteTimes);
        }

        // TestCheckShapeContains
        [TestMethod()]
        public void TestCheckShapeContains()
        {
            _model.CheckShapeContains(3, 4);
        }

        // TestSelectShape
        [TestMethod()]
        public void TestSelectShape()
        {
            _model.SelectShape(3, 4);
        }

        // TestDrawHint
        [TestMethod()]
        public void TestDrawHint()
        {
            Shape shape = new Rectangle();
            _model.DrawHint();
            _model.Hint = shape;
            _model.DrawHint();
            Assert.IsNull((Shape)_privateObject.GetFieldOrProperty("_hint"));
            Assert.IsTrue(_model.CommandBindingObject.IsUndoEnabled);
        }

        // TestSetSelectionMode
        [TestMethod()]
        public void TestSetSelectionMode()
        {
            _model.SetSelectionMode();
            Assert.IsInstanceOfType(_model.CurrentState, typeof(SelectionState));
        }

        // TestSetDrawShapeMode
        [TestMethod()]
        public void TestSetDrawShapeMode()
        {
            _model.SetDrawShapeMode(ShapeType.Rectangle);
            Assert.IsInstanceOfType(_model.CurrentState, typeof(DrawShapeState));
            Assert.AreEqual(ShapeType.Rectangle, ((DrawShapeState)_model.CurrentState).DrawShapeType);

            _model.SetDrawShapeMode(ShapeType.Triangle);
            Assert.IsInstanceOfType(_model.CurrentState, typeof(DrawShapeState));
            Assert.AreEqual(ShapeType.Triangle, ((DrawShapeState)_model.CurrentState).DrawShapeType);
        }

        // TestSetDrawLineMode
        [TestMethod()]
        public void TestSetDrawLineMode()
        {
            _model.SetDrawLineMode();
            Assert.IsInstanceOfType(_model.CurrentState, typeof(DrawLineState));
        }
    }
}