using NUnit.Framework;
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

    }
}
