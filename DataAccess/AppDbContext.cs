using System;
using Microsoft.EntityFrameworkCore;
using SharedModels.Models;

namespace PaymentService;

public class AppDbContext:DbContext
{
    public AppDbContext()
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("Test");
    }
    public DbSet<Card> Cards { get; set; }
    public DbSet<PaymentTrx> Payments { get; set; }
}
