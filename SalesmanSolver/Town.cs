namespace SalesmanSolver
{
    internal class Town : Node
    {
        public Town(string name)
        {
            Name = name;
        }

        public Town(string name, int x, int y)
        {
            Name = name;
            X = x; Y = y;
        }

        public string Name { get; set; }
    }
}
