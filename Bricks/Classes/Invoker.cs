using Bricks.Interfaces;

namespace Bricks.Classes
{
    class Invoker
    {
        ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void Run()
        {
            command.Execute();
        }
    }
}
