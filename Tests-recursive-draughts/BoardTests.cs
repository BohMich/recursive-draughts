using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using recursive_draughts;
using System.Net.Mail;
using NUnit.Framework.Constraints;
using Moq;
using Newtonsoft.Json.Bson;

namespace Tests_recursive_draughts
{
    [TestFixture]
    class BoardTests
    {
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
            var classUnderTest = new Mock<Board>();
            classUnderTest.Object.GenerateNewBoard();
            
            return classUnderTest.Object;
        }
    }
}
