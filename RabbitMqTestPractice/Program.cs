using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMqTestPractice
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {

                SendMessage();

            }


        }


        public static async void SendMessage()
        {
            var factory = new ConnectionFactory();

            factory.Uri = new Uri("amqps://qmigkbqr:gOtB2rhWGkjXFWL21mDBFOEpXt2MM4rj@stingray.rmq.cloudamqp.com/qmigkbqr");


            using var connection = factory.CreateConnectionAsync();


            var channel = connection.Result.CreateChannelAsync();

            channel.Result.QueueDeclareAsync("message-queue", true, false, false);

            var mesaj = "test mesaj";

            var body = Encoding.UTF8.GetBytes(mesaj);
            //String.Empty, "message-queue",null,body
            await channel.Result.BasicPublishAsync(String.Empty, "message-queue", body);

            Console.WriteLine("Hello World");

            Console.ReadLine();



        }

    }
}




