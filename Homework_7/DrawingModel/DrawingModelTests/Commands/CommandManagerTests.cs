using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Moq;

namespace DrawingModel.Commands.Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        CommandManager _commandManager;
        PrivateObject _privateObject;
        Mock<ICommand> _mockICommand;

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
            _commandManager = new CommandManager();
            _privateObject = new PrivateObject(_commandManager);
            _mockICommand = new Mock<ICommand>();
        }

        // TestExecute
        [TestMethod()]
        public void TestExecute()
        {
            _commandManager.Execute(_mockICommand.Object);
            _mockICommand.Verify(obj => obj.Execute(), Times.Exactly(1));
            Assert.IsTrue(_commandManager.IsUndoEnabled);
            Assert.IsFalse(_commandManager.IsRedoEnabled);
        }

        // TestUndo
        [TestMethod()]
        public void TestUndo()
        {
            Assert.ThrowsException<Exception>(_commandManager.Undo);
            _commandManager.Execute(_mockICommand.Object);
            _commandManager.Undo();
            Assert.IsFalse(_commandManager.IsUndoEnabled);
            Assert.IsTrue(_commandManager.IsRedoEnabled);
            Assert.AreEqual(0, ((Stack<ICommand>)_privateObject.GetFieldOrProperty("_undo")).Count);
            Assert.AreEqual(1, ((Stack<ICommand>)_privateObject.GetFieldOrProperty("_redo")).Count);
        }

        // TestRedo
        [TestMethod()]
        public void TestRedo()
        {
            Assert.ThrowsException<Exception>(_commandManager.Redo);
            _commandManager.Execute(_mockICommand.Object);
            _commandManager.Undo();
            _commandManager.Redo();
            Assert.AreEqual(1, ((Stack<ICommand>)_privateObject.GetFieldOrProperty("_undo")).Count);
            Assert.AreEqual(0, ((Stack<ICommand>)_privateObject.GetFieldOrProperty("_redo")).Count);
            Assert.IsTrue(_commandManager.IsUndoEnabled);
            Assert.IsFalse(_commandManager.IsRedoEnabled);
        }

        // TestNotifyPropertyChanged
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            List<string> receivedEvents = new List<string>();
            string propertyName = "test";
            _privateObject.Invoke("NotifyPropertyChanged", propertyName);
            Assert.AreEqual(0, receivedEvents.Count);
            _commandManager.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };
            _privateObject.Invoke("NotifyPropertyChanged", propertyName);
            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual(propertyName, receivedEvents[0]);
        }
    }
}