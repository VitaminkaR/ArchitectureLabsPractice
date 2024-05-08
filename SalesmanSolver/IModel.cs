using System.Numerics;

namespace SalesmanSolver
{
    internal interface IModel
    {
        public void SolveGraph();
        public void AddTown(Node coords);
        public Node RemoveTown(Node coords);
        public void CreatePath(int id1, int id2);
        public void ClearGraph();
    }
}
