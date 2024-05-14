using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SalesmanSolver
{
    internal class TSPModel : IModel
    {
        public IGraph Graph;

        public TSPModel()
        {
            Graph = new TSPGraph();
        }

        public void AddTown(Node coords) => Graph.AddNode(coords);

        public void ClearGraph() => Graph.ClearGraph();

        public void CreatePath(int id1, int id2) => Graph.CreatePath(id1, id2);

        public Node? GetTown(Node coords)
        {
            foreach (var node in Graph.GetNodes())
            {
                if (coords.X >= node.X - Application.TOWN_SIZE / 2 && coords.Y >= node.Y - Application.TOWN_SIZE / 2
                    && coords.X <= node.X - Application.TOWN_SIZE / 2 + Application.TOWN_SIZE
                    && coords.Y <= node.Y - Application.TOWN_SIZE / 2 + Application.TOWN_SIZE)
                {
                    return node;
                }
            }

            return null;
        }

        public int GetTownID(Node coords)
        {
            return Graph.GetNodes().FindIndex((_node) => _node.X == coords.X && _node.Y == coords.Y);
        }

        public Node? RemoveTown(Node coords)
        {
            Node? node = GetTown(coords);

            if(node != null)
            {
                Graph.RemoveNode(GetTownID(node));
                return node;
            }

            return null;
        }

        public string SolveGraph()
        {
            int[,] matrix = Graph.GetAdjacentMatrix();
            


            return "";
        }
    }
}
