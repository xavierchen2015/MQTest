using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace MSMQRecive
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageQueue myQueue = new MessageQueue(".\\myQueue");
            //var mes = myQueue.Receive(new TimeSpan(0, 0, 3));
            var timeout = TimeSpan.FromSeconds(1);
            MessageEnumerator msgs = myQueue.GetMessageEnumerator2();
            while (msgs.MoveNext(timeout))
            {
                using (var message = myQueue.ReceiveById(msgs.Current.Id, timeout))
                {
                    message.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" });
                    string m = message.Body.ToString();
                    Console.WriteLine(m);
                }
            }
        }
    }
}
