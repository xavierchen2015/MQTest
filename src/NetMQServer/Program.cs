using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;

namespace NetMQServer
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
                Thread.Sleep(900);
                //pubSocket.SendMoreFrame("").SendFrame("aaaa");
                for (var i =0; i < 10; i++)
                {
                    pubSocket.SendMoreFrame("").SendFrame("aaaa"+i);
                }
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
    }
}
