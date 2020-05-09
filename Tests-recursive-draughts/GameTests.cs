using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using recursive_draughts;

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
    }
}
