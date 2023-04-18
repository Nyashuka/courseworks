using System;
using System.Collections.Generic;
using System.IO;


// Создать матрицу смежностей
// Вывод в консоль лабиринта по матрице смежностей
// матрица ходов 
// 


namespace Bfs
{
    public interface IGraphCreator
    {
        public List<int>[] FromTextMaze(StreamReader fileForRead);
    }

    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Point point1, Point point2)
        {
            return point1.X == point2.X && point1.Y == point2.Y;
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return point1.X != point2.X || point1.Y != point2.Y;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }

    class GraphCreator : IGraphCreator
    {

        public List<int>[] FromTextMaze(StreamReader file)
        {
            List<int>[] graph = new List<int>[4];

            return graph;
        }
    }


    public class Graph
    {
        //graph[i] - index это вершины
        //значение это вершины к которым соеденина вершина тобишь индекс
        private int[,] matrix;
        private List<Point> exits = new List<Point>();

        public Graph(string side, string freeWave, string path)
        {
            CreateAdjacencyMatrix(side, freeWave, path);
        }


        private void CreateAdjacencyMatrix(string side, string freeWave, string path)
        {
            int[] size = GetLabiryntSizeFromTxt(path);

            matrix = new int[size[0], size[1]];

            using (StreamReader reader = new StreamReader(path))
            {
                int i = 0;
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    for (int j = 0; j < line.Length; j++)
                    {
                        string currentCell = Convert.ToString(line[j]);
                        if (currentCell == side)
                            matrix[i, j] = -1;
                        else if (currentCell == freeWave)
                            matrix[i, j] = 0;
                    }
                    i++;
                }
            }
        }


        private int[] GetLabiryntSizeFromTxt(string path)
        {
            // size[0] = rows,  size[1] = cols
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





        public int[,] Bfs(Point start)
        {
            Queue<Point> queue = new Queue<Point>();

            queue.Enqueue(start);

            while (queue.Count != 0)
            {
                Point currentNode = queue.Peek();

                queue.Dequeue();

                Point[] points = GetNearestElements(currentNode);

                for (int i = 0; i < points.Length; i++)
                {
                    if (CoordinateExistence(points[i]))
                    {
                        if (matrix[points[i].X, points[i].Y] == 0 && points[i] != start)
                        {

                            if (IsEdgeOfTheLabyrinth(points[i]))
                            {
                                exits.Add(points[i]);
                            }
                            matrix[points[i].X, points[i].Y] = matrix[currentNode.X, currentNode.Y] + 1;
                            queue.Enqueue(points[i]);


                        }

                    }
                }
            }

            return matrix;
        }

        private bool IsEdgeOfTheLabyrinth(Point point)
        {
            if (
                point.X == 0 ||
                point.Y == 0 ||
                point.X == matrix.GetLength(0) - 1 ||
                point.Y == matrix.GetLength(1) - 1
               )
            {
                return true;
            }
            else return false;
        }

        private bool CoordinateExistence(Point point)
        {
            if (
                point.X >= 0 &&
                point.X < matrix.GetLength(0) &&
                point.Y >= 0 &&
                point.Y < matrix.GetLength(1)
              )
            {
                return matrix[point.X, point.Y] > -1;
            }
            return false;
        }

        // через отдельный лист выходов которые задаются в бфс
        // переделать на обход краёв лабиринта
        private Point FindShotestExit()
        {
            Point shortestExit = exits[0];
            int currentShortestLength = matrix[exits[0].X, exits[0].Y];

            for (int i = 0; i < exits.Count; i++)
            {
                int currentPath = matrix[exits[i].X, exits[i].Y];
                if (currentPath < currentShortestLength)
                {
                    shortestExit = exits[i];
                    currentShortestLength = currentPath;
                }
            }

            return shortestExit;
        }


        public Point[] GetShortestPath(Point goal)
        {
            int currentPathNumber = matrix[goal.X, goal.Y];
            Point[] path = new Point[currentPathNumber + 1];

            path[0] = goal;

            Point currentNode = goal;
            int index = 1;
            while (currentPathNumber != 0)
            {
                Point[] points = GetNearestElements(currentNode);

                for (int i = 0; i < points.Length; i++)
                {
                    if (CoordinateExistence(points[i]))
                    {
                        int searchedNumberPath = matrix[points[i].X, points[i].Y];
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


        public void PrintLabyryntInConsole()
        {
            Point[] shortestPath = GetShortestPath(FindShotestExit());

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == -1)
                        Console.Write(" # ");
                    else
                    {
                        bool isDelivered = false;
                        for (int k = 0; k < shortestPath.Length; k++)
                        {
                            Point tempPoint = new Point(i, j);
                            if (tempPoint == shortestPath[k])
                            {
                                Console.Write(" P ");
                                isDelivered = true;
                            }
                        }
                        if (!isDelivered)
                            Console.Write(" * ");
                    }
                    // Console.Write(" * ");
                }
                Console.WriteLine();
            }
        }

    }
}
