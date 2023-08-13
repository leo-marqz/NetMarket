using Business.Data;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.ImplRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketplaceDbContext _context;
        public ProductRepository(MarketplaceDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(product => product.Brand)
                .Include(product => product.Category)
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(product => product.Brand)
                .Include(product => product.Category)
                .FirstOrDefaultAsync(product => product.Id == id);
        }
    }
}
