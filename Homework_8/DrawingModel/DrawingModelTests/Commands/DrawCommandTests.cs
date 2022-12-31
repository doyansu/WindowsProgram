using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Commands.Tests
{
    [TestClass()]
    public class DrawCommandTests
    {
        DrawCommand _drawCommand;
        Model _model;
        Shapes _shapes;
        Shape _shape;
        PrivateObject _privateObject;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _shape = new Rectangle();
            _shapes = _model.ShapeBindingObject;
            _drawCommand = new DrawCommand(_model, _shape);
            _privateObject = new PrivateObject(_drawCommand);
        }

        // TestDrawCommand
        [TestMethod()]
        public void TestDrawCommand()
        {
            Assert.AreEqual(_model, _privateObject.GetFieldOrProperty("_model"));
            Assert.AreEqual(_shape, _privateObject.GetFieldOrProperty("_shape"));
        }

        // TestExecute
        [TestMethod()]
        public void TestExecute()
        {
            _drawCommand.Execute();
            Assert.IsTrue(_shapes.Contains(_shape));
        }

        // TestCancelExecute
        [TestMethod()]
        public void TestCancelExecute()
        {
            _drawCommand.Execute();
            _drawCommand.CancelExecute();
            Assert.IsFalse(_shapes.Contains(_shape));
        }
    }
}