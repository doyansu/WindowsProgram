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
    public class ShapeFactoryTests
    {
        ShapeFactory _shapeFactory;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _shapeFactory = new ShapeFactory();
        }

        // Test Constructor ShapeFactory()
        [TestMethod()]
        public void TestShapeFactoryConstructor()
        {
            // ShapeFactory() now do nothing
        }

        // TestCreateShape
        [TestMethod()]
        public void TestCreateShape()
        {
            Shape shape;
            shape = _shapeFactory.CreateShape(ShapeType.Null);
            Assert.IsNull(shape);

            shape = _shapeFactory.CreateShape(ShapeType.Line);
            Assert.IsInstanceOfType(shape, typeof(Line));

            shape = _shapeFactory.CreateShape(ShapeType.Rectangle);
            Assert.IsInstanceOfType(shape, typeof(Rectangle));

            shape = _shapeFactory.CreateShape(ShapeType.Triangle);
            Assert.IsInstanceOfType(shape, typeof(Triangle));
        }
    }
}