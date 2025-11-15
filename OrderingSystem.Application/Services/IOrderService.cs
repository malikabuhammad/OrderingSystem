using OrderingSystem.Application.DTOs.Orders;
using OrderingSystem.Domain.ProcedureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Application.Services
{
    public interface IOrderService
    {

        public interface IOrderService
        {
            Task<CreateOrderResult> CreateAsync(CreateOrderItemDto dto);

            Task<OrderDetailsResult?> GetFullAsync(int id);

            Task<List<OrderListResult>> GetPagedAsync(
                int pageNumber,
                int pageSize,
                int? customerId,
                int? status,
                DateTime? startDate,
                DateTime? endDate);
        }
    }
}
