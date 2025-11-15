using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Application.DTOs.Orders;
using OrderingSystem.Application.Services;

namespace OrderingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet("GetOrdersPaged")]
        public async Task<IActionResult> GetPaged(
            int pageNumber = 1,
            int pageSize = 10,
            int? customerId = null,
            int? status = null,
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            var items = await _service.GetPagedAsync(pageNumber, pageSize, customerId, status, startDate, endDate);
 
            return Ok(new { items.TotalCount, items.Items });
        }

        [HttpGet("GetOrderById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetFullAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> Create(CreateOrderDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }

        [HttpPut("UpdateStatus/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateOrderStatusDto dto)
        {
            var order = await _service.GetFullAsync(id);
            if (order == null) return NotFound();

            if (order.StatusId == 4) return BadRequest("Cannot update cancelled order.");
            if (order.StatusId == 3) return BadRequest("Cannot update shipped order.");

            using var conn = new Microsoft.Data.SqlClient.SqlConnection(
                HttpContext.RequestServices.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection"));

            await conn.OpenAsync();

            using var cmd = new Microsoft.Data.SqlClient.SqlCommand("UpdateOrderStatus", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@OrderId", id);
            cmd.Parameters.AddWithValue("@NewStatusId", dto.StatusId);

            await cmd.ExecuteNonQueryAsync();

            return Ok(new { Success = true });
        }

        [HttpDelete("DeleteOrder/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _service.GetFullAsync(id);
            if (order == null) return NotFound();

            if (order.StatusId != 1) return BadRequest("Only pending orders can be deleted.");

            using var conn = new Microsoft.Data.SqlClient.SqlConnection(
                HttpContext.RequestServices.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection"));

            await conn.OpenAsync();

            using var cmd = new Microsoft.Data.SqlClient.SqlCommand("DeleteOrder", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@OrderId", id);

            await cmd.ExecuteNonQueryAsync();

            return Ok(new { Success = true });
        }
    }
}
