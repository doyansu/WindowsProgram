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
    public class ClearCommandTests
    {
        ClearCommand _clearCommand;
        Shapes _shapes;
        Shape _shape;
        PrivateObject _privateObject;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _shape = new Rectangle();
            _shapes = new Shapes(new ShapeFactory());
            _shapes.Add(_shape);
            _clearCommand = new ClearCommand(_shapes);
            _privateObject = new PrivateObject(_clearCommand);
        }

        // TestDrawCommand
        [TestMethod()]
        public void TestDrawCommand()
        {
            Assert.AreEqual(_shapes, _privateObject.GetFieldOrProperty("_shapes"));
        }

        // TestExecute
        [TestMethod()]
        public void TestExecute()
        {
            _clearCommand.Execute();
            Assert.AreEqual(0, _shapes.Count);
            Assert.AreEqual(1, ((List<Shape>)_privateObject.GetFieldOrProperty("_shapeList")).Count);
        }

        // TestCancelExecute
        [TestMethod()]
        public void TestCancelExecute()
        {
            _clearCommand.Execute();
            _clearCommand.CancelExecute();
            Assert.AreEqual(1, _shapes.Count);
            Assert.AreEqual(0, ((List<Shape>)_privateObject.GetFieldOrProperty("_shapeList")).Count);
        }
    }
}