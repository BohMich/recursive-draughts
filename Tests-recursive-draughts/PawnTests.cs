using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using recursive_draughts;

namespace Tests_recursive_draughts
{
    [TestFixture]
    public class PawnTests
    {

        [Test]
        public void ShouldInitialize()
        {
            Pawn classUnderTest = new Pawn("black");
        }

        [Test]
        public void ShouldReturnColourBlack()
        {
            Pawn classUnderTest = new Pawn("black");

            var expectedColour = "black";
            var actualColour = classUnderTest.Colour;
            Assert.AreEqual(expectedColour, actualColour);
        }
        [Test]
        public void ShouldReturnColourWhite()
        {
            Pawn classUnderTest = new Pawn("white");

            var expectedColour = "white";
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
    }
}
