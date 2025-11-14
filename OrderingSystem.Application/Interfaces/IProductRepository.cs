using OrderingSystem.Application.Repositories;
using OrderingSystem.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Application.Interfaces
{

    public interface IProductRepository : IRepository<Products>
    {
        Task<Products?> GetBySkuAsync(string sku);
        Task<bool> SkuExistsAsync(string sku, int? excludeId = null);

        Task<List<Products>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm);

        Task<int> CountAsync(
            string? searchTerm);
    }

}
