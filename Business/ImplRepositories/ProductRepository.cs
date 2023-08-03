using Core.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ImplRepositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<IReadOnlyList<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
