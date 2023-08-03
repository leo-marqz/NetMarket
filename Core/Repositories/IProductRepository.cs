using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetAllAsync();
    }
}
