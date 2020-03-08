using GameManager;
using GameManager.PlayerArea;
using Xunit;

namespace GameManagerTest.PlayArea.Placeables
{
    public class Transform2DGridTest
    {
        private Transform testee;

        public Transform2DGridTest()
        {
            testee = new Transform2DGrid(0, 0);
        }

        [Fact]
        public void RotateTest()
        {
            testee.RotateAroundY(90);
            Assert.Equal(90, testee.Rotation.DegreeRotatedOnY);
            testee.RotateAroundY(270);
            Assert.Equal(0, testee.Rotation.DegreeRotatedOnY);
            testee.RotateAroundY(-270);
            Assert.Equal(90, testee.Rotation.DegreeRotatedOnY);
            testee.RotateAroundY(95);
            Assert.Equal(180, testee.Rotation.DegreeRotatedOnY);
        }
    }
}