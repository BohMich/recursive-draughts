using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using recursive_draughts;

namespace Tests_recursive_draughts
{
    [TestFixture]
    class FieldTests
    {
        [Test]
        public void ShouldInitialize()
        {
            Field classUnderTest = new Field();
        }
        [Test]
        public void ShouldGetXas5()
        {
            Field classUnderTest = new Field();

            
            var expectedX = 5;
            var actualX = classUnderTest.X = 5;

            Assert.AreEqual(expectedX, actualX);
        }
        [Test]
        public void ShouldRejectNegativeX()
        {
            Field classUnderTest = new Field();

            try
            {
                classUnderTest.X = -5;
                Assert.Fail();
            }
            catch
            {

            }
            
        }
        [Test]
        public void ShouldRejectXAs10()
        {
            //The board size = 10x10 meaning no field will be bigger than boardX[9]
            Field classUnderTest = new Field();

            try
            {
                classUnderTest.X = 10;
                Assert.Fail();
            }
            catch
            {

            }
        }
        [Test]
        public void ShouldAcceptXAs9()
        {
            //test highest n as x
            Field classUnderTest = new Field();

            try
            {
                classUnderTest.X = 9;
            }
            catch
            {
                Assert.Fail();
            }
        }
        [Test]
        public void ShouldAcceptXAs0()
        {
            //test lowest n as x
            Field classUnderTest = new Field();

            try
            {
                classUnderTest.X = 0;
            }
            catch
            {
                Assert.Fail();
            }
        }
        [Test]
        public void ShouldGetYas8()
        {
            Field classUnderTest = new Field();

            var expectedY = 8;
            var actualY = classUnderTest.Y = 8;

            Assert.AreEqual(expectedY, actualY);
        }
        [Test]
        public void ShouldAcceptYAs9()
        {
            //test highest n as y
            Field classUnderTest = new Field();

            try
            {
                classUnderTest.Y = 9;
            }
            catch
            {
                Assert.Fail();
            }
        }
        [Test]
        public void ShouldAcceptYAs0()
        {
            //test lowest n as y
            Field classUnderTest = new Field();

            try
            {
                classUnderTest.Y = 0;
            }
            catch
            {
                Assert.Fail();
            }
        }
        [Test]
        public void ShouldRejectYAsNegative()
        {
            //test lowest n as y
            Field classUnderTest = new Field();

            try
            {
                classUnderTest.Y = -3;
            }
            catch
            {
                Assert.Fail();
            }
        }
    }
}
