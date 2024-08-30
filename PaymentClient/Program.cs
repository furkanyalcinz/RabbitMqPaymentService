using MassTransit;
using PaymentClient.Controllers;
using PaymentClient.Services;
using PaymentService;
using SharedModels.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPaymentRequestService,PaymentRequestService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransit(x=> 
{
    x.UsingRabbitMq((ctx,cfg) => 
    {
        cfg.Host(new Uri("amqp://guest:guest@localhost:5672"),h => 
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.Message<PaymentRequestDto>(configureTopology => 
        {
            configureTopology.SetEntityName("payment-created-event");
        });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
