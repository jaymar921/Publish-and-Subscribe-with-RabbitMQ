using EasyNetQ;
using MicroserviceCommon;

namespace MicroservicePublisher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Publisher Started");

            using(var bus = RabbitHutch.CreateBus("host=localhost;publisherConfirms=true;timeout=10"))
            {
                bus.PubSub.Publish(new MessageRequest { Message = "Subject: Hello World! " });
                bus.PubSub.Publish(new MessageRequest { Message = "This message was published - 1st " });
                bus.PubSub.Publish(new MessageRequest { Message = "Followed by this message   - 2nd" });
                bus.PubSub.Publish(new MessageRequest { Message = "This was the last message  - 3rd" });
            }
        }
    }
}