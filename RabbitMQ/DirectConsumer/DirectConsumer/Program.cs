using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace DirectConsumer
{
    class Program
    {
        // commond line arg queue and key
        static void Main(string[] args)
        {
            Console.WriteLine(args[0] + " -- " + args[1]);

            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "dir-exch",
                     type: ExchangeType.Direct,
                     durable: false,
                     autoDelete: false,
                     arguments: null);

            channel.QueueDeclare(args[0], durable: false, exclusive: false, autoDelete: false);

            channel.QueueBind(args[0], "dir-exch", args[1], null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (ch, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body);
                Console.WriteLine($"Message received :{message}");
            };
            channel.BasicConsume(args[0], true, consumer);

            Console.WriteLine("Waiting for message.....Press ENTER to exit");
            Console.ReadLine();

            channel.Dispose();
            connection.Dispose();
        }
    }
}
