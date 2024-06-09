using System;
using System.Text;
using System.Threading.Tasks;
using case_study.Dtos;
using RabbitMQ.Client;

public class MessageQueuePublisher : IMessageQueuePublisher
{
    private readonly ConnectionFactory _connectionFactory;
    private const string QueueName = "transfer_queue";

    public MessageQueuePublisher()
    {
        // Initialize RabbitMQ connection factory
        _connectionFactory = new ConnectionFactory
        {
            HostName = "localhost", // RabbitMQ server hostname
            UserName = "guest",     // RabbitMQ username
            Password = "guest"      // RabbitMQ password
        };
    }

    public Task PublishTransferMessageAsync(TransferDto transferDto)
    {
        // Create a connection to RabbitMQ server
        using (var connection = _connectionFactory.CreateConnection())
        {
            // Create a channel
            using (var channel = connection.CreateModel())
            {
                // Declare the queue if it doesn't exist
                channel.QueueDeclare(queue: QueueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                // Convert the transferDto to a JSON string
                var messageBody = Newtonsoft.Json.JsonConvert.SerializeObject(transferDto);
                var body = Encoding.UTF8.GetBytes(messageBody);

                // Publish the message to the queue
                channel.BasicPublish(exchange: "",
                                     routingKey: QueueName,
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine(" [x] Sent {0}", messageBody);
            }
        }

        // Return a completed task
        return Task.CompletedTask;
    }
}
