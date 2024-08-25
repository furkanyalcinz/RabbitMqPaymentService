using SharedModels.Models;

namespace PaymentClient.Services;

public interface IPaymentRequestService
{
    Task CreateRequest(PaymentRequestDto paymentRequestDto);
}
