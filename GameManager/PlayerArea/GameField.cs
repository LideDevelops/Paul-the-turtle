using System;
using System.Collections.Generic;

namespace com.theTurtlePaul.PlayerArea.GameManager
{
    public class GameField
    {
        private int fieldSize;

        public GameField(int size)
        {
            FieldSize = size;
        }

        public int FieldSize { get => fieldSize; set => fieldSize = value; }
    }
}