namespace Bfs
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "labr.txt";
            Graph graph = new Graph("*", ".", path);
            var a = graph.Bfs(new Point(2, 4));
            graph.PrintLabyryntInConsole();

        }
    }
}
