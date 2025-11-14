using Microsoft.EntityFrameworkCore;
using OrderingSystem.Domain.DbModels;
 
namespace OrderingSystem.Infrastructure.Persistence;

public class OrderingDbContext : DbContext
{
    public OrderingDbContext(DbContextOptions<OrderingDbContext> options)
        : base(options) { }

    public DbSet<Customers> Customers => Set<Customers>();
    public DbSet<Products> Products => Set<Products>();
    public DbSet<Orders> Orders => Set<Orders>();
    public DbSet<OrderItems> OrderItems => Set<OrderItems>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderingDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
