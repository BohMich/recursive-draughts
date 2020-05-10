
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using recursive_draughts;
using System.Security.RightsManagement;
using System.Security.Cryptography.X509Certificates;

namespace Tests_recursive_draughts
{
    [TestFixture]
    class GameTests
    {
        [Test]
       public void ShouldInitialize()
       {
            Game classUnderTest = new Game();
       }

        [Test]
        public void ShouldInstanciateAGame()
        {
            Game classUnderTest = new Game();

            try
            {
                classUnderTest.SetGame();
            }
            catch
            {
                Assert.Fail();
            }
        }
        [Test]
        public void ShouldHaveTwoTeamsAfterSetGame()
        {
            Game classUnderTest = new Game();
            classUnderTest.SetGame();

            var teams = classUnderTest.Teams;

            var expectedSize = 2;   //team white and team black

            Assert.AreEqual(expectedSize, teams.Count);
        }
        [Test]
        public void ShouldSetupGameOnlyOnce()
        {
            Game classUnderTest = new Game();
            classUnderTest.SetGame();

            try
            {
                classUnderTest.SetGame();
                Assert.Fail();
            }
            catch
            {

            }
        }
        [Test]
        public void ShouldHaveWhiteTeam()
        {
            CheckTeamColour(Team._COLOURS[0]);
        }
        [Test]
        public void ShouldHaveBlackTeam()
        {
            CheckTeamColour(Team._COLOURS[1]);
        }
        [Test]
        public void ShouldHaveOneWhiteOneBlack()
        {
            Game classUnderTest = new Game();
            classUnderTest.SetGame();

            var teams = classUnderTest.Teams;
            var white = teams.Find(x => x.Colour == Team._COLOURS[0]);
            var black = teams.Find(x => x.Colour == Team._COLOURS[1]);

            if(white == null  || black == null)
            {
                Assert.Fail();
            }
        }
        [Test]
        public void ShouldCreateNewBoard()
        {
            Game classUnderTest = new Game();
            classUnderTest.SetGame();

            if (classUnderTest.Board == null)
            {
                Assert.Fail();
            }
        }
        [Test]
        public void ShouldLoadTheBoardWithTeamPawns()
        {
            Game classUnderTest = new Game();

            try
            {
                classUnderTest.SetGame();
            }
            catch
            {
                Assert.Fail();
            }

        }


        private void CheckTeamColour(string colour)
        {
            Game classUnderTest = new Game();
            classUnderTest.SetGame();

            var actual = classUnderTest.Teams.Find(x => x.Colour == colour).Colour;

            var expectedSize = colour;   //team white and team black

            Assert.AreEqual(expectedSize, actual);
        }
    }
}
