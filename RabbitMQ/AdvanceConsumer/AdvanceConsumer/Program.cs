using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvanceConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine(args[0] + " -- " + args[1]);

            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "demo-exch",
                     type: ExchangeType.Fanout,
                     durable: true,
                     autoDelete: false,
                     arguments: null);

            var arguments = new Dictionary<string, object>() {
                {"x-message-ttl", 6000 },  // TTL fro the queue messsage (all messages)
                { "x-expires", 30*60*1000} // Queue expire after idle time out, in milliseconds
            };

            channel.QueueDeclare("demoq", durable: false, exclusive: false, autoDelete: false, arguments:arguments);

            channel.QueueBind("demoq", "demo-exch", "", null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (ch, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body);
                Console.WriteLine($"Message received :{message}");
                channel.BasicAck(ea.DeliveryTag, multiple: false);
            };
            channel.BasicConsume(queue: "demoq", autoAck:false, consumer:consumer);

            Console.WriteLine("Waiting for message.....Press ENTER to exit");
            Console.ReadLine();

            channel.Dispose();
            connection.Dispose();
        }
    }
}
