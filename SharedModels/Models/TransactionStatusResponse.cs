namespace SharedModels.Models;

public class TransactionStatusResponse
{
    public string TransactionId { get; set; }
    public decimal Amount { get; set; }
    public int Status { get; set; }
}
