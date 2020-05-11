using NUnit.Framework;
using recursive_draughts;
using recursive_draughts.architecture.DataObjects;
namespace Tests_recursive_draughts
{
    [TestFixture]
    class DraughtsTests
    {
        IGame _game;

        [SetUp]
        public void setupTests()
        {
            _game = new Game();
        }
        [Test]
        public void ShouldInitialize()
        {
            Draughts classUnderTest = new Draughts(_game);
        }
        [Test]
        public void ShouldStartANewGame()
        {
            Draughts classUnderTest = new Draughts(_game);

            try
            {
                classUnderTest.StartNewGame();
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
