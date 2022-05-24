using System;

namespace ConsoleApp1
{
    class Program {

        // Constants for the game rules.
        private const int Height = 20;
        private const int Width = 60;

        private static void Main(string[] args) {
            var sim = new LifeSimulation(Height, Width);

            while (true) {
                sim.DrawAndGrow();

                // Give the user a chance to view the game in a more reasonable speed.
                System.Threading.Thread.Sleep(100);
            }
        }
    }

    public class LifeSimulation {
        private readonly int _height;
        private readonly int _width;
        private Cell[,] _cells;

        public LifeSimulation(int height, int width) {
            _height = height;
            _width = width;
            _cells = new Cell[height, width];
            GenerateField();
        }

        public void DrawAndGrow() {
            DrawGame();
            Grow();
        }

        private void Grow()
        {
            var difference = 0;
            var nextGen = new Cell[_height,_width];

            for (var i = 0; i < _height; i++) {
                for (var j = 0; j < _width; j++) {
                    var n = CountLiveNeighbors(i, j);
                    var c = _cells[i, j];

                    nextGen[i, j] = Conways.Execute(c, n);
                    if (nextGen[i, j] != _cells[i, j])
                    {
                        difference++;
                    }
                }
            }

            _cells = nextGen;

            if (difference < _height * _width * .01)
            {
                GenerateField((int)(_height * _width * .05));
            }
        }

        private int CountLiveNeighbors(int x, int y)
        {
            var numOfAliveNeighbors = 0;

            for (var i = x - 1; i < x + 2; i++) {
                for (var j = y - 1; j < y + 2; j++)
                {
                    if ((i < 0 || j < 0) || (i >= _height || j >= _width)) continue;
                    if ((i == x) && (j == y)) continue;
                    if (_cells[i, j] == Cell.Alive) numOfAliveNeighbors++;
                }
            }
            return numOfAliveNeighbors;
        }

        private void DrawGame() {
            for (var i = 0; i < _height; i++) {
                for (var j = 0; j < _width; j++) {
                    Console.Write(_cells[i, j] == Cell.Alive ? "*" : " ");
                    if (j == _width - 1) Console.WriteLine("\r");
                }
            }
            Console.SetCursorPosition(0, Console.WindowTop);
        }

        private void GenerateField(int maxGen = int.MaxValue) {
            var generator = new Random();
            for (var i = 0; i < _height; i++) {
                for (var j = 0; j < _width; j++)
                {
                    if (maxGen <= 0)
                    {
                        return;
                    }

                    _cells[i, j] = generator.Next(3) != 1
                        ? Cell.Alive
                        : Cell.Dead;

                    if (_cells[i, j] == Cell.Alive)
                    {
                        maxGen--;
                    }
                }
            }
        }
    }
}
