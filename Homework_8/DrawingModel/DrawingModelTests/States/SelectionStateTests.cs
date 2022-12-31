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
    public class SelectionStateTests
    {
        Model _model;
        SelectionState _selectionState;
        PrivateObject _privateObject;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _selectionState = new SelectionState(_model);
            _privateObject = new PrivateObject(_selectionState);
        }

        // TestSelectionState
        [TestMethod()]
        public void TestSelectionState()
        {
            Assert.AreSame(_model, _privateObject.GetFieldOrProperty("_model"));
        }

        // TestPressPointer
        [TestMethod()]
        public void TestPressPointer()
        {
            _selectionState.PressPointer(3, 4);
        }

        // TestMovePointer
        [TestMethod()]
        public void TestMovePointer()
        {
            _selectionState.MovePointer(3, 4);
        }

        // TestReleasePointer
        [TestMethod()]
        public void TestReleasePointer()
        {
            _selectionState.ReleasePointer(3, 4);
        }
    }
}