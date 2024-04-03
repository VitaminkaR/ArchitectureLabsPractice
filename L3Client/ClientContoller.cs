using System.Windows;
using System.Windows.Controls;

namespace L3Client
{
    class ClientContoller : IClientController
    {
        IClientView m_View;
        IClientModel m_Model;

        string m_Message;

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

        public void ReceiveMsgEvent(string msg)
        {
            m_View.ShowMessage(msg);
        }

        public void SetMessage(object? sender, TextChangedEventArgs e) => m_Message = ((TextBox)sender).Text;
    }
}
