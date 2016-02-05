using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;


namespace ZMQ
{
    class Program
    {
        public static IList<string> allowableCommandLineArgs
            = new[] { "TopicA", "TopicB", "All" };

        static void Main(string[] args)
        {
            
            using (var subSocket = new SubscriberSocket())
            {
                subSocket.Options.ReceiveHighWatermark = 100;
                subSocket.Connect("tcp://localhost:12345");
                subSocket.Subscribe("");
                Console.WriteLine("Subscriber socket connecting...");
                while (true)
                {
                    string messageTopicReceived = subSocket.ReceiveFrameString();
                    string messageReceived = subSocket.ReceiveFrameString();
                    Console.WriteLine(messageReceived);
                    Thread.Sleep(300);
                }
            }
        }



        //sealed class Server
        //{
        //    static void Main(string[] args)
        //    {

        //        using (var server = new ResponseSocket())
        //        {
        //            server.Bind("tcp://*:5555");

        //            while (true)
        //            {
        //                var message = server.ReceiveFrameString();

        //                Console.WriteLine("Received {0}", message);

        //                // processing the request
        //                Thread.Sleep(100);

        //                Console.WriteLine("Sending World");
        //                server.SendFrame("World");
        //            }
        //        }



        //        //Server s = new Server();
        //        //s.Run();



        //        //using (NetMQContext ctx = NetMQContext.Create())
        //        //{
        //        //    using (var server = ctx.CreateResponseSocket())
        //        //    {
        //        //        server.Bind("tcp://127.0.0.1:5556");
        //        //        using (var client = ctx.CreateRequestSocket())
        //        //        {
        //        //            //client.Connect("tcp://127.0.0.1:5556");
        //        //            //client.Send("Hello");

        //        //            string m1 = server.ReceiveString();
        //        //            Console.WriteLine("From Client: {0}", m1);
        //        //            server.Send("Hi Back");

        //        //            //string m2 = client.ReceiveString();
        //        //            //Console.WriteLine("From Server: {0}", m2);
        //        //            Console.ReadLine();
        //        //        }
        //        //    }
        //        //}
        //    }

        //    public void Run()
        //    {
        //        Task.Run(() =>
        //        {
        //            using (NetMQContext ctx = NetMQContext.Create())
        //            {
        //                using (var server = ctx.CreateResponseSocket())
        //                {
        //                    server.Bind("tcp://127.0.0.1:5556");
        //                    while (true)
        //                    {
        //                        string fromClientMessage = server.ReceiveString();
        //                        Console.WriteLine("From Client: { 0} running on ThreadId: { 1}", fromClientMessage, Thread.CurrentThread.ManagedThreadId);
        //                        server.Send("Hi Back");
        //                    }
        //                }
        //            }
        //            //using (NetMQContext ctx = NetMQContext.Create())
        //            //{
        //            //    using (var server = ctx.CreateResponseSocket())
        //            //    {
        //            //        server.Bind("tcp://127.0.0.1:5556");

        //            //        while (true)
        //            //        {
        //            //            string fromClientMessage = server.ReceiveString();
        //            //            Console.WriteLine("From Client: {0} running on ThreadId: {1}", fromClientMessage, Thread.CurrentThread.ManagedThreadId);
        //            //            //server.Send("Hi Back");
        //            //            Thread.Sleep(2000);
        //            //        }

        //            //    }
        //            //}
        //        }
        //        );
        //    }


        //}
    }
}
