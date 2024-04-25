using System.Windows;
using System.Windows.Controls;

namespace L3Client
{
    interface IClientController
    {
        void SetView(IClientView view);
        void SetModel(IClientModel model);

        void IPInput(object? sender, TextChangedEventArgs e);
        void UserNameInput(object? sender, TextChangedEventArgs e);
        void Connect2ServerButton(object? sender, RoutedEventArgs e);
        void SetMessage(object? sender, TextChangedEventArgs e);
        void SendMessageButton(object? sender, RoutedEventArgs e);
        void ReceiveMsgEvent(string msg, int op);
    }
}
