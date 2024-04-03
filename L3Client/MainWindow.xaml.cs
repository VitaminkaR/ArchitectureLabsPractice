using System.Windows;

namespace L3Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IClientView
    {
        private int m_MsgCount = 0;

        public MainWindow()
        {
            InitializeComponent();

            IClientModel model = new ClientModel();
            IClientController clientController = new ClientContoller();

            clientController.SetView(this);
            clientController.SetModel(model);

            TB_IP.TextChanged += clientController.IPInput;
            TB_NickName.TextChanged += clientController.UserNameInput;
            Button_Connect2Server.Click += clientController.Connect2ServerButton;
            Button_SendMessage.Click += clientController.SendMessageButton;
            Button_SendMessage.Click += (object sender, RoutedEventArgs e) => { TB_Message.Text = ""; };
            TB_Message.TextChanged += clientController.SetMessage;
        }

        public void ShowMessage(string msg)
        {
            Dispatcher.Invoke(() =>
            {
                if (m_MsgCount >= 12)
                {
                    m_MsgCount--;
                    TF_Chat.Text = TF_Chat.Text.Remove(0, TF_Chat.Text.IndexOf('\n') + 1);
                }
                m_MsgCount++;
                TF_Chat.Text += msg + "\n";
            });
        }
    }
}