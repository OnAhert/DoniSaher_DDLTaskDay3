using Persistence.Models;

namespace Persistence.Repositories;

public interface ITableSpecificationRepository : IGenericRepository<TableSpecification>
{
    Task AddAsync(TableSpecification tableSpecification);
    Task SaveChangesAsync();
    Task<TableSpecification> GetByIdAsync(Guid id);
    Task UpdateAsync(TableSpecification tableSpecification);
    Task Remove(TableSpecification tableSpecification);
}