using OrderingSystem.Application.DTOs.Orders;
using OrderingSystem.Application.Interfaces;
using OrderingSystem.Domain.ProcedureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public Task<CreateOrderResult> CreateAsync(CreateOrderDto dto)
        {
            return _repo.CreateOrderAsync(dto.CustomerId, dto.Items);
        }

        public Task<OrderDetailsResult?> GetByIdAsync(int id)
        {
            return _repo.GetFullOrderAsync(id);
        }



        public Task<int> CountAsync(
            int? customerId,
            int? status,
            DateTime? startDate,
            DateTime? endDate)
        {
            return _repo.CountAsync(customerId, status, startDate, endDate);
        }

       

        public Task<OrderDetailsResult?> GetFullAsync(int id)
        {
            return _repo.GetFullOrderAsync(id);
        }

        Task<(int TotalCount, List<OrderListResult> Items)> IOrderService.GetPagedAsync(int pageNumber, int pageSize, int? customerId, int? status, DateTime? startDate, DateTime? endDate)
        {
            return _repo.GetPagedOrdersAsync(
              pageNumber,
              pageSize,
              customerId,
              status,
              startDate,
              endDate);
        }

       

        public async Task<bool> UpdateStatusAsync(UpdateOrderStatusDto dto)
        {
            var order = await _repo.GetByIdAsync(dto.OrderId);
            if (order == null) return false;

            order.UpdateStatus(dto.StatusId);

            _repo.Update(order);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
