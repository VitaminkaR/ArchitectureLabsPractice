using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace SalesmanSolver
{
    internal class TSPController : IController
    {
        private IModel m_Model;
        private IView m_View;

        // хранит временый узел для соединения городов (1 город)
        private Node? m_TempNode;

        public TSPController(IModel model, IView view)
        {
            m_Model = model;
            m_View = view;

            m_View.SetSolveButtonEvent(Solve);
            m_View.SetClearButtonEvent(ClearGraph);
            m_View.SetMouseButtonEvent(ModifyMap);
        }

        public void SetModel(IModel model) => m_Model = model;

        public void SetView(IView view) => m_View = view;

        public void ClearGraph(object? sender, RoutedEventArgs e)
        {
            m_Model.ClearGraph();
            m_View.ClearMap();
        }

        public void Solve(object? sender, RoutedEventArgs e)
        {
            string res = m_Model.SolveGraph();
            m_View.ShowResult(res.Length != 0 ? $"Кратчайший путь: {res}" : "Ошибка расчёта");
        }

        public void ModifyMap(object? sender, MouseButtonEventArgs e)
        {
            if (e.MouseDevice.LeftButton == MouseButtonState.Pressed)
            {
                Node clickedCoords = new Node((int)e.GetPosition(null).X, (int)e.GetPosition(null).Y);
                Node? node = m_Model.GetTown(clickedCoords);
                if (node == null)
                {
                    m_Model.AddTown(clickedCoords);
                    m_View.ShowNode(clickedCoords, "T");
                }
                else
                {
                    m_View.RemoveNode(m_Model.RemoveTown(clickedCoords));
                }
            }

            if (e.MouseDevice.RightButton == MouseButtonState.Pressed)
            {
                Node clickedCoords = new Node((int)e.GetPosition(null).X, (int)e.GetPosition(null).Y);
                Node? node = m_Model.GetTown(clickedCoords);

                if(node != null)
                {
                    if(m_TempNode == null)
                    {
                        m_TempNode = node;
                    }
                    else
                    {
                        int tmpNodeID = m_Model.GetTownID(m_TempNode);
                        int curNodeID = m_Model.GetTownID(node);
                        m_Model.CreatePath(tmpNodeID, curNodeID);
                        m_View.ShowPath(m_TempNode, node);
                        m_TempNode = null;
                    }
                }
            }
        }
    }
}
