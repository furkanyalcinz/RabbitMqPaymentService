using System;
using System.Text.Json;
using MassTransit;
using PaymentService.Services;
using SharedModels.Models;

namespace PaymentService.Consumer;

public class PaymentConsumer : IConsumer<PaymentRequestDto>
{
    public PaymentConsumer()
    {
    }

    public async Task Consume(ConsumeContext<PaymentRequestDto> context)
    {
        PaymentTrxService paymentTrxService = new PaymentTrxService();
        var result = paymentTrxService.DoDirectPayment(context.Message);
        if (result){
            await Task.CompletedTask;
        }
        else
        {
            throw new InvalidOperationException("Payment processing failed");
        }
    }
}
