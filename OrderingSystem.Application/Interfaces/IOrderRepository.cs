using OrderingSystem.Application.Repositories;
using OrderingSystem.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Application.Interfaces
{
    public interface IOrderRepository : IRepository<Orders>
    {
        Task<Orders?> GetFullOrderAsync(int id);

        Task<List<Orders>> GetPagedOrdersAsync(
            int pageNumber,
            int pageSize,
            int? customerId,
            int? status,
            DateTime? startDate,
            DateTime? endDate);

        Task<int> CountAsync(
            int? customerId,
            int? status,
            DateTime? startDate,
            DateTime? endDate);
    }
}
