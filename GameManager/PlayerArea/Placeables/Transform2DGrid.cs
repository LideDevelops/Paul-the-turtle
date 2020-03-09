using GameManager.PlayerArea;

namespace GameManager
{
    public class Transform2DGrid : Transform
    {
        private readonly float MaxRotaionDegree = 360;

        /// <summary>
        /// Rotations can only be performed on a multiple of the snap angle.
        /// </summary>
        private readonly float RotationSnapAngle = 90;

        public Transform2DGrid() : this(0, 0)
        {
        }

        public Transform2DGrid(int x, int y)
        {
            Position = new Position(x, y, 0);
            Rotation = new Rotation();
        }

        public Position Position { get; private set; }
        public Rotation Rotation { get; private set; }

        public Position GetNormalizedForwardPosition()
        {
            switch (Rotation.DegreeRotatedOnY)
            {
                case 0:
                    return new Position(Position.X, Position.Y + 1, Position.Z);

                case 90:
                    return new Position(Position.X + 1, Position.Y, Position.Z);

                case 180:
                    return new Position(Position.X, Position.Y - 1, Position.Z);

                case 270:
                    return new Position(Position.X - 1, Position.Y, Position.Z);

                default:
                    return Position;
            }
        }

        public void PlaceAt(int x, int y, int z)
        {
            Position.X = x;
            Position.Y = y;
            Position.Z = z;
        }

        public void PlaceAt(Position position)
        {
            PlaceAt(position.X, position.Y, position.Z);
        }

        public void RotateAroundX(float degree)
        {
            return; //Ignore rotation on the x axis
        }

        public void RotateAroundY(float degree)
        {
            degree = ReduceDegreeToSnapAngle(degree);
            Rotation.DegreeRotatedOnY = (Rotation.DegreeRotatedOnY + degree) % MaxRotaionDegree;
            if (Rotation.DegreeRotatedOnY < 0)
            {
                Rotation.DegreeRotatedOnY += MaxRotaionDegree;
            }
        }

        public void RotateAroundZ(float degree)
        {
            return; //Ignore rotation on the z axis
        }

        private float ReduceDegreeToSnapAngle(float degree)
        {
            return degree - (degree % RotationSnapAngle);
        }
    }
}