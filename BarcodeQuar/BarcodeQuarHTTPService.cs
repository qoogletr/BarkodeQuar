using System;
using System.Net;
using System.Threading;

namespace QuarBarcodeApp
{
    public class BarcodeQuarHTTPService
    {
        private readonly string _host;
        private readonly int _port;
        private HttpListener _listener;
        private Thread _listenerThread;

        public BarcodeQuarHTTPService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Start()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://{_host}:{_port}/");
            _listener.Start();
            _listenerThread = new Thread(Listen);
            _listenerThread.Start();
            Console.WriteLine($"HTTP Servisi {_host}:{_port} adresinde başlatıldı.");
        }

        public void Stop()
        {
            _listener.Stop();
            _listenerThread.Join();
            Console.WriteLine("HTTP Servisi durduruldu.");
        }

        private void Listen()
        {
            while (_listener.IsListening)
            {
                try
                {
                    var context = _listener.GetContext();
                    var response = context.Response;
                    string responseString = "<HTML><BODY> Merhaba, dünya! </BODY></HTML>";
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    using (var output = response.OutputStream)
                    {
                        output.Write(buffer, 0, buffer.Length);
                    }
                }
                catch (HttpListenerException) { }
                catch (InvalidOperationException) { }
            }
        }
    }
}