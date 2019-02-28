using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    interface IDrawer
    {
        int Height { get; }
        int Width { get; }

        void Draw();
    }
}
