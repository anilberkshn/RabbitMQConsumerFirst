using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitConsumer3
{
    class Program
    {
        static void Main(string[] args)
        {
        //     var factory = new ConnectionFactory { HostName = "localhost" };
        //     using var connection = factory.CreateConnection();
        //     using var channel = connection.CreateModel();
        //
        //     channel.QueueDeclare(queue: "hello",
        //         durable: false,
        //         exclusive: false,
        //         autoDelete: false,
        //         arguments: null);
        //     
        //     Console.WriteLine(" [*] Waiting for messages.");
        //
        //     var consumer = new EventingBasicConsumer(channel);
        //     consumer.Received += (model, ea) =>
        //     {
        //         var body = ea.Body.ToArray();
        //         var message = Encoding.UTF8.GetString(body);
        //         Console.WriteLine($" [x] Received {message}");
        //         
        //         int dots = message.Split('.').Length - 1;
        //         Thread.Sleep(dots * 1000);
        //
        //         Console.WriteLine(" [x] Done");
        //     };
        //     channel.BasicConsume(queue: "hello",
        //         autoAck: true,
        //         consumer: consumer);
        //
        //     Console.WriteLine(" Press [enter] to exit."); 
        //     Console.ReadLine();
        }
        
    }
}