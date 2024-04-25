using System.Windows;

namespace SalesmanSolver
{
    internal class Application
    {
        static public void Main(IView MainWindow)
        {
            IModel model = new TSPModel();
            IController controller = new TSPController(model, MainWindow);
        }
    }
}
