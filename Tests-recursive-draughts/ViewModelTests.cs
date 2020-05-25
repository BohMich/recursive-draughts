using NUnit.Framework;
using NUnit.Framework.Constraints;
using recursive_draughts;
using recursive_draughts.architecture;
using recursive_draughts.architecture.DataObjects;

namespace Tests_recursive_draughts
{
    [TestFixture]
    class ViewModelTests
    {
        IDraughts _draughts;
        IGame _game;
        [SetUp]
        public void SetupTests()
        {
            _game = new Game();
            _draughts = new Draughts(_game);
        }
        [Test]
        public void ShouldInitialize()
        {
            ViewModel classUnderTest = new ViewModel(_draughts);
        }
        [Test]
        public void ShouldChangeDisplayToTest()
        {
            ViewModel classUnderTest = new ViewModel(_draughts);

            classUnderTest.cmdStartExecution.Execute(classUnderTest.cmdStartExecution);

            var expected = "test1";

            Assert.AreEqual(expected, classUnderTest.Display);
        }
        [Test]
        public void ShouldMakeANewGame()
        {
            ViewModel classUnderTest = new ViewModel(_draughts);
            classUnderTest.cmdStartNewGame.Execute(classUnderTest.cmdStartNewGame);

        }

        [Test]
        public void ShouldOutputWelcomeMessage()
        {
            ViewModel classUnderTest = new ViewModel(_draughts);
            classUnderTest.cmdStartNewGame.Execute(classUnderTest.cmdStartNewGame);

            var expected = "Welcome to draughts by Mike. \n Please choose your action.";
            var actual = classUnderTest.Output;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ShouldTakeUserInput()
        {
            ViewModel classUnderTest = new ViewModel(_draughts);
            classUnderTest.cmdSendRequest.Execute(classUnderTest.cmdSendRequest);
            

            var expected = "Test1";
            var actual = classUnderTest;
        }

    }
}
