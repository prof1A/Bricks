using Bricks.Interfaces;

namespace Bricks.Classes
{
    class СreatorEazyMenu : ICreator
    {
        public IMenu CreateMenu()
        {
            return new EazyMenu(new Game());
        }
    }
}
