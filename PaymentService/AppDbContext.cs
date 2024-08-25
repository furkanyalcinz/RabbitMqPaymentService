using System;
using Microsoft.EntityFrameworkCore;
using SharedModels.Models;

namespace PaymentService;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Card> Cards { get; set; }
}
