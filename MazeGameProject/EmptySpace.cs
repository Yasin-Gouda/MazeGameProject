using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGameProject
{
    public class EmptySpace : IMazeObject
    {
        public char Pixel { get => ' ';}
        public bool isSolid { get => false; }
    }
}
