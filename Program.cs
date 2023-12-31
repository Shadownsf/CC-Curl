// See https://aka.ms/new-console-template for more information
using CommandDotNet;

namespace CC_Curl
{
    public class Program
    {
        static int Main(string[] args)
        {
            return new AppRunner<Program>().Run(args);
        }

        [Subcommand]
        public Get Get { get; set; }
    }

    public class Get
    {
        [DefaultCommand]
        public Task Execute(string s)
        {
            var url = s.Split("://").ToList();

            var protocol = url[0];

            var path = url[1].Split("/").ToList();
            var hostAndPort = path[0].Split(':');
            var host = hostAndPort[0];
            string port = "";
            if (hostAndPort.Length > 1)
            {
                port = hostAndPort[1];
            }
            else
            {
                if (protocol == "http")
                {
                    port = "80";
                }
                else if (protocol == "https")
                {
                    port = "443";
                }
            }

            //Console.WriteLine(protocol);
            //Console.WriteLine(port);

            //Console.WriteLine(host.ToString());

            //for (int i = 1; i < path.Count; i++)
            //{
            //    Console.WriteLine(path[i]);
            //}

            string protocolMessage = string.Empty;
            switch (protocol)
            {
                case "http":
                    protocolMessage = "HTTP/1.1";
                    break;
                case "https":
                    protocolMessage = "TLS/SSL";
                    break;
                default:
                    protocolMessage = "HTTP/1.1";
                    break;
            }

            var response = string.Format($"connecting to {host}\nSending request GET /get {protocolMessage}\nHost: {host}\nAccept: */*");

            Console.WriteLine(response);

            return Task.CompletedTask;
        }
    }
}