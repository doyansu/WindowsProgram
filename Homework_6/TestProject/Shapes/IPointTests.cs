using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class IPointTests
    {
        IPoint _point;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            
        }

        // Test Constructor Point()
        [TestMethod()]
        public void TestIPoint()
        {
            _point = new IPoint();
            Assert.AreEqual(0, _point.X);
            Assert.AreEqual(0, _point.Y);
        }

        // Test Constructor Point(double, double)
        [TestMethod()]
        public void TestIPoint1()
        {
            double pointX = 10;
            double pointY = 5;
            _point = new IPoint(pointX, pointY);
            Assert.AreEqual(pointX, _point.X);
            Assert.AreEqual(pointY, _point.Y);
        }

        // Test Copy()
        [TestMethod()]
        public void TestCopy()
        {
            double pointX = 10;
            double pointY = 5;
            _point = new IPoint(pointX, pointY);
            IPoint copyPoint = _point.Copy();
            Assert.AreEqual(false, _point == copyPoint);
            Assert.AreEqual(copyPoint.X, _point.X);
            Assert.AreEqual(copyPoint.Y, _point.Y);
        }
    }
}