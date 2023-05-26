using Application.SaleTransactions.Dtos;
using Common.CQRS;
using Domain.Enums;

namespace Application.SaleTransactions.Commands
{
	public class PerformSaleCommand : ICommand
	{
		public PaymentMethodType PaymentMethodType { get; set; }
		public List<SaleItemModel> Items { get; set; } = new List<SaleItemModel>();
	}
}