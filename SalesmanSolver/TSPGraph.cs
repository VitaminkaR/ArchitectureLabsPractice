﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SalesmanSolver
{
    internal class TSPGraph : IGraph
    {
        private List<Town> m_Towns;
        private List<Node> m_Paths;

        public TSPGraph()
        {
            m_Towns = new List<Town>();
            m_Paths = new List<Node>();
        }

        public void AddNode(Node vec) => m_Towns.Add(new Town($"T{m_Towns.Count + 1}", vec.X, vec.Y));

        public void CreatePath(int id1, int id2) => m_Paths.Add(new Node(id1, id2));

        public int[,] GetAdjacentMatrix()
        {
            int townCount = m_Towns.Count;
            int[,] adjacentMatrix = new int[townCount, townCount];
            for (int i = 0; i < townCount; i++)
            {

                for (int j = 0; j < m_Paths.Count; j++)
                {
                    // если существует путь от исследуемого города к другому
                    if (m_Paths[j].X == i)
                    {
                        int it1 = i;
                        int it2 = (int)m_Paths[j].Y;
                        Town t1 = m_Towns[it1];
                        Town t2 = m_Towns[it2];
                        adjacentMatrix[it1, it2] = (int)MathF.Sqrt(((t2.X - t1.X) * (t2.X - t1.X)) + ((t2.Y - t1.Y) * (t2.Y - t1.Y)));
                    }
                }
            }

            return adjacentMatrix;
        }

        public List<Node> GetNodes()
        {
            List<Node> list = new List<Node>();
            foreach (var town in m_Towns)
                list.Add(new Node(town.X, town.Y));
            return list;
        }

        public void RemoveNode(int id) => m_Towns.RemoveAt(id);

        public void RemovePath(Node vec) => m_Paths.Remove(vec); 

        public void RemovePath(int id1, int id2) => m_Paths.Remove(new Node(id1, id2));
    }
}
