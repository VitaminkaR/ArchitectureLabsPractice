using System.Numerics;

namespace SalesmanSolver
{
    internal interface IGraph
    {
        public void AddNode(Node vec);
        public void RemoveNode(int id);
        public void CreatePath(int id1, int id2);
        public void RemovePath(int id1, int id2);
        public List<Node> GetNodes();
        public int[,] GetAdjacentMatrix();
    }
}
