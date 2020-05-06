using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Xml;
using NuGet.Frameworks;
using NUnit.Framework;
using NUnit.Framework.Internal;
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
                Assert.Fail();
            }
            catch
            {

            }
        }
        [Test]
        public void ShouldAddNewPawn()
        {
            Pawn testPawn = new Pawn(Pawn.colours[0]);

            Field classUnderTest = new Field();
            
            try
            {
                classUnderTest.Pawn = testPawn;
            }
            catch
            {
                Assert.Fail();
            }
        }
        [Test]
        public void ShouldInsertWhitePawn()
        {
            TestAddPawn(Pawn.colours[0]);
        }
        [Test]
        public void ShoudInsertBlackPawn()
        {
            TestAddPawn(Pawn.colours[1]);
        }
        [Test]
        public void ShouldRemovePawn()
        {
            Pawn testPawn = new Pawn(Pawn.colours[0]);

            Field classUnderTest = new Field();

            try
            {
                classUnderTest.Pawn = null;
            }
            catch
            {
                Assert.Fail();
            }
        }
        [Test]
        public void ShouldReturnWhitePawn()
        {
            Pawn testPawn = new Pawn(Pawn.colours[0]);

            Field classUnderTest = new Field();

            classUnderTest.Pawn = testPawn;

            if(classUnderTest.Pawn.Colour == "WHITE")
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        private void TestAddPawn(string colour)
        {
            Pawn testPawn = new Pawn(colour);

            Field classUnderTest = new Field();

            try
            {
                classUnderTest.Pawn = testPawn;
            }
            catch
            {
                Assert.Fail();
            }
        }
        

    }
}
