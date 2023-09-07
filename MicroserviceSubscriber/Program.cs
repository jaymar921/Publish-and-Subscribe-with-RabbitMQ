using EasyNetQ;
using MicroserviceCommon;

namespace MicroserviceSubscriber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Subscriber Started");

            using(var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.PubSub.Subscribe<MessageRequest>("MessageRequest", handleMessageRequest);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        static void handleMessageRequest(MessageRequest request)
        {
            Console.WriteLine($"Message: {request.Message}");
        }
    }
}