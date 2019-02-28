using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Menu : IDrawer
    {
        public int Height { get; } = 10;

        public int Width { get; } = 100;

        public void Draw()
        {
            for (int i = Width; i >= 45; i--)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("*");
            }

            for (int i = Width; i >= 45; i--)
            {
                Console.SetCursorPosition(i, Height);
                Console.Write("*");
            }

            for (int i = Height; i > 0; i--)
            {
                Console.SetCursorPosition(45, i);
                Console.Write("*");
            }

            for (int i = Height; i > 0; i--)
            {
                Console.SetCursorPosition(Width, i);
                Console.Write("*");
            }

        }
    }
}
