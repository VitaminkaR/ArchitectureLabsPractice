using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesmanSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SalesmanView : Window, IView
    {
        public SalesmanView()
        {
            InitializeComponent();

            Application.Main(this);
        }

        public void SetClearButtonEvent(RoutedEventHandler routedEventHandler) =>
            Button_ClearCanvas.Click += routedEventHandler;

        public void SetMouseButtonEvent(MouseButtonEventHandler mouseEventHandler) =>
            Mouse.AddMouseDownHandler(this, mouseEventHandler);

        public void SetSolveButtonEvent(RoutedEventHandler routedEventHandler) =>
            Button_SolveGraph.Click += routedEventHandler;
    }
}