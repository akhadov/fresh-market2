using Domain.Blogs;
using FreshMarket.Domain.Categories;
using FreshMarket.Domain.Customers;
using FreshMarket.Domain.Orders;
using FreshMarket.Domain.Products;
using FreshMarket.Infrastructure.Persistence.Interceptors;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FreshMarket.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<User>
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
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<BlogPostComment> BlogPostComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.Entity<User>().Property(u => u.Initials).HasMaxLength(5);

        modelBuilder.HasDefaultSchema("identity");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Order of the interceptors is important
        optionsBuilder.AddInterceptors(saveChangesInterceptor, dispatchDomainEventsInterceptor);
    }
}