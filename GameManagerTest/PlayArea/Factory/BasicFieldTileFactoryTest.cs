using com.theTurtlePaul.PlayerArea.GameManager;
using com.theTurtlePaul.PlayerArea.GameManager.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace GameManagerTest.PlayArea.Factory
{
    public class BasicFieldTileFactoryTest
    {
        private FieldTileFactory testee;

        public BasicFieldTileFactoryTest()
        {
            testee = new BasicFieldTileFactory();
        }

        [Fact]
        public void CreateFieldTileTest()
        {
            Assert.NotNull(testee.CreateTile());
        }

        [Fact]
        public void CreateFieldTileListTest()
        {
            var actual = testee.CreateTileList(10);
            Assert.All(actual, x => Assert.NotNull(x));
            Assert.All(actual, x => Assert.Equal(typeof(BasicFieldTile), x.GetType()));
            Assert.NotEmpty(actual);
            Assert.Equal(10, actual.Count());
        }

        [Fact]
        public void CreateFieldTileListNegativTest()
        {
            var actual = testee.CreateTileList(-10);
            Assert.NotNull(actual);
            Assert.Empty(actual);
        }
    }
}