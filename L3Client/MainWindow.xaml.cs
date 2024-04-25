using System.Windows;
using System.Windows.Controls;

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
            IClientController clientController = new ClientContoller(this, model);

            Button_SendMessage.Click += (object sender, RoutedEventArgs e) => { TB_Message.Text = ""; };
        }

        public void Connect2ServerButtonEventSet(RoutedEventHandler routedEventHandler) =>
            Button_Connect2Server.Click += routedEventHandler;

        public string GetMessage() => TB_Message.Text;

        public void IPInputEventSet(TextChangedEventHandler textChangedEventHandler) =>
            TB_IP.TextChanged += textChangedEventHandler;

        public void MessageInputEventSet(TextChangedEventHandler textChangedEventHandler) =>
            TB_Message.TextChanged += textChangedEventHandler;

        public void NickInputEventSet(TextChangedEventHandler textChangedEventHandler) =>
            TB_NickName.TextChanged += textChangedEventHandler;

        public void SendMessageButtonEventSet(RoutedEventHandler routedEventHandler) =>
            Button_SendMessage.Click += routedEventHandler;

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

        public void UpdateClientList(string msg)
        {
            Dispatcher.Invoke(() =>
            {
                TB_UsersList.Text = "Users:\n" + msg;
            });
        }
    }
}