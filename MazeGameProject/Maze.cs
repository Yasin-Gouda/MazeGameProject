using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MazeGameProject
{
    public class Maze
    {
        
        private Player _Player;
        private int _Width { get; set; }
        private int _Height { get; set; }
        private IMazeObject[,] _MazeObjects;

        public Maze(int width, int height)
        {
            _Width = width;
            _Height = height;
            _MazeObjects = new IMazeObject[width, height];
            _Player = new Player()
            {
                X = 1,
                Y = 1
            };
        }

        public void MovePlayer()
        {
            ConsoleKeyInfo UserInput = Console.ReadKey();
            ConsoleKey Key = UserInput.Key;

            while (Key != ConsoleKey.UpArrow && Key != ConsoleKey.DownArrow && Key != ConsoleKey.LeftArrow && Key != ConsoleKey.RightArrow)
            {
                Console.WriteLine("please only use the Arrow Keys to move");
                UserInput = Console.ReadKey();
                Key = UserInput.Key;
            }

            switch (Key)
            {
                case ConsoleKey.UpArrow: // decrease y value
                    UpdatePlayerPosition(0,-1);
                    break;
                case ConsoleKey.DownArrow: // increase y value
                    UpdatePlayerPosition(0,1);
                    break;
                case ConsoleKey.LeftArrow: // decrese x
                    UpdatePlayerPosition(-1,0);
                    break;
                case ConsoleKey.RightArrow: // increase x
                    UpdatePlayerPosition(1,0);
                    break;
            }

        }

        public void DrawMaze()
        {
          
            Console.Clear();

            for (int y = 0; y < _Height; y++)
            {
                for (int x = 0; x < _Width; x++)
                {
                    if (x == 1 && y == _Height - 1)
                    {
                        _MazeObjects[x, y] = new EmptySpace();
                        Console.Write(_MazeObjects[x, y].Pixel + " ");
                    }
                    else if (x == 0 || y == 0 || x == _Width - 1 || y == _Height - 1)
                    {
                        _MazeObjects[x, y] = new Wall();
                        Console.Write(_MazeObjects[x, y].Pixel + " ");
                    }
                    else if (x == _Player.X && y == _Player.Y)
                    {
                        Console.Write(_Player.Pixel + " ");
                    }
                    else if (y % 2 == 0 && y != 0 && y != _Height - 1 && x != 0 && x != _Width - 1)
                    {
                        bool gapOnRight = (y / 2) % 2 == 0;
                        int gapX = gapOnRight ? _Width - 2 : 1;

                        if (x != gapX)
                        {
                            _MazeObjects[x, y] = new Wall();
                            Console.Write(_MazeObjects[x, y].Pixel + " ");
                        }
                        else
                        {
                            _MazeObjects[x, y] = new EmptySpace();
                            Console.Write(_MazeObjects[x, y].Pixel + " ");
                        }
                    }
                    else
                    {
                        _MazeObjects[x, y] = new EmptySpace();
                        Console.Write(_MazeObjects[x, y].Pixel + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        private void UpdatePlayerPosition(int dx, int dy)
        {
            int newX = _Player.X + dx;
            int newY = _Player.Y + dy;

            if (newX < _Width && newY < _Height && newX >= 0 && newY >= 0 && _MazeObjects[newX, newY].isSolid == false )
            {
                _Player.X = newX;
                _Player.Y = newY;
                DrawMaze();
            }

            if (_Player.X == 1 && _Player.Y == _Height - 1) // or (1, _Height-1) if you went with Option A
            {
                Console.Clear();
                Console.WriteLine("YOU WIN!");
                Environment.Exit(0);
            }

        }


    }
}
