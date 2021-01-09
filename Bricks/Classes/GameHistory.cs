using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks.Classes
{
    class GameHistory
    {
        public Stack<Field> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<Field>();
        }
    }
}
