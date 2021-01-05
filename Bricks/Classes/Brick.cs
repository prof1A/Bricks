using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks.Classes
{
    class Brick
    {
        public string Symbol { get; set; }
        public Brick(string symbol)
        {
            Symbol = symbol;
        }
        public override string ToString()
        {
            return Symbol;
        }
    }
}
