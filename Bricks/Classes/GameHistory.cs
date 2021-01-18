using System.Collections.Generic;

namespace Bricks.Classes
{
    public class GameHistory
    {
        public Stack<Brick[]> History { get; }
        public GameHistory()
        {
            History = new Stack<Brick[]>();
        }
    }
}
