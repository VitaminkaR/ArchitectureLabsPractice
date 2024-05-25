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
        List<Line> m_Paths = new List<Line>();
        List<Label> m_Labels = new List<Label>();

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

            Predicate<Ellipse> pr_e = (Ellipse el) => 
            el.Margin.Left + Application.TOWN_SIZE == node.X && el.Margin.Top + Application.TOWN_SIZE == node.Y;
            int el = m_Nodes.FindIndex(pr_e);

            Predicate<Line> pr_l = (Line line) =>
            line.X1 + Application.TOWN_SIZE / 2 == node.X && line.Y1 + Application.TOWN_SIZE / 2 == node.Y ||
            line.X2 + Application.TOWN_SIZE / 2 == node.X && line.Y2 + Application.TOWN_SIZE / 2 == node.Y;
            List<Line> lines = m_Paths.FindAll(pr_l);

            if (el >= 0 && el < m_Nodes.Count)
            {
                C_GraphicMap.Children.Remove(m_Nodes[el]);
                m_Nodes.Remove(m_Nodes[el]);
            }    
            if(lines.Count > 0)
            {
                foreach (var line in lines)
                {
                    m_Paths.Remove(line);
                    C_GraphicMap.Children.Remove(line);
                }  
            }

            C_GraphicMap.Children.Remove(m_Labels[el]);
            m_Labels.RemoveAt(el);

            for (int i = 0; i < m_Labels.Count; i++)
            {
                m_Labels[i].Content = i+1;
            }
        }

        public void ClearMap()
        {
            C_GraphicMap.Children.Clear();
            m_Nodes.Clear();
            m_Paths.Clear();
            m_Labels.Clear();
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

            Label l = new Label();
            l.Margin = new Thickness(node.X - Application.TOWN_SIZE*2, node.Y - Application.TOWN_SIZE*2, 0, 0);
            l.Content = m_Nodes.Count;
            C_GraphicMap.Children.Add(l);
            m_Labels.Add(l);
        }

        public void ShowPath(Node n1, Node n2)
        {
            Line line = new Line();
            line.X1 = n1.X - Application.TOWN_SIZE/2;
            line.X2 = n2.X - Application.TOWN_SIZE/2;
            line.Y1 = n1.Y - Application.TOWN_SIZE/2;
            line.Y2 = n2.Y - Application.TOWN_SIZE/2;
            line.StrokeThickness = 2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            C_GraphicMap.Children.Add(line);
            m_Paths.Add(line);
        }
    }
}