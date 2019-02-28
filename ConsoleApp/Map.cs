using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Map : IDrawer
    {
        public Map()
        {
            Height = 40;
            Width = 40;
        }
        public int Height { get; }

        public int Width { get; }

        public void Draw()
        {
            for (int i = Width; i >= 0; i--)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("*");
            }

            for (int i = Width; i >= 0; i--)
            {
                Console.SetCursorPosition(i, Height);
                Console.Write("*");
            }

            for (int i = Height; i >= 0; i--)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("*");
            }

            for (int i = Height; i >= 0; i--)
            {
                Console.SetCursorPosition(Width, i);
                Console.Write("*");
            }
        }
    }
}
