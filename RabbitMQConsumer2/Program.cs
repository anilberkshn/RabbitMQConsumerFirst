using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQConsumer2
{
    class Program
    {
        static void Main(string[] args)
        {
//             var connectionFactory = new ConnectionFactory
//             {
//                 HostName = "localhost", // RabbitMQ'nun bulunduğu sunucu adresi
//                 Port = 5672, // RabbitMQ'nun kullanacağı bağlantı noktası
//                 VirtualHost = "/" // RabbitMQ sanal ana bilgisayar (virtual host)
//             };
//             
//             var connection = connectionFactory.CreateConnection();
//             var channel = connection.CreateModel();
//             
//             // Queue oluşturma
//             channel.QueueDeclare("my_queue", false, false, false, null);
//
// // Mesajları alma
//             var consumer = new EventingBasicConsumer(channel);
//             consumer.Received += (model, ea) =>
//             {
//                 var message = Encoding.UTF8.GetString(ea.Body.ToArray());
//                 Console.WriteLine("Received message: {0}", message);
//             };
//             channel.BasicConsume("my_queue", true, consumer);
//
//             channel.Close();
//             connection.Close();

        }
    }
}