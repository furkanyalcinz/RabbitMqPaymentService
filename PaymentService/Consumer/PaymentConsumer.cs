using System;
using System.Text.Json;
using MassTransit;
using SharedModels.Models;

namespace PaymentService.Consumer;

public class PaymentConsumer : IConsumer<PaymentRequestDto>
{
    public PaymentConsumer()
    {
    }

    public async Task Consume(ConsumeContext<PaymentRequestDto> context)
    {
        var jsonMessage = JsonSerializer.Serialize(context.Message);
        Console.WriteLine("Recieved: " +jsonMessage);
        await Task.CompletedTask;
    }
}
