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
        List<Ellipse> m_Nodes = new List<Ellipse>();

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

        public void ShowResult(string res) =>
            TB_Result.Text = res;

        public void RemoveNode(Node node)
        {
            if (node == null)
                return;

            Predicate<Ellipse> pr = (Ellipse el) => 
            el.Margin.Left + Application.TOWN_SIZE == node.X && el.Margin.Top + Application.TOWN_SIZE == node.Y;
            Ellipse ?el = m_Nodes.Find(pr);
            if (el != null)
            {
                m_Nodes.Remove(el);
                C_GraphicMap.Children.Remove(el);
            }    
        }

        public void ClearMap()
        {
            C_GraphicMap.Children.Clear();
            m_Nodes.Clear();
        }

        public void ShowNode(Node node, string name)
        {
            Ellipse el = new Ellipse();
            el.Margin = new Thickness(node.X - Application.TOWN_SIZE, node.Y - Application.TOWN_SIZE, 0, 0);
            el.Width = Application.TOWN_SIZE;
            el.Height = Application.TOWN_SIZE;
            el.StrokeThickness = 2;
            el.Stroke = new SolidColorBrush(Colors.Red);
            el.Fill = new SolidColorBrush(Colors.White);
            C_GraphicMap.Children.Add(el);
            m_Nodes.Add(el);
        }
    }
}