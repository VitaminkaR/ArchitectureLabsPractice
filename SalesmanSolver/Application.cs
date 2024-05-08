using System.Windows;

namespace SalesmanSolver
{
    internal class Application
    {
        public const int TOWN_SIZE = 16;

        static public void Main(IView MainWindow)
        {
            IModel model = new TSPModel();
            IController controller = new TSPController(model, MainWindow);
        }
    }
}
