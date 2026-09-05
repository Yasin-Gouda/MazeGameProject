using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGameProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Maze, Can you beat it ?");
            Console.WriteLine("use the arrow keys to move");
            Console.WriteLine("click on \"S\" to start");

            ConsoleKeyInfo UserInput = Console.ReadKey();
            ConsoleKey Key = UserInput.Key;

            while (Key != ConsoleKey.S)
            {
                Console.WriteLine();
                Console.WriteLine("do you want to play or not ?!");
                Console.WriteLine("click on S if you want to");
                UserInput = Console.ReadKey();
                Key = UserInput.Key;
            }

            if (Key == ConsoleKey.S)
            {


                Maze maze = new Maze(20, 20);
                bool IsOver = false;

                while (!IsOver)
                {
                    maze.DrawMaze();
                    maze.MovePlayer();
                }
            }
            
        }
    }
}
