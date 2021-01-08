namespace Bricks.Interfaces
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }
}
