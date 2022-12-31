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
    public class DrawShapeStateTests
    {
        Model _model;
        DrawShapeState _drawShapeState;
        PrivateObject _privateObject;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _drawShapeState = new DrawShapeState(_model);
            _privateObject = new PrivateObject(_drawShapeState);
        }

        // TestDrawShapeState
        [TestMethod()]
        public void TestDrawShapeState()
        {
            Assert.AreEqual(ShapeType.Null, _drawShapeState.DrawShapeType);
        }

        // TestPressPointer
        [TestMethod()]
        public void TestPressPointer()
        {
            _drawShapeState.PressPointer(3, 4);
            Assert.AreEqual(3, (double)_privateObject.GetFieldOrProperty("_firstPointX"));
            Assert.AreEqual(4, (double)_privateObject.GetFieldOrProperty("_firstPointY"));
        }

        // TestMovePointer
        [TestMethod()]
        public void TestMovePointer()
        {
            _drawShapeState.DrawShapeType = ShapeType.Rectangle;
            _drawShapeState.MovePointer(4, 5);
            Shape hint = _model.Hint;
            Assert.IsInstanceOfType(hint, typeof(Rectangle));
            Assert.AreEqual(0, hint.StartX);
            Assert.AreEqual(0, hint.StartY);
            Assert.AreEqual(4, hint.EndX);
            Assert.AreEqual(5, hint.EndY);

            _drawShapeState.DrawShapeType = ShapeType.Triangle;
            _drawShapeState.MovePointer(4, 5);
            Assert.IsInstanceOfType(_model.Hint, typeof(Triangle));
            Assert.AreEqual(0, hint.StartX);
            Assert.AreEqual(0, hint.StartY);
            Assert.AreEqual(4, hint.EndX);
            Assert.AreEqual(5, hint.EndY);
        }

        // TestReleasePointer
        [TestMethod()]
        public void TestReleasePointer()
        {
            _drawShapeState.ReleasePointer(4, 5);
        }
    }
}