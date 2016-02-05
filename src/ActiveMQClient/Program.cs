using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ;

namespace ActiveMQClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Create the Connection factory
                IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616/");

                //Create the connection
                using (IConnection connection = factory.CreateConnection())
                {
                    connection.ClientId = "AMQ listener";
                    connection.Start();

                    //Create the Session
                    using (ISession session = connection.CreateSession())
                    {
                        //Create the Consumer
                        IMessageConsumer consumer = session.CreateDurableConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic("AMQ"), "AMQ listener", null, false);

                        consumer.Listener += new MessageListener(consumer_Listener);

                        Console.ReadLine();
                    }
                    connection.Stop();
                    connection.Close();
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void consumer_Listener(IMessage message)
        {
            try
            {
                Thread.Sleep(5000);
                ITextMessage msg = (ITextMessage)message;
                
                Console.WriteLine("Receive: " + msg.Text);
                
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
