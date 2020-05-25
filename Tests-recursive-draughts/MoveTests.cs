using recursive_draughts.architecture.DataObjects;
using recursive_draughts;
using NUnit.Framework;
using Moq;
using System.Drawing;

namespace Tests_recursive_draughts
{
    class MoveTests
    {
        Board _board;
        Team _teamWhite;
        Team _teamBlack;

        Mock<IPawn> _pawn;

        [SetUp]
        public void Setup()
        {
            _teamWhite = new Team();
            _teamWhite.SetColour(Team._COLOURS[0]);
            _teamWhite.RestPawns();

            _teamBlack = new Team();
            _teamBlack.SetColour(Team._COLOURS[1]);
            _teamBlack.RestPawns();

            _board = new Board();
            _board.GenerateNewBoard();
            _board.AddAllPawns(_teamWhite.Pawns, _teamBlack.Pawns);
        }

        [Test]
        public void ShouldInitialize()
        {
            Move classUnderTest = new Move();
        }

        [Test]
        public void ShouldMoveBlackPawnAt0x3()
        {

            Move classUnderTest = new Move();
            var oldPosition = _board.Fields[0, 3];
            var newPosition = _board.Fields[1, 4]; //diagonal jump x+1 y+1

            var expected = _board.Fields[0, 3].Pawn;
            classUnderTest.MovePawn(_board, oldPosition, newPosition);
            var actual = _board.Fields[1, 4].Pawn;

            Assert.AreEqual(expected, actual); //pawn from old position should be found in the new position.
        }
        [Test]
        public void ShouldRemoveOriginalPosition()
        {

            Move classUnderTest = new Move();
            var oldPosition = _board.Fields[0, 3];
            var newPosition = _board.Fields[1, 4]; //diagonal jump x+1 y+1

            Pawn expected = null;
            classUnderTest.MovePawn(_board, oldPosition, newPosition);
            var actual = _board.Fields[0, 3].Pawn;

            Assert.AreEqual(expected, actual); //pawn from old position should be found in the new position.
        }
        [Test] 
        public void ShouldNotMoveIfCurrentPositionNotPawn()
        {
            Move classUnderTest = new Move();
            
            var oldPosition = _board.Fields[1, 4]; //empty field.
            var newPosition = _board.Fields[2, 5];


            try
            {
                classUnderTest.MovePawn(_board, oldPosition, newPosition);
                Assert.Fail();
            }
            catch
            {

            }
        }
        [Test]
        public void ShouldNotMoveIfNewPositionIsPawn()
        {
            Move classUnderTest = new Move();

            var oldPosition = _board.Fields[0, 3]; 
            var pawn = GetPawn(Team._COLOURS[0]);
            var newPosition = _board.Fields[1, 4];
            newPosition.Pawn = pawn.Object;  //fill the end position with a mock pawn.

            try
            {
                classUnderTest.MovePawn(_board, oldPosition, newPosition);
                Assert.Fail();
            }
            catch
            {

            }
        }
        [Test]
        public void ShouldNotMoveInNonDiagonalDirection()
        {
            Move classUnderTest = new Move();

            var oldPosition = _board.Fields[0, 3]; 
            var newPosition = _board.Fields[0, 4]; //non-diagonal movement

            try
            {
                classUnderTest.MovePawn(_board, oldPosition, newPosition);
                Assert.Fail();
            }
            catch
            {

            }
        }
        private Mock<IPawn> GetPawn(string colour)
        {
            Mock<IPawn> temp = new Mock<IPawn>();

            temp.Setup(m => m.Colour).Returns(colour);
            temp.Setup(m => m.Id).Returns(1);
            return temp;
        }
    }
}
