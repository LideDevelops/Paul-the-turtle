namespace GameManager.PlayerArea
{
    public interface Transform
    {
        Position Position { get; }

        Rotation Rotation { get; }

        void RotateAroundX(float degree);

        void RotateAroundY(float degree);

        void RotateAroundZ(float degree);

        void PlaceAt(int x, int y, int z);
    }
}