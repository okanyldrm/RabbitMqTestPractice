using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMqTestPracticeGetMessage
{
    internal class Program
    {
        static async Task Main(string[] args)
        {


            var factory = new ConnectionFactory();

            factory.Uri = new Uri("amqps://qmigkbqr:gOtB2rhWGkjXFWL21mDBFOEpXt2MM4rj@stingray.rmq.cloudamqp.com/qmigkbqr");


            using var connection = factory.CreateConnectionAsync();


            var channel = connection.Result.CreateChannelAsync();

            channel.Result.QueueDeclareAsync("message-queue", true, false, false);


            var consumer = new AsyncEventingBasicConsumer(channel.Result);

            await channel.Result.BasicConsumeAsync("message-queue", true, consumer);

            consumer.ReceivedAsync += Consumer_ReceivedAsync; ;

            Console.ReadLine();


            Console.WriteLine("Hello, World!");
        }

        private static async Task Consumer_ReceivedAsync(object sender, BasicDeliverEventArgs e)
        {
            Console.WriteLine("Request Message : " + Encoding.UTF8.GetString(e.Body.ToArray()));
        }
    }
}
