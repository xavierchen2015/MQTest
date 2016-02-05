using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace MSMQSend
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageQueue myQueue = new MessageQueue(".\\myQueue");
            myQueue.Send("Public queue by path name.");
            //if (!MessageQueue.Exists(@".Private$LearningHardMSMQ"))
            //                 {
            //                     using (MessageQueue mq = MessageQueue.Create(@".Private$LearningHardMSMQ"))
            //                         {
            //                             mq.Label = "LearningHardPrivateQueue";
            //                             Console.WriteLine("已经创建了一个私有队列");
            //                             Console.WriteLine("路径为:{0}", mq.Path);
            //                             Console.WriteLine("私有队列名字为:{0}", mq.QueueName);
            //                             mq.Send("MSMQ Private Message", "Leaning Hard"); // 发送消息
            //                         }
            //                 }
        }
    }
}
