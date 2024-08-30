namespace SharedModels.Models;

public class PaymentTrx
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string PaymentRequestId { get; set; }
    public required string CardNumber { get; set; }
    public decimal Amount { get; set; }
    public int Status { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
