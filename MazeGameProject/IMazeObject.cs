using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGameProject
{
    public interface IMazeObject
    {
        char Pixel { get; }
        bool isSolid { get; }



    }
}
