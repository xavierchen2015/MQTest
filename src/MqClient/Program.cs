using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Apache.NMS;
using Apache.NMS.ActiveMQ;


namespace MqClient
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
                    connection.ClientId = "DidiMQ listener";
                    connection.Start();

                    //Create the Session
                    using (ISession session = connection.CreateSession())
                    {
                        //Create the Consumer
                        //IMessageConsumer consumer = session.CreateDurableConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic("testing"), "testing listener", null, false);
                        //IMessageConsumer consumer = session.CreateDurableConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic("DidiMQ"), "DidiMQ listener", null, false);
                        IMessageConsumer consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("DidiMQ"), "filter=DidiMQ listener");

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
                string sqlStr = "";
                ITextMessage msg = (ITextMessage)message;
                XDocument xdoc = new XDocument();
                xdoc = XDocument.Parse(msg.Text);
                var d = xdoc.Element("string");
                sqlStr = d.Value;
                Console.WriteLine("Receive: " + msg.Text);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
