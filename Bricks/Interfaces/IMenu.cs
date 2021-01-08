using Bricks.Classes;

namespace Bricks.Interfaces
{
    interface IMenu
    {
        bool EndOfGame { get; set; }
        void GameProcess();
        void InputNumber(Brick[] bricks, string number);
        Game Game { get; set; }
    }
}
