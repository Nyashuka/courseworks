using System;
using System.Collections.Generic;
using System.IO;
 
namespace MazeRenderWF
{ 
    public class Maze
    {
        
        //координати гравця, звідки буде почато пошук(старт)
        private Point _player;
        //graph[i,j] - index це вершина
        //значення це довжина кроку від старту
        private int[,] _matrix;
        //координати виходів
        private List<Point> _exits = new List<Point>();
        //історія роботи алгоритму пошуку в ширину
        //потрібно щоб правильно відмалювати
        private Queue<Point> _BFSHistory = new Queue<Point>();

        public Maze(string side, string freeWave, string player, string filePath)
        {
            CreateAdjacencyMatrix(side, freeWave, player, filePath);
        }
     

        public Point GetStartCoordinate()
        {
            return new Point(_player.X, _player.Y);
        }

        public Queue<Point> GetPathesForRenderer()
        {
            return _BFSHistory;
        }

        private void CreateAdjacencyMatrix(string side, string freeWave, string player, string filePath)
        {
            int[] size = GetMazeSizeFromTxt(filePath);

            _matrix = new int[size[0], size[1]];

            using (StreamReader reader = new StreamReader(filePath))
            {
                int i = 0;
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    for (int j = 0; j < line.Length; j++)
                    {
                        string currentCell = Convert.ToString(line[j]);
                        if (currentCell == side)
                            _matrix[i, j] = -1;
                        else if (currentCell == freeWave)
                            _matrix[i, j] = 0;
                        if (currentCell == player)
                            _player = new Point(i, j);
                    }

                    i++;
                }
            }
        }


        private int[] GetMazeSizeFromTxt(string path)
        {
            int[] size = new int[2];

            using (StreamReader file = new StreamReader(path))
            {
                size[1] = file.ReadLine().Length;

                int rows = 1;

                while (file.ReadLine() != null)
                {
                    rows++;
                }

                size[0] = rows;
            }

            return size;
        }


        public Point[] GetNearestElements(Point node)
        {
            Point[] points = new Point[4];

            points[0] = new Point(node.X, node.Y - 1);
            points[1] = new Point(node.X, node.Y + 1);
            points[2] = new Point(node.X - 1, node.Y);
            points[3] = new Point(node.X + 1, node.Y);

            return points;
        }


        public int[,] Bfs()
        {
            Queue<Point> queue = new Queue<Point>();

            queue.Enqueue(_player);

            _BFSHistory.Enqueue(_player);

            while (queue.Count != 0)
            {
                Point currentNode = queue.Peek();

                queue.Dequeue();

                Point[] points = GetNearestElements(currentNode);

                for (int i = 0; i < points.Length; i++)
                {
                    if (CoordinateExistence(points[i]))
                    {
                        if (_matrix[points[i].X, points[i].Y] == 0 && points[i] != _player)
                        {
                            if (IsEdgeOfTheMaze(points[i]))
                            {
                                _exits.Add(points[i]);
                            }

                            _matrix[points[i].X, points[i].Y] = _matrix[currentNode.X, currentNode.Y] + 1;

                            _BFSHistory.Enqueue(points[i]);
                            queue.Enqueue(points[i]);
                        }                       
                    }
                }
            }
            return _matrix;
        }

        private bool IsEdgeOfTheMaze(Point point)
        {
            return (
                    point.X == 0 ||
                    point.Y == 0 ||
                    point.X == _matrix.GetLength(0) - 1 ||
                    point.Y == _matrix.GetLength(1) - 1
                   );

        }

        private bool CoordinateExistence(Point point)
        {
            return (
                    point.X >= 0 &&
                    point.X < _matrix.GetLength(0) &&
                    point.Y >= 0 &&
                    point.Y < _matrix.GetLength(1)
                   );
        }

        // через отдельный лист выходов которые задаются в бфс
        // переделать на обход краёв лабиринта
        private Point GetShotestExit()
        {
            Point shortestExit = _exits[0];
            int currentShortestLength = _matrix[_exits[0].X, _exits[0].Y];

            for (int i = 0; i < _exits.Count; i++)
            {
                int currentPath = _matrix[_exits[i].X, _exits[i].Y];
                if (currentPath < currentShortestLength)
                {
                    shortestExit = _exits[i];
                    currentShortestLength = currentPath;
                }
            }

            return shortestExit;
        }


        public Point[] GetShortestPath()
        {
            Point currentNode = GetShotestExit();
            int currentPathNumber = _matrix[currentNode.X, currentNode.Y]; // length of the last coordinate of the shortest exit
            Point[] path = new Point[currentPathNumber + 1]; // +1 because counting start with zero
            path[0] = currentNode;       

            int index = 1;
            while (currentPathNumber != 0)
            {
                Point[] points = GetNearestElements(currentNode);

                for (int i = 0; i < points.Length; i++)
                {
                    if (CoordinateExistence(points[i]))
                    {
                        int searchedNumberPath = _matrix[points[i].X, points[i].Y];
                        if (currentPathNumber - 1 == searchedNumberPath)
                        {
                            currentNode = points[i];
                            currentPathNumber = searchedNumberPath;
                            path[index] = points[i];
                            index++;
                            break;
                        }
                    }
                }
            }

            return path;
        }   

    }
}
