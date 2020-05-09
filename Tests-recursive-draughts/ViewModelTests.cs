using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using recursive_draughts.architecture;

namespace Tests_recursive_draughts
{
    [TestFixture]
    class ViewModelTests
    {
        [Test]
        public void ShouldInitialize()
        {
            ViewModel classUnderTest = new ViewModel();
        }
        [Test]
        public void ShouldChangeDisplayToTest()
        {
            ViewModel classUnderTest = new ViewModel();

            classUnderTest.cmdStartExecution.Execute(classUnderTest.cmdStartExecution);

            var expected = "test1";

            Assert.AreEqual(expected, classUnderTest.Display);
        }
        [Test]
        public void ShouldMakeANewGame()
        {
            ViewModel classUnderTest = new ViewModel();
            classUnderTest.cmdStartNewGame.Execute(classUnderTest.cmdStartNewGame);

        }

    }
}
