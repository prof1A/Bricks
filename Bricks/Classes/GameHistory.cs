using System.Collections.Generic;

namespace Bricks.Classes
{
    public class GameHistory
    {
        public Stack<Brick[]> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<Brick[]>();
        }
    }
}
