using OrderingSystem.Application.Interfaces;
using OrderingSystem.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Infrastructure.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        public Task AddAsync(Orders entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Orders> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(int? customerId, int? status, DateTime? startDate, DateTime? endDate)
        {
            throw new NotImplementedException();
        }

        public void Delete(Orders entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Orders>> FindAsync(Expression<Func<Orders, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Orders>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Orders?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Orders?> GetFullOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Orders>> GetPagedOrdersAsync(int pageNumber, int pageSize, int? customerId, int? status, DateTime? startDate, DateTime? endDate)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Orders entity)
        {
            throw new NotImplementedException();
        }
    }
}
