using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.States.Tests
{
    [TestClass()]
    public class DrawLineStateTests
    {
        Model _model;
        DrawLineState _drawLineState;
        PrivateObject _privateObject;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _drawLineState = new DrawLineState(_model);
            _privateObject = new PrivateObject(_drawLineState);
        }

        // TestDrawLineState
        [TestMethod()]
        public void TestDrawLineState()
        {
            Assert.IsNull(_privateObject.GetFieldOrProperty("_firstShape"));
        }

        // TestPressPointer
        [TestMethod()]
        public void TestPressPointer()
        {
            Shape shape = new Rectangle(0, 0, 6, 6);
            _model.AddShape(shape);
            _drawLineState.PressPointer(3, 4);
            Assert.AreEqual(3, (double)_privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(4, (double)_privateObject.GetFieldOrProperty("_firstPointY"));
            Assert.AreSame(shape, _privateObject.GetFieldOrProperty("_firstShape"));
        }

        // TestMovePointer
        [TestMethod()]
        public void TestMovePointer()
        {
            _drawLineState.MovePointer(7, 8);
            Assert.IsNull(_privateObject.GetFieldOrProperty("_firstShape"));

            Shape startShape = new Rectangle(0, 0, 6, 6);
            _model.AddShape(startShape);
            _privateObject.SetFieldOrProperty("_firstShape", startShape);
            _drawLineState.MovePointer(7, 8);
            Shape shape = _model.Hint;
            Assert.IsInstanceOfType(shape, typeof(Line));
            Line line = (Line)shape;
            Assert.AreSame(startShape, line.StartShape);
            Shape endShape = line.EndShape;
            Assert.AreEqual(7, endShape.StartX);
            Assert.AreEqual(8, endShape.StartY);
            Assert.AreEqual(7, endShape.EndX);
            Assert.AreEqual(8, endShape.EndY);
        }

        // TestReleasePointer
        [TestMethod()]
        public void TestReleasePointer()
        {
            _drawLineState.ReleasePointer(8, 8);
            Assert.IsNull(_privateObject.GetFieldOrProperty("_firstShape"));

            Shape startShape = new Rectangle(0, 0, 6, 6);
            Shape endShape = new Rectangle(7, 7, 9, 9);
            _model.AddShape(startShape);
            _model.AddShape(endShape);
            _privateObject.SetFieldOrProperty("_firstShape", startShape);

            _drawLineState.ReleasePointer(100, 100);
            Assert.AreEqual(2, _model.ShapeBindingObject.Count);

            _drawLineState.ReleasePointer(8, 8);
            Assert.AreEqual(3, _model.ShapeBindingObject.Count);
            Shape shape = _model.ShapeBindingObject.GetBy(2);
            Assert.IsInstanceOfType(shape, typeof(Line));
            Line line = (Line)shape;
            Assert.AreSame(startShape, line.StartShape);
            Assert.AreSame(endShape, line.EndShape);
        }
    }
}