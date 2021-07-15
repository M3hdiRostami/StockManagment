using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.interfaces.infrastructure.Repositories;
using Application.interfaces.infrastructure.UnitOfWorks;
using Persistence.Repositories;
using Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private IRepository<STK> _productRepository;
        private ProductActionRepository _ProductActionRepository;
        

        public IRepository<STK> Products => _productRepository = _productRepository ?? new Repository<STK>(_context);

        public IProductActionRepository Actions => _ProductActionRepository = _ProductActionRepository ?? new ProductActionRepository(_context);
       
        public UnitOfWork(ApplicationDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map, Dictionary<string, object> parameters)
        {

                var command = _context.Database.GetDbConnection().CreateCommand();

                foreach (var item in parameters)
                {
                    var p = command.CreateParameter();
                    p.ParameterName = item.Key;
                    p.Value = item.Value;
                    command.Parameters.Add(p);
                }
                
                command.CommandText = query;
                command.CommandType = CommandType.StoredProcedure;
              
                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    var entities = new List<T>();

                    while (result.Read())
                    {
                        entities.Add(map(result));
                    }

                    return entities;
                }

            
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}