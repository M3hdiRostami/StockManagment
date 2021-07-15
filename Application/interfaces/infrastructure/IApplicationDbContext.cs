using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.interfaces.infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<STI> STI { get; set; }
        DbSet<STK> STK { get; set; }
       
        Task<int> SaveChangesAsync();
    }
}