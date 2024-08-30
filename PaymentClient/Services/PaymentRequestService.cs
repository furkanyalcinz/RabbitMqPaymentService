using MassTransit;
using MassTransit.Initializers;
using Microsoft.EntityFrameworkCore;
using PaymentService;
using SharedModels.Models;

namespace PaymentClient.Services;


public class PaymentRequestService:IPaymentRequestService
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly AppDbContext _dbContext;
    public PaymentRequestService(IPublishEndpoint publishEndpoint, AppDbContext dbContext)
    {
        _publishEndpoint = publishEndpoint;
        _dbContext = dbContext;
    }

    public async Task CreateRequest(PaymentRequestDto paymentRequestDto)
    {
        await _publishEndpoint.Publish<PaymentRequestDto>(paymentRequestDto);
    }
    public Task<List<TransactionStatusResponse>> GetTransactionStatusResponseAsync(string paymentId)
    {
        return _dbContext.Payments.Where(x=> x.PaymentRequestId == paymentId).Select(x => new TransactionStatusResponse {
            Status = x.Status,
            Amount = x.Amount,
            TransactionId = x.Id.ToString(),
        }).ToListAsync();
    }

}
