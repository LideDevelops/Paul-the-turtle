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

        public void PlaceAt(int x, int y, int z)
        {
            Position.X = x;
            Position.Y = y;
            Position.Z = z;
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