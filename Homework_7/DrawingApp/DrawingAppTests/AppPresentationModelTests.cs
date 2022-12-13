using System;
using System.Collections.Generic;
using System.ComponentModel;
using DrawingApp.PresentationModel;
using DrawingModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DrawingAppTests
{
    [TestClass]
    public class AppPresentationModelTests
    {
        Model _model;
        AppPresentationModel _presentationModel;
        Mock<IGraphics> _mockIGraphics;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _mockIGraphics = new Mock<IGraphics>();
            _presentationModel = new AppPresentationModel(_model, _mockIGraphics.Object);
        }

        // TestFormPresentationModel
        [TestMethod()]
        public void TestFormPresentationModel()
        {
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
        }

        // TestHandleRectangleButtonClick
        [TestMethod()]
        public void TestHandleRectangleButtonClick()
        {
            _presentationModel.HandleRectangleButtonClick();
            Assert.IsFalse(_presentationModel.IsRectangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
            Assert.AreEqual(ShapeType.Rectangle, _model.DrawingShapeType);
        }

        // TestHandleTriangleButtonClick
        [TestMethod()]
        public void TestHandleTriangleButtonClick()
        {
            _presentationModel.HandleTriangleButtonClick();
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
            Assert.IsFalse(_presentationModel.IsTriangleButtonEnabled);
            Assert.AreEqual(ShapeType.Triangle, _model.DrawingShapeType);
        }

        // TestHandleClearButtonClick
        [TestMethod()]
        public void TestHandleClearButtonClick()
        {
            _presentationModel.HandleClearButtonClick();
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
            Assert.AreEqual(ShapeType.Null, _model.DrawingShapeType);
        }

        // TestHandleCanvasReleased
        [TestMethod()]
        public void TestHandleCanvasReleased()
        {
            IPoint point = new IPoint(3, 4);
            _presentationModel.HandleCanvasReleased((int)point.X, (int)point.Y);
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
            Assert.AreEqual(ShapeType.Null, _model.DrawingShapeType);
        }

        // TestDraw
        [TestMethod()]
        public void TestDraw()
        {
            _presentationModel.Draw();
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            string propertyName = "test";
            CallNonPublicMethod(_presentationModel, "NotifyPropertyChanged", new object[] { propertyName });
            Assert.AreEqual(0, receivedEvents.Count);
            _presentationModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            CallNonPublicMethod(_presentationModel, "NotifyPropertyChanged", new object[] { propertyName });
            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual(propertyName, receivedEvents[0]);
        }

        // CallNonPublicMethod
        private void CallNonPublicMethod(object o, string methodName, params object[] args)
        {
            var type = o.GetType();
            var mi = type.GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (mi != null)
            {
                mi.Invoke(o, args);
                return;
            }

            string error_message_format = "Method {0} does not exist on type {1}";
            throw new Exception(string.Format(error_message_format, methodName, type.ToString()));
        }

        /* https://stackoverflow.com/questions/60067717/privateobject-in-visual-studio
        public static T CallNonPublicMethod<T>(this object o, string methodName, params object[] args)
        {
            var type = o.GetType();
            var mi = type.GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (mi != null)
            {
                return (T)mi.Invoke(o, args);
            }

            throw new Exception($"Method {methodName} does not exist on type {type.ToString()}");
        }

        public static T CallNonPublicProperty<T>(this object o, string methodName)
        {
            var type = o.GetType();
            var mi = type.GetProperty(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (mi != null)
            {
                return (T)mi.GetValue(o);
            }

            throw new Exception($"Property {methodName} does not exist on type {type.ToString()}");
        }*/
    }
}