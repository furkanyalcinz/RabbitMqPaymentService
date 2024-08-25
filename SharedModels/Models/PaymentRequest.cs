using System;

namespace SharedModels.Models;

public class PaymentRequestDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string CardNum { get; set; }
    public decimal Amount { get; set; }
}
