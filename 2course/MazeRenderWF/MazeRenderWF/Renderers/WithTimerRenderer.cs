using System;
using System.Collections.Generic;
using System.Drawing;

namespace MazeRenderWF
{
    public class WithTimerRenderer
    {
        private Point[] _shortestPath;
        private Queue<Point> _nextSteps;
        private int[,] _markedGraph;
        private Graphics _graphics;
        private Maze _maze;
        private Font _font = new Font("Arial", 18);
        private Brush _brushForMarkers = Brushes.Green;
        private Brush _brushForShortestPath = Brushes.Red;

        public WithTimerRenderer(Graphics graphics, Maze maze)
        {
            _graphics = graphics;
            _maze = maze;
            _markedGraph = _maze.Bfs();
            _nextSteps = _maze.GetPathesForRenderer();
            _shortestPath = _maze.GetShortestPath();
        }

        public void ShowWalls()
        {
            for (int i = 0; i < _markedGraph.GetLength(0); i++)
            {
                for (int j = 0; j < _markedGraph.GetLength(1); j++)
                {
                    if (_markedGraph[i, j] == -1)
                        _graphics.FillRectangle(Brushes.Black, j * 50, i * 50, 50, 50);
                }
            }
        }

        public bool ShowPathLengths()
        {
            while (_nextSteps.Count != 0)
            {
                Point currentNode = _nextSteps.Peek();

                _nextSteps.Dequeue();
                if (IsShortestPath(currentNode))
                {
                    _graphics.DrawString(
                                   Convert.ToString(_markedGraph[currentNode.X, currentNode.Y]),
                                   _font, _brushForShortestPath,
                                   currentNode.Y * 50, currentNode.X * 50, new StringFormat()
                                  );
                }
                else
                {
                    _graphics.DrawString(
                                    Convert.ToString(_markedGraph[currentNode.X, currentNode.Y]),
                                    _font, _brushForMarkers,
                                    currentNode.Y * 50, currentNode.X * 50, new StringFormat()
                                   );
                }
                if (IsFoundEndOfShortestPath(currentNode))
                    break;

                return false;
            }

            return true;
        }


        public void ShowShortestPath()
        {
            for (int i = 0; i < _shortestPath.Length; i++)
            {
                _graphics.DrawString(
                                    Convert.ToString(_markedGraph[_shortestPath[i].X, _shortestPath[i].Y]),
                                    _font, _brushForShortestPath,
                                    _shortestPath[i].Y * 50, _shortestPath[i].X * 50, new StringFormat()
                                   );
            }
        }

        private bool IsShortestPath(Point point)
        {
            for (int i = 0; i < _shortestPath.Length; i++)
            {
                if (_shortestPath[i] == point)
                    return true;
            }
            return false;
        }

        private bool IsFoundEndOfShortestPath (Point point)
        {
            return _shortestPath[0] == point;
        }
    }
}
