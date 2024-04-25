namespace L3Client
{
    interface IClientModel
    {
        void SetIP(string ip);
        void SetName(string name);
        void Connect();
        void SendMessage(string msg);
        void SetReceiveMsgEvent(Action<string, int> handle);
    }
}
