using System.Windows;
using System.Windows.Controls;

namespace L3Client
{
    class ClientContoller : IClientController
    {
        IClientView m_View;
        IClientModel m_Model;

        string m_Message;

        public ClientContoller(IClientView view, IClientModel model)
        {
            m_View = view;
            m_Model = model;

            m_View.IPInputEventSet(IPInput);
            m_View.SendMessageButtonEventSet(SendMessageButton);
            m_View.NickInputEventSet(UserNameInput);
            m_View.Connect2ServerButtonEventSet(Connect2ServerButton);
            m_View.MessageInputEventSet(SetMessage);
        }

        public void SetModel(IClientModel model) => m_Model = model;

        public void SetView(IClientView view) => m_View = view;

        public void IPInput(object? sender, TextChangedEventArgs e)
        {
            m_Model.SetIP(((TextBox)sender).Text);
        }

        public void UserNameInput(object? sender, TextChangedEventArgs e)
        {
            m_Model.SetName(((TextBox)sender).Text);
        }

        public void Connect2ServerButton(object? sender, RoutedEventArgs e)
        {
            m_Model.Connect();
            m_Model.SetReceiveMsgEvent(ReceiveMsgEvent);
        }

        public void SendMessageButton(object? sender, RoutedEventArgs e) => m_Model.SendMessage("m" + m_Message);

        public void ReceiveMsgEvent(string msg, int op)
        {
            if (op == 0)
                m_View.ShowMessage(msg);
            else
                m_View.UpdateClientList(msg);
        }

        public void SetMessage(object? sender, TextChangedEventArgs e) => m_Message = m_View.GetMessage();
    }
}
