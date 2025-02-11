using Application.SaleTransactions.Commands;
using Application.SaleTransactions.Dtos;
using Application.SaleTransactions.Queries;
using Application.Security;
using Common.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SalesController : ControllerBase
	{
		private readonly ISender _sender;

		public SalesController(ISender sender)
		{
			_sender = sender;
		}

		[HttpGet("month-sales")]
		public async Task<List<SaleInfoModel>> GetMonthSales([FromQuery] GetMonthSalesQuery query)
		{
			var list = await _sender.Send(query);
			return list;
		}

		[HttpGet("sales")]
		public async Task<Page<SaleInfoModel>> GetMonthSales([FromQuery] GetPagedSalesQuery query)
		{
			var list = await _sender.Send(query);
			return list;
		}

		[HttpPost("perform-sale")]
		[Authorize(Roles = "Admin")]
		public async Task GetMonthSales([FromBody] PerformSaleCommand command)
		{
			await _sender.Send(command);
		}

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request, JwtService jwtService)
        {
            // Simulación de usuario válido (esto debería venir de una base de datos)
            if (request.Username == "admin" && request.Password == "password123")
            {
                var token = jwtService.GenerateToken(request.Username, "Admin");
                return Ok(new { Token = token });
            }

            return Unauthorized("Usuario o contraseña incorrectos");
        }

        [HttpGet("salespaged")]
        public async Task<Page<SaleInfoModel>> GetPagedSales([FromQuery] GetPagedSalesQuery query)
        {
            return await _sender.Send(query);
        }

		[HttpGet("sales-year-report")]
		public async Task<List<SalesForMonthModel>> GetYearSalesReport([FromQuery] GetYearSalesReportQuery query) => await _sender.Send(query);
        
		public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
