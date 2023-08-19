using Business.Data;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private readonly MarketplaceDbContext _context;

        public GenericRepository(MarketplaceDbContext context)
        {
            this._context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await this._context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
