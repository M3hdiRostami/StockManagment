using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.interfaces.infrastructure.Repositories
{
    public interface IProductActionRepository : IRepository<STI>
    {
        
        Task<STI> GetWithProductsByIdAsync(int actionId);
        Task<ICollection<STI>> GetWithProductsAsync();
    }
}