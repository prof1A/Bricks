using Bricks.Classes;

namespace Bricks.Interfaces
{
    interface IMenuFunction
    {
        void ShowField(Field field);

        void CreateField(Game game, int height, int width);

        bool Win(Brick[] bricks);

        void InputNumber(Game game, string number);
    }
}
