using System;

namespace PaymentService.Services;

public class PaymentService
{
    private readonly AppDbContext _context;
    public PaymentService(AppDbContext context)
    {
        _context = context;
    }
    

}
