
using System;
using System.Net;
using System.Threading.Tasks;

namespace Callback
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestSender sender = new RequestSender();
            sender.RequestAsync("http://bbb.net", BlockUrl);
        }

        private static void BlockUrl(string url) => Console.WriteLine($"{url} is blocked in your contry");
    }    

    class RequestSender
    {
        public delegate void Handle(string url);

        public async Task RequestAsync(string url, Handle result)
        {
            bool callback = await Task.Run(() =>
            {
                return true;
            });

            if (callback)
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
