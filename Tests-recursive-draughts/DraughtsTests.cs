using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using recursive_draughts;

namespace Tests_recursive_draughts
{
    [TestFixture]
    class DraughtsTests
    {
        [Test]
        public void ShouldInitialize()
        {
            Draughts classUnderTest = new Draughts();
        }
        [Test]
        public void ShouldStartANewGame()
        {
            Draughts classUnderTest = new Draughts();

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
