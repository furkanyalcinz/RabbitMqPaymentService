using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using PaymentService;
using PaymentService.Consumer;
using SharedModels.Models;
var serviceProvider = new ServiceCollection()
    .AddDbContext<AppDbContext>().BuildServiceProvider();

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg => {
    cfg.ReceiveEndpoint("payment-created-event", e => 
    {
        e.Consumer<PaymentConsumer>();
        e.BindDeadLetterQueue("payment-created-event-dlq");
    });
    cfg.Host(new Uri("amqp://guest:guest@localhost:5672"), h => 
    {
        h.Username("guest");
        h.Password("guest");
    });
    cfg.ReceiveEndpoint("payment-created-event-error",e => 
    {
        // Hata alınan ödemelerin işleneceği consumer tanımlanır.
    });
});
await busControl.StartAsync(new CancellationToken());

try
{
    Console.WriteLine("Enter to exit");
    Console.ReadLine();
}
finally 
{
    await busControl.StopAsync();
}