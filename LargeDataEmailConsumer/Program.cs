using System;
using System.Text;
using LargeDataEmailConsumer.Models;
using LargeDataEmailConsumer.Models.Entities;
using LargeDataEmailConsumer.Models.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace LargeDataEmailConsumer
{
    public class Program
    {
        public static void Main(string[] args)
        {

            UserEmail email = null;
            var factory = new ConnectionFactory() {HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "LargeDataEmailTaskManager",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    //check if message is available
                    if (!string.IsNullOrEmpty(message))
                    {
                        email = JsonConvert.DeserializeObject<UserEmail>(message);

                        if (email != null)
                        {
                            if (email.MessageCategory == "General")
                            {
                                foreach (var item in email.AppUsers)
                                {
                                    //send user email
                                    var mailer = new Mailer();
                                    var success =
                                        mailer.SendGeneralNoticeEmail(new AppConfig().GeneralNoticeHtml, email.Body,email.Subject,
                                            item);
                                    if (success)
                                    {
                                        Console.WriteLine(JsonConvert.SerializeObject(email.MessageCategory));
                                    }
                                }
                            }
                            if (email.MessageCategory == "Newsletter")
                            {
                          
                                foreach (var item in email.AppUsers)
                                {      //send user email
                                var mailer = new Mailer();
                                    var success = mailer.SendNewsletterEmail(new AppConfig().NewsLetterHtml, email.Body, email.Subject, item);
                                    if (success)
                                    {
                                        Console.WriteLine(JsonConvert.SerializeObject(email.MessageCategory));
                                    }
                                }
                               
                              
                            }

                        }
                        Console.WriteLine(" [x] Received {0}", message);

                    }
             

           

                };
                channel.BasicConsume(queue: "LargeDataEmailTaskManager",
                    autoAck: true,
                    consumer: consumer);
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
