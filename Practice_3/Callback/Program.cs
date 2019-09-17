
using System;

namespace Callback
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server("http//requesthandler.net");
            RequestSender sender = new RequestSender();
            sender.Request(server.GetUrl(), BlockUrl);
        }

        private static void BlockUrl(string url) => Console.WriteLine($"{url} is blocked in your contry");
    }    

    class RequestSender
    {
        public delegate void Handle(string url);

        public async void Request(string url, Handle result)
        {
            if (string.IsNullOrEmpty(url))
                return;
            else
                result(url);
        }
    }

    class Server
    {
        private string _url;

        public Server(string url)
        {
            _url = url;
        }

        public string GetUrl() => _url;
    }
}
