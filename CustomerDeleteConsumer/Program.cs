using System;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CustomerDeleteConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("CustomerDelete",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            
            Console.WriteLine(" Waiting for messages.");
            
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                // var bodyToGuid = new Guid(ea.Body.ToArray()                                                                                                                                                                                                                                            );
                var message = System.Text.Encoding.UTF8.GetString(body);
                var message1 = message.Trim('"');
                Console.WriteLine($" Received : {message1}");
                var guidParse = Guid.Parse(message1);
                using (var httpClient = new HttpClient())
                {
                    var apiUrl = $"http://localhost:5011/api/orders/Customer/{message1}";
                    //string apiUrl = $"http://localhost:5011/api/orders/Customer/20636b1d-a1bc-4581-b01f-3f066ff8f474"; // çalışıyor.      
                    var content = new StringContent(message1,Encoding.UTF8,"application/json");
                    var response = httpClient.PostAsync(apiUrl,content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("API isteği başarılı. Yanıt içeriği:");
                        var responseContent = response.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(responseContent);
                    }
                    else
                    {
                        Console.WriteLine("API isteği başarısız. Hata kodu: " + response.StatusCode);
                    }
                }
                
                
            };
            channel.BasicConsume(queue: "CustomerDelete",
                autoAck: true,
                consumer: consumer);
            
            Console.WriteLine(" Press [enter] to exit."); 
            Console.ReadLine();

        }
    }
}