using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.interfaces.infrastructure.Repositories;
using Application.interfaces.Services;
using Application.interfaces.infrastructure.UnitOfWorks;

namespace Persistence.Services
{
    public class ProductActionService : Service<STI>, IProductActionService
    {
        public ProductActionService(IUnitOfWork unitOfWork, IRepository<STI> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<STI> GetWithProductsByIdAsync(int actionId)
        {
            return await _unitOfWork.Actions.GetWithProductsByIdAsync(actionId);
        }
        
    }
}