using Bricks.Interfaces;

namespace Bricks.Classes
{
    class CreatorHardMenu : ICreator
    {
        public IMenu CreateMenu()
        {
            return new HardMenu(new Game());
        }
    }
}
