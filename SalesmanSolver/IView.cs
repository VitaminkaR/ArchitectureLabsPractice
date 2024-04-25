using System.Windows;
using System.Windows.Input;

namespace SalesmanSolver
{
    internal interface IView
    {
        public void SetClearButtonEvent(RoutedEventHandler routedEventHandler);
        public void SetSolveButtonEvent(RoutedEventHandler routedEventHandler);
        public void SetMouseButtonEvent(MouseButtonEventHandler mouseButtonEventHandler);
    }
}
