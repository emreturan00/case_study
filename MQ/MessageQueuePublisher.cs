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
        _connectionFactory = new ConnectionFactory
        {
            HostName = "localhost", 
            UserName = "guest",     
            Password = "guest"     
        };
    }

    public Task PublishTransferMessageAsync(TransferDto transferDto)
    {
        using (var connection = _connectionFactory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: QueueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var messageBody = Newtonsoft.Json.JsonConvert.SerializeObject(transferDto);
                var body = Encoding.UTF8.GetBytes(messageBody);

                channel.BasicPublish(exchange: "",
                                     routingKey: QueueName,
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine(" [x] Sent {0}", messageBody);
            }
        }

        return Task.CompletedTask;
    }
}
