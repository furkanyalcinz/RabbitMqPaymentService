using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PaymentService;
using PaymentService.Consumer;
using SharedModels.Models;
var serviceProvider = new ServiceCollection()
    .AddDbContext<AppDbContext>( opt => opt.UseInMemoryDatabase("TestDatabase"))
    .BuildServiceProvider();
using (var context = serviceProvider.GetService<AppDbContext>())
{
    if(context != null)
    {
        context.Cards.Add(new Card {CardNumber = "1234", FullName = "Furkan Yalçın", CVV = 123, Month= 12, Year = 25});
        context.Cards.Add(new Card {CardNumber = "5678", FullName = "Emre Yalçın", CVV = 456, Month= 12, Year = 25});
        context.Cards.Add(new Card {CardNumber = "9101", FullName = "Doğukan Yalçın", CVV = 789, Month= 12, Year = 25});
    }
}

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg => {
    cfg.ReceiveEndpoint("payment-created-event", e => 
    {
        e.Consumer<PaymentConsumer>();
    });
    cfg.Host(new Uri("amqp://guest:guest@localhost:5672"), h => 
    {
        h.Username("guest");
        h.Password("guest");
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