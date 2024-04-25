using System.Windows;
using System.Windows.Controls;

namespace L3Client
{
    interface IClientView
    {
        void ShowMessage(string msg);

        void IPInputEventSet(TextChangedEventHandler textChangedEventHandler);
        void NickInputEventSet(TextChangedEventHandler textChangedEventHandler);
        void MessageInputEventSet(TextChangedEventHandler textChangedEventHandler);
        void Connect2ServerButtonEventSet(RoutedEventHandler routedEventHandler);
        void SendMessageButtonEventSet(RoutedEventHandler routedEventHandler);
        string GetMessage();
        void UpdateClientList(string msg);
    }
}
