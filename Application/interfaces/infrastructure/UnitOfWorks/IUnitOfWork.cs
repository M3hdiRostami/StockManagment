using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.interfaces.infrastructure.Repositories;
using System.Data.Common;

namespace Application.interfaces.infrastructure.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IRepository<STK> Products { get; }

        IProductActionRepository Actions { get; }
        List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map, Dictionary<string, object> parameters);


        Task CommitAsync();

        void Commit();
    }
}