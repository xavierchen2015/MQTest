using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
using System.Threading;

namespace ZMQClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random(50);


            using (var pubSocket = new PublisherSocket())
            {
                Console.WriteLine("Publisher socket binding...");
                pubSocket.Options.SendHighWatermark = 100;
                pubSocket.Bind("tcp://localhost:12345");
                Thread.Sleep(200);
                pubSocket.SendMoreFrame("").SendFrame("1231231231313123131231");
                //for (var i = 0; i < 300; i++)
                //{
                //    var randomizedTopic = rand.NextDouble();
                //    if (randomizedTopic > 0.5)
                //    {
                //        var msg = "TopicA msg-" + i;
                //        Console.WriteLine("Sending message : {0}", msg);
                //        pubSocket.SendMoreFrame("TopicA").SendFrame(msg);
                //    }
                //    else
                //    {
                //        var msg = "TopicB msg-" + i;
                //        Console.WriteLine("Sending message : {0}", msg);
                //        pubSocket.SendMoreFrame("TopicB").SendFrame(msg);
                //    }

                //    Thread.Sleep(100);
                //}
            }
        }
        //sealed class Client
        //{
        //    private string clientName;
        //    static void Main(string[] args)
        //    {
        //        Client c = new Client();
        //        c.clientName = args[0];
        //        c.Run();
        //        //using (NetMQContext ctx = NetMQContext.Create())
        //        //{
        //        //    using (var server = ctx.CreateResponseSocket())
        //        //    {
        //        //        using (var client = ctx.CreateRequestSocket())
        //        //        {
        //        //            client.Connect("tcp://127.0.0.1:5556");
        //        //            client.Send("Hello");
        //        //        }
        //        //    }
        //        //}
        //    }
        //    public void Run()
        //    {

        //        using (NetMQContext ctx = NetMQContext.Create())
        //        {
        //            using (var client = ctx.CreateRequestSocket())
        //            {
        //                client.Connect("tcp://127.0.0.1:5556");
        //                while (true)
        //                {
        //                    client.Send(string.Format("Hello from client {0}", clientName));
        //                    string fromServerMessage = client.ReceiveString();
        //                    Console.WriteLine("From Server: {0}=running on ThreadId: {1}",fromServerMessage, Thread.CurrentThread.ManagedThreadId);
        //                    Thread.Sleep(5000);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
