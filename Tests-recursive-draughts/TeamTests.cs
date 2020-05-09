using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Automation.Peers;
using Moq;
using NUnit.Framework;
using recursive_draughts;

namespace Tests_recursive_draughts
{
    [TestFixture]
    class TeamTests
    {
        [Test]
        public void ShouldInitialize()
        {
            Team classUnderTest = new Team();
        }
        [Test]
        public void ShouldAllocateNewSetOf20Pawns()
        {
            Team classUnderTest = new Team();
            classUnderTest.SetColour(Team._COLOURS[1]);
            classUnderTest.RestPawns();

            var expected = 20;

            Assert.AreEqual(expected, classUnderTest.Pawns.Count);
            
        }
        [Test]
        public void ShouldHavePawnID5AtPosition5()
        {
            CheckPositionForID(5,5);

        }
        [Test]
        public void ShouldHavePawnID19AtPosition19()
        {
            CheckPositionForID(19, 19);

        }
        [Test]
        public void ShouldRejectOutOfBoundsPawnId20AtPosition20()
        {
            try
            {
                CheckPositionForID(20, 20);
                Assert.Fail();
            }
            catch
            {
                
            }
        }
        [Test]
        public void ShouldCreateWhiteTeam()
        {
            Team classUnderTest = new Team();

            var expected = "WHITE";

            classUnderTest.SetColour(Team._COLOURS[0]);

            Assert.AreEqual(expected, classUnderTest.Colour);
        }
        [Test]
        public void ShouldCreateBlackTeam()
        {
            Team classUnderTest = new Team();
            var expected = "BLACK";

            classUnderTest.SetColour(Team._COLOURS[1]);

            Assert.AreEqual(expected, classUnderTest.Colour);
        }
        [Test]
        public void ShouldRejectChangingColour()
        {
            Team classUnderTest = new Team();
            classUnderTest.SetColour(Team._COLOURS[1]);

            try
            {
                classUnderTest.SetColour(Team._COLOURS[0]);
                Assert.Fail();
            }
            catch
            {

            }
        }
        [Test]
        public void ShouldRejectResetPawnsWhenNoTeamColourSet()
        {
            Team classUnderTest = new Team();

            try
            {
                classUnderTest.RestPawns();
                Assert.Fail();
            }
            catch
            {

            }
        }
        private void CheckPositionForID(int position, int id)
        {
            Team classUnderTest = new Team();
            classUnderTest.SetColour(Team._COLOURS[1]);
            classUnderTest.RestPawns();
            

            var expected = id;

            Assert.AreEqual(expected, classUnderTest.Pawns[position].Id);
        }

    }
}
