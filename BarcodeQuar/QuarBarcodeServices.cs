using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class Host
{
    private TcpListener listener;

    public void Start(string ipAddress, int port, Action<string> onDataReceived)
    {
        IPAddress ip = IPAddress.Parse(ipAddress);
        listener = new TcpListener(ip, port);
        listener.Start();
        listener.BeginAcceptTcpClient(OnClientConnected, onDataReceived);
    }

    private void OnClientConnected(IAsyncResult ar)
    {
        TcpClient client = listener.EndAcceptTcpClient(ar);
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        var onDataReceived = (Action<string>)ar.AsyncState;
        onDataReceived(receivedData);

        client.Close();
        listener.BeginAcceptTcpClient(OnClientConnected, onDataReceived);
    }

    public void Stop()
    {
        listener.Stop();
    }
}