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

        private int[,] m_CurGraph;
        private int m_CurSize;
        private List<int>? m_MinRoute;
        private List<int> m_CurPath = new List<int>();

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

            string route = "";

            try
            {
                m_CurGraph = matrix;
                m_CurSize = (int)MathF.Sqrt(matrix.Length);
                m_CurPath = new List<int>();
                m_MinRoute = null;
                List<int> minPath = Solve();
                
                foreach (int city in minPath)
                    route += (city + 1) + " ";
            }
            catch (Exception)
            {

            }

            return route;
        }

        private List<int> Solve()
        {
            m_CurPath.Add(0);

            for (int i = 1; i < m_CurSize; i++)
            {
                GeneratePaths(i);
            }

            if (m_MinRoute != null)
            {
                return m_MinRoute;
            }
            else
            {
                return null;
            }
        }

        private void GeneratePaths(int city)
        {
            if (m_CurPath.Count == m_CurSize)
            {
                m_CurPath.Add(0);

                int pathLength = CalculatePathLength(m_CurPath);

                if (pathLength != int.MaxValue && (m_MinRoute == null || pathLength < CalculatePathLength(m_MinRoute)))
                {
                    m_MinRoute = new List<int>(m_CurPath);
                }

                m_CurPath.RemoveAt(m_CurPath.Count - 1);

                return;
            }

            for (int i = 0; i < m_CurSize; i++)
            {
                if (!m_CurPath.Contains(i) && m_CurGraph[m_CurPath.Last(), i] != int.MaxValue)
                {
                    m_CurPath.Add(i);
                    GeneratePaths(i);
                    m_CurPath.RemoveAt(m_CurPath.Count - 1);
                }
            }
        }

        private int CalculatePathLength(List<int> path)
        {
            int length = 0;

            for (int i = 0; i < path.Count - 1; i++)
            {
                if (m_CurGraph[path[i], path[i + 1]] == int.MaxValue)
                {
                    return int.MaxValue;
                }

                length += m_CurGraph[path[i], path[i + 1]];
            }

            return length;
        }
    }
}
