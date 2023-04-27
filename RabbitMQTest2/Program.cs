using System;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMQTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost", // RabbitMQ'nun bulunduğu sunucu adresi
                // Port = 5672, // RabbitMQ'nun kullanacağı bağlantı noktası
                VirtualHost = "/" // RabbitMQ sanal ana bilgisayar (virtual host)
            };
            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
        
            // Exchange ve Queue oluşturma
            channel.ExchangeDeclare("my_exchange", ExchangeType.Direct);
            channel.QueueDeclare("my_queue", false, false, false, null);
            channel.QueueBind("my_queue", "my_exchange", "my_routing_key");

            // Mesajı gönderme
            var message = "Hello, RabbitMQ!";
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish("my_exchange", "my_routing_key", null, body);

            channel.Close();
            connection.Close();
        }
    }
}