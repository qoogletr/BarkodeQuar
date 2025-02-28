using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace QuarBarcodeApp
{
    public class BarcodeQuarSockService
    {
        private readonly string _host;
        private readonly int _port;
        private TcpListener _listener;
        private Thread _listenerThread;

        public BarcodeQuarSockService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Start()
        {
            _listener = new TcpListener(IPAddress.Parse(_host), _port);
            _listener.Start();
            _listenerThread = new Thread(Listen);
            _listenerThread.Start();
            Console.WriteLine($"SOCKS Servisi {_host}:{_port} adresinde başlatıldı.");
        }

        public void Stop()
        {
            _listener.Stop();
            _listenerThread.Join();
            Console.WriteLine("SOCKS Servisi durduruldu.");
        }

        private void Listen()
        {
            while (true)
            {
                try
                {
                    var client = _listener.AcceptTcpClient();
                    var stream = client.GetStream();
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string request = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Gelen mesaj: {request}");
                    byte[] response = System.Text.Encoding.UTF8.GetBytes("Merhaba, dünya!");
                    stream.Write(response, 0, response.Length);
                    client.Close();
                }
                catch (SocketException) { }
            }
        }
    }
}