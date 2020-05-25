using NUnit.Framework;
using recursive_draughts;
using Moq;
using recursive_draughts.architecture.DataObjects;

namespace Tests_recursive_draughts
{
    [TestFixture]
    class BoardTests
    {
        private Mock<IPawn> _mockPawn;
        private Mock<ITeam> _teamWhite;
        private Mock<ITeam> _teamBlack;


        [SetUp]
        public void TestsSetup()
        {
            _mockPawn = new Mock<IPawn>();
            _teamWhite = new Mock<ITeam>();
            _teamBlack = new Mock<ITeam>();
        }
           
        [Test]
        public void ShouldInitialize()
        {
            try
            {
                InitializeWithBoard();
            }
            catch
            {
                Assert.Fail();
            }
        }
        [Test]
        public void ShouldBuildNewBoard()
        {
            var classUnderTest = InitializeWithBoard();
        }
        [Test]
        public void ShouldLoadAllFields()
        {

            var classUnderTest = new Mock<Board>();
            var board = classUnderTest.Object;
            board.GenerateNewBoard();

            if(board.IsLoaded() == false)
            {
                Assert.Fail();
            }
           
        }
        [Test]
        public void ShouldReturnField0x0()
        {
            CheckReturnFieldNxN(0, 0);
        }

        [Test]
        public void ShouldReturnField9x9()
        {
            CheckReturnFieldNxN(9, 9);
        }
        [Test]
        public void ShouldFailOutOfBoundsLessThanZero()
        {
            CheckFailTryCatch(-1, -1);
        }
        [Test]
        public void ShouldFailOutOfBoundsMoreThanNine()
        {
            CheckFailTryCatch(10, 10);
        }
        [Test]
        public void ShouldPassPosition5x5()
        {
            try
            {
                CheckReturnFieldNxN(5,5);
            }
            catch
            {
                Assert.Fail();
            }
        }
        [Test]
        public void ShouldFailXOutofBounds()
        {
            CheckFailTryCatch(11, 0);
        }
        [Test]
        public void ShouldFailYOutofBounds()
        {
            CheckFailTryCatch(1, 11);
        }
        [Test]
        public void ShouldAddPawnCheckByID()
        {
            //Test pawn by checking ID
            var classUnderTest = InitializeWithBoard();
          
            _mockPawn.Setup(m => m.Id).Returns(1);
            _mockPawn.Setup(m => m.Colour).Returns(Team._COLOURS[0]);

            classUnderTest.AddPawn(0, 0, _mockPawn.Object);
            var expectedID = 1;

            Assert.AreEqual(expectedID, classUnderTest.Fields[0, 0].Pawn.Id);
        }
        [Test]
        public void ShouldAddPawnCheckByColour()
        {
            //Test pawn by checking ID
            var classUnderTest = InitializeWithBoard();

            _mockPawn.Setup(m => m.Id).Returns(1);
            _mockPawn.Setup(m => m.Colour).Returns(Team._COLOURS[0]);

            classUnderTest.AddPawn(0, 0, _mockPawn.Object);
            var expectedColour = Team._COLOURS[0];

            Assert.AreEqual(expectedColour, classUnderTest.Fields[0, 0].Pawn.Colour);
        }
        [Test]
        public void ShouldAddAllWhiteAndBlackPawns()
        {
            Team testWhite = new Team();
            testWhite.SetColour(Team._COLOURS[0]);
            testWhite.RestPawns();

            Team testBlack = new Team();
            testBlack.SetColour(Team._COLOURS[1]);
            testBlack.RestPawns();


            var classUnderTest = InitializeWithBoard();
            classUnderTest.GenerateNewBoard();

            

            classUnderTest.AddAllPawns(testWhite.Pawns, testBlack.Pawns);

            var actual = classUnderTest.GetPawns().Count;
            var expected = 40; //20 for each team;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ShouldReturnPos0x0AsEmpty()
        {
            var position = CheckPawnPosition(0, 0);
            if(position.Pawn != null)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void ShouldReturnPos0x1AsBlackPawn()
        {
            var position = CheckPawnPosition(0, 1);
            var expected = Team._COLOURS[1];
            var actual = position.Pawn.Colour;

            Assert.AreEqual(expected, actual);

        }
        [Test]
        public void ShouldReturnPos4x9AsEmpty()
        {
            var position = CheckPawnPosition(4, 9);
            if (position.Pawn != null)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void ShouldReturnPos9x9AsEmpty()
        {
            var position = CheckPawnPosition(9, 9);
            if (position.Pawn != null)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void ShouldReturnPos0x4AsEmpty()
        {
            var position = CheckPawnPosition(0, 4);
            if (position.Pawn != null)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void ShouldReturnPos0x3AsBlackPawn()
        {
            var position = CheckPawnPosition(0, 3);
            var expected = Team._COLOURS[1].ToString();
            var actual = position.Pawn.Colour.ToString();

            Assert.AreEqual(expected, actual);

        }
        public IField CheckPawnPosition(int x, int y)
        {
            Team testWhite = new Team();
            testWhite.SetColour(Team._COLOURS[0]);
            testWhite.RestPawns();

            Team testBlack = new Team();
            testBlack.SetColour(Team._COLOURS[1]);
            testBlack.RestPawns();

            var classUnderTest = InitializeWithBoard();
            classUnderTest.GenerateNewBoard();

            classUnderTest.AddAllPawns(testWhite.Pawns, testBlack.Pawns);

            return classUnderTest.Fields[x, y];

        }
        [Test]
         public void ShouldReturnPawnCountOfPawnsOnTheBoardOnePawn()
         {
             var classUnderTest = InitializeWithBoard();
             classUnderTest.GetPawns();

            _mockPawn.Setup(m => m.Id).Returns(1);
            _mockPawn.Setup(m => m.Colour).Returns(Team._COLOURS[0]);

            classUnderTest.AddPawn(3, 3, _mockPawn.Object);
            var actual = classUnderTest.GetPawns().Count;
            var expected = 1;

            Assert.AreEqual(expected,actual);
        }

        private void CheckFailTryCatch(int x, int y)
        {
            try
            {
                CheckReturnFieldNxN(x, y);
                Assert.Fail();
            }
            catch
            {

            }
        }
        private void CheckReturnFieldNxN(int x, int y)
        {
            var classUnderTest = InitializeWithBoard();
            var actual = classUnderTest.Fields[x, y];

            int[] expected = { x, y };

            Assert.AreEqual(expected, actual.GetPosition());
        }
        private Board InitializeWithBoard()
        {
            var classUnderTest = new Board();
            classUnderTest.GenerateNewBoard();
            
            return classUnderTest;
        }
    }
}
