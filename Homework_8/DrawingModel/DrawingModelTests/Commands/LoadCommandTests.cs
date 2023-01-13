using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel.GoogleDrive;
using Moq;

namespace DrawingModel.Commands.Tests
{
    [TestClass()]
    public class LoadCommandTests
    {
        LoadCommand _loadCommand;
        Model _model;
        Mock<IFileBaseService> _mockIFileBaseService;
        Shapes _shapes;
        Shape _shape;
        PrivateObject _privateObject;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _mockIFileBaseService = new Mock<IFileBaseService>();
            _model = new Model();
            _model.FileService = _mockIFileBaseService.Object;
            _shape = new Rectangle();
            _shapes = _model.ShapeBindingObject;
            _shapes.Add(_shape);
            _loadCommand = new LoadCommand(_model);
            _privateObject = new PrivateObject(_loadCommand);
        }

        // TestLoadCommand
        [TestMethod()]
        public void TestLoadCommand()
        {
            Assert.AreEqual(_model, _privateObject.GetFieldOrProperty("_model"));
        }

        // TestExecute
        [TestMethod()]
        public void TestExecute()
        {
            Shape loadShape = new Triangle();
            _mockIFileBaseService.Setup(obj => obj.ReadFile("DrawingShapes.txt")).Returns(loadShape.GetObjectString());
            _loadCommand.Execute();
            Assert.AreEqual(1, _shapes.Count);
            Shape loadShapeInModel = _shapes.GetBy(0);
            Assert.AreEqual(loadShape.StartX, loadShapeInModel.StartX);
            Assert.AreEqual(loadShape.StartY, loadShapeInModel.StartY);
            Assert.AreEqual(loadShape.EndX, loadShapeInModel.EndX);
            Assert.AreEqual(loadShape.EndY, loadShapeInModel.EndY);
            Assert.AreEqual(loadShape.GetType(), loadShapeInModel.GetType());
            List<Shape> shapeList = ((List<Shape>)_privateObject.GetFieldOrProperty("_shapeList"));
            Assert.AreEqual(1, shapeList.Count);
            Assert.ReferenceEquals(_shape, shapeList[0]);
        }

        // TestCancelExecute
        [TestMethod()]
        public void TestCancelExecute()
        {
            Shape loadShape = new Triangle();
            _mockIFileBaseService.Setup(obj => obj.ReadFile("DrawingShapes.txt")).Returns(loadShape.GetObjectString());
            _loadCommand.Execute();
            _loadCommand.CancelExecute();
            Assert.AreEqual(1, _shapes.Count);
            Assert.ReferenceEquals(_shape, _shapes.GetBy(0));
            List<Shape> shapeList = ((List<Shape>)_privateObject.GetFieldOrProperty("_shapeList"));
            Assert.AreEqual(1, shapeList.Count);
            Shape loadShapeInCommand = shapeList[0];
            Assert.AreEqual(loadShape.StartX, loadShapeInCommand.StartX);
            Assert.AreEqual(loadShape.StartY, loadShapeInCommand.StartY);
            Assert.AreEqual(loadShape.EndX, loadShapeInCommand.EndX);
            Assert.AreEqual(loadShape.EndY, loadShapeInCommand.EndY);
            Assert.AreEqual(loadShape.GetType(), loadShapeInCommand.GetType());

            _loadCommand.Execute();
            Assert.AreEqual(1, _shapes.Count);
            Shape loadShapeInModel = _shapes.GetBy(0);
            Assert.AreEqual(loadShape.StartX, loadShapeInModel.StartX);
            Assert.AreEqual(loadShape.StartY, loadShapeInModel.StartY);
            Assert.AreEqual(loadShape.EndX, loadShapeInModel.EndX);
            Assert.AreEqual(loadShape.EndY, loadShapeInModel.EndY);
            Assert.AreEqual(loadShape.GetType(), loadShapeInModel.GetType());
            Assert.AreEqual(1, shapeList.Count);
            Assert.ReferenceEquals(_shape, shapeList[0]);
        }
    }
}