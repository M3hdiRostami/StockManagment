using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.interfaces.Services
{
    public interface IProductActionService : IService<STI>
    {
        Task<STI> GetWithProductsByIdAsync(int actionId);

    }
}