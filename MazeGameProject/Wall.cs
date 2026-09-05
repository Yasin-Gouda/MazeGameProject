using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGameProject
{
    public class Wall : IMazeObject
    {
        public char Pixel { get => '#'; }
        public bool isSolid { get => true; }
    }
}
