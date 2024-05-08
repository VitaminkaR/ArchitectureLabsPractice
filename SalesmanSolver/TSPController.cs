using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace SalesmanSolver
{
    internal class TSPController : IController
    {
        private IModel m_Model;
        private IView m_View;

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
            m_Model.SolveGraph();
        }

        public void ModifyMap(object? sender, MouseButtonEventArgs e)
        {
            if (e.MouseDevice.LeftButton == MouseButtonState.Pressed)
            {
                Node node = new Node((int)e.GetPosition(null).X, (int)e.GetPosition(null).Y);
                m_Model.AddTown(node);
                m_View.ShowNode(node, "T");
            }

            if (e.MouseDevice.RightButton == MouseButtonState.Pressed)
            {
                Node node = new Node((int)e.GetPosition(null).X, (int)e.GetPosition(null).Y);
                m_View.RemoveNode(m_Model.RemoveTown(node));
            }
        }
    }
}
