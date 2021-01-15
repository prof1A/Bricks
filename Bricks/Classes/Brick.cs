namespace Bricks.Classes
{
    public class Brick
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
