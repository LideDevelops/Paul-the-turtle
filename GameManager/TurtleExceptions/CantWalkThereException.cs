using System;

namespace GameManager.TurtleExceptions
{
    public class CantWalkThereException : Exception
    {
        public CantWalkThereException(int x, int y) : base($"Can't walk to this tile on position ({x}, {y})")
        {
        }

        public CantWalkThereException(uint x, uint y) : base($"Can't walk to this tile on position ({x}, {y})")
        {
        }
    }
}