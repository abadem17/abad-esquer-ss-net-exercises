using Application.SaleTransactions.Commands;
using Application.SaleTransactions.Dtos;
using Application.SaleTransactions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

		[HttpPost("perform-sale")]
		public async Task GetMonthSales([FromBody] PerformSaleCommand command)
		{
			await _sender.Send(command);
		}
	}
}
