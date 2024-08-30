using SharedModels.Models;

namespace PaymentClient.Services;

public interface IPaymentRequestService
{
    Task CreateRequest(PaymentRequestDto paymentRequestDto);
    Task<List<TransactionStatusResponse>> GetTransactionStatusResponseAsync(string paymentId);
}
