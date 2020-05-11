﻿using NUnit.Framework;
using recursive_draughts.architecture.DataObjects;

namespace Tests_recursive_draughts
{
    [TestFixture]
    public class PawnTests
    {

        [Test]
        public void ShouldInitialize()
        {
            Pawn classUnderTest = new Pawn(Team._COLOURS[1]);
        }

        [Test]
        public void ShouldReturnColourBlack()
        {
            Pawn classUnderTest = new Pawn(Team._COLOURS[1]);

            var expectedColour = "BLACK";
            var actualColour = classUnderTest.Colour;
            Assert.AreEqual(expectedColour, actualColour);
        }
        [Test]
        public void ShouldReturnColourWhite()
        {
            Pawn classUnderTest = new Pawn(Team._COLOURS[0]);

            var expectedColour = "WHITE";
            var actualColour = classUnderTest.Colour;
            Assert.AreEqual(expectedColour, actualColour);
        }
        [Test]
        public void ShouldRejectEmptyString()
        {
            try
            {
                Pawn classUnderTest = new Pawn("");
                Assert.Fail();
            }
            catch
            {

            }
        }
        [Test]
        public void ShouldRejectNull()
        {
            

            try
            {
                Pawn classUnderTest = new Pawn(null);
                Assert.Fail();
            }
            catch
            {

            }
        }
        [Test]
        public void ShouldRejectInvalidFormat()
        {
            try
            {
                Pawn classUnderTest = new Pawn("BlAck ");
                Assert.Fail();
            }
            catch
            {

            }
        }
        [Test] 
        public void ShouldSetID5()
        {
            Pawn classUnderTest = new Pawn(Team._COLOURS[0]);
            var expected = 5;

            classUnderTest.Id = 5;

            Assert.AreEqual(expected, classUnderTest.Id);
        }
        [Test]
        public void ShouldRejectNegativeID()
        {
            Pawn classUnderTest = new Pawn(Team._COLOURS[0]);
            
            try
            {
                classUnderTest.Id = -5;
                Assert.Fail();
            }
            catch
            {

            }
        }
    }
}
