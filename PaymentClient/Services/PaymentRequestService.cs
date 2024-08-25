using MassTransit;
using SharedModels.Models;

namespace PaymentClient.Services;


public class PaymentRequestService:IPaymentRequestService
{
    private readonly IPublishEndpoint _publishEndpoint;
    public PaymentRequestService(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task CreateRequest(PaymentRequestDto paymentRequestDto)
    {
        await _publishEndpoint.Publish<PaymentRequestDto>(paymentRequestDto);
    }

}
