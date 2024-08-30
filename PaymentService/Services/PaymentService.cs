using System;
using SharedModels.Models;

namespace PaymentService.Services;

public class PaymentTrxService
{
    private readonly AppDbContext _context;
    public PaymentTrxService()
    {
        _context = new AppDbContext();
    }
    public bool DoDirectPayment(PaymentRequestDto paymentRequest)
    {
        Random random = new Random();
        bool isSuccess = random.Next(2) == 1;
        Console.WriteLine("Ödeme başarılı");
        if(isSuccess)
        {
            _context.Payments.Add(new PaymentTrx {
                Amount = paymentRequest.Amount,
                CardNumber = paymentRequest.CardNum,
                PaymentRequestId = paymentRequest.Id.ToString(),
                Status = 1
            });
            return true;
        } 
        else
        {
            Console.WriteLine("Ödeme başarısız");
            return false;
        }
    }
    

}
