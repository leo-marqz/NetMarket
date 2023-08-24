using Business.Data;
using Core.Entities;
using Core.Repositories;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<IReadOnlyList<T>> GetAllBySpecification(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetDataBySpecification(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>
                .GetQuery(
                inputQuery: _context.Set<T>().AsQueryable(), 
                specification: specification
                );
        }
    }
}
