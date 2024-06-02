using Ardalis.Specification.EntityFrameworkCore;
using FreshMarket.Application.Common.Interfaces;
using FreshMarket.Domain.Common.Interfaces;

namespace FreshMarket.Infrastructure.Persistence.Repository;

// Inherited from Ardalis.Specification's RepositoryBase<T>
public class ApplicationDbRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot
{
    public ApplicationDbRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

}