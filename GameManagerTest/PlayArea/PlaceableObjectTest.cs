using com.theTurtlePaul.PlayerArea.GameManager;
using GameManager;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameManagerTest.PlayArea
{
    public class PlaceableObjectTest
    {
        private PlaceableObject testee;

        public PlaceableObjectTest()
        {
            testee = new BasicWall();
        }

        [Fact]
        public void IsPassableTest()
        {
            Assert.False(testee.CanWalkThrough());
        }

        [Fact]
        public void SetAndGetName()
        {
            testee.Name = "Wall";
            Assert.Equal("Wall", testee.Name);
        }
    }
}