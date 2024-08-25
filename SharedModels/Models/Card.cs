using System;

namespace SharedModels.Models;

public class Card
{
    public required string FullName { get; set; }
    public required string CardNumber { get; set; }
    public int CVV { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
}
