using FreshMarket.Domain.Categories;
using FreshMarket.Domain.Customers;
using FreshMarket.Domain.Orders;
using FreshMarket.Domain.Products;
using FreshMarket.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace FreshMarket.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    private readonly EntitySaveChangesInterceptor saveChangesInterceptor;
    private readonly DispatchDomainEventsInterceptor dispatchDomainEventsInterceptor;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        EntitySaveChangesInterceptor saveChangesInterceptor,
        DispatchDomainEventsInterceptor dispatchDomainEventsInterceptor) : base(options)
    {
        this.saveChangesInterceptor = saveChangesInterceptor;
        this.dispatchDomainEventsInterceptor = dispatchDomainEventsInterceptor;
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderSummary> OrderSummaries { get; set; }
    public DbSet<LineItem> LineItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Order of the interceptors is important
        optionsBuilder.AddInterceptors(saveChangesInterceptor, dispatchDomainEventsInterceptor);
    }
}