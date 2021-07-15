using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.interfaces.infrastructure.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class ProductActionRepository : Repository<STI>, IProductActionRepository
    {
        private ApplicationDbContext _appDbContext { get => _context as ApplicationDbContext; }

        public ProductActionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ICollection<STI>> GetWithProductsAsync()
        {
            return await _appDbContext.STI.Include(x => x.Mal).ToListAsync();
        }

        public async Task<STI> GetWithProductsByIdAsync(int actionId)
        {
            return await _appDbContext.STI.Include(x => x.Mal).FirstOrDefaultAsync(m => m.ID == actionId);
        }
    }
}