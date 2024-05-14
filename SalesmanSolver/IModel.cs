using System.Numerics;

namespace SalesmanSolver
{
    internal interface IModel
    {
        public string SolveGraph();
        public void AddTown(Node coords);
        public Node? RemoveTown(Node coords);
        public Node? GetTown(Node coords);
        public int GetTownID(Node coords);
        public void CreatePath(int id1, int id2);
        public void ClearGraph();
    }
}
