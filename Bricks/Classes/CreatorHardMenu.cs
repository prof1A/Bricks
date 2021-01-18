using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bricks.Interfaces;

namespace Bricks.Classes
{
    class CreatorHardMenu : ICreator
    {
        public IMenu CreateMenu()
        {
            return new EazyMenu(new Game());
        }
    }
}
