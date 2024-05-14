using System.Windows;
using System.Windows.Input;

namespace SalesmanSolver
{
    internal interface IView
    {
        public void ShowNode(Node node, string name);
        public void RemoveNode(Node node);
        public void ShowResult(string res);
        public void ShowPath(Node n1, Node n2);
        public void ClearMap();
        public void SetClearButtonEvent(RoutedEventHandler routedEventHandler);
        public void SetSolveButtonEvent(RoutedEventHandler routedEventHandler);
        public void SetMouseButtonEvent(MouseButtonEventHandler mouseButtonEventHandler);
    }
}
