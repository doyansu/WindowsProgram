using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingFormSpace.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using DrawingModel;
using System.ComponentModel;

namespace DrawingFormSpace.PresentationModel.Tests
{
    [TestClass()]
    public class FormPresentationModelTests
    {
        Model _model;
        FormPresentationModel _presentationModel;
        PrivateObject _privateObject;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _presentationModel = new FormPresentationModel(_model);
            _privateObject = new PrivateObject(_presentationModel);
        }

        // TestFormPresentationModel
        [TestMethod()]
        public void TestFormPresentationModel()
        {
            Assert.AreEqual(_model, _privateObject.GetFieldOrProperty("_model"));
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsLineButtonEnabled);
        }

        // TestHandleRectangleButtonClick
        [TestMethod()]
        public void TestHandleRectangleButtonClick()
        {
            _presentationModel.HandleRectangleButtonClick();
            Assert.IsFalse(_presentationModel.IsRectangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsLineButtonEnabled);
        }

        // TestHandleTriangleButtonClick
        [TestMethod()]
        public void TestHandleTriangleButtonClick()
        {
            _presentationModel.HandleTriangleButtonClick();
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
            Assert.IsFalse(_presentationModel.IsTriangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsLineButtonEnabled);
        }

        // TestHandleTriangleButtonClick
        [TestMethod()]
        public void TestHandleLineButtonClick()
        {
            _presentationModel.HandleLineButtonClick();
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
            Assert.IsFalse(_presentationModel.IsLineButtonEnabled);
        }

        // TestHandleClearButtonClick
        [TestMethod()]
        public void TestHandleClearButtonClick()
        {
            _presentationModel.HandleClearButtonClick();
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsLineButtonEnabled);
        }

        // TestHandleCanvasReleased
        [TestMethod()]
        public void TestHandleCanvasReleased()
        {
            IPoint point = new IPoint(3, 4);
            _presentationModel.HandleCanvasReleased((int)point.X, (int)point.Y);
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsLineButtonEnabled);
            _model.PressPointer(1, 1);
            _model.MovePointer((int)point.X, (int)point.Y);
            _presentationModel.HandleCanvasReleased((int)point.X, (int)point.Y);
            Assert.IsTrue(_presentationModel.IsRectangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsTriangleButtonEnabled);
            Assert.IsTrue(_presentationModel.IsLineButtonEnabled);
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            string propertyName = "test";
            _privateObject.Invoke("NotifyPropertyChanged", propertyName);
            Assert.AreEqual(0, receivedEvents.Count);
            _presentationModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            _privateObject.Invoke("NotifyPropertyChanged", propertyName);
            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual(propertyName, receivedEvents[0]);
        }
    }
}