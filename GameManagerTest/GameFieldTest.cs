using GameManager;
using Xunit;

namespace GameManagerTest
{
    public class GameFieldTest
    {
        private int fieldSize = 10;
        private GameField testee;

        public GameFieldTest()
        {
            testee = new GameField(fieldSize);
        }

        [Fact]
        public void CreateField()
        {
            Assert.Equal(fieldSize, testee.FieldSize);
        }
    }
}