using Bricks.Classes;

namespace Bricks.Interfaces
{
    interface IMenu
    {
        void GameProcess();
        void InputNumber(Brick[] bricks, string number);
        Game Game { get; set; }
    }
}
