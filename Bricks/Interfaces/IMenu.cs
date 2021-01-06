using Bricks.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks.Interfaces
{
    interface IMenu
    {
        bool EndOfGame { get; set; }
        void GameProcess();
    }
}
