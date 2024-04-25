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
            Debug.WriteLine("Clear");
        }

        public void Solve(object? sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Solve");
        }

        public void ModifyMap(object? sender, MouseButtonEventArgs e)
        {
            if (e.MouseDevice.LeftButton == MouseButtonState.Pressed)
                Debug.WriteLine("Modify Click");
        }
    }
}
