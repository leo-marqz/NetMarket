using Core.Entities;
using Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetDataBySpecification(ISpecification<T> specification);
        Task<IReadOnlyList<T>> GetAllBySpecification(ISpecification<T> specification);
    }
}
