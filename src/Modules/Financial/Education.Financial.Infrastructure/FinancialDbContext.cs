using Education.Financial.Domain.Financial;
using Education.Financial.Domain.Payments;
using Microsoft.EntityFrameworkCore;

namespace Education.Financial.Infrastructure;

public class FinancialDbContext : DbContext
{
    public FinancialDbContext(DbContextOptions<FinancialDbContext> options) : base(options)
    {
        
    }

    public FinancialDbContext()
    {
        
    }

    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
}